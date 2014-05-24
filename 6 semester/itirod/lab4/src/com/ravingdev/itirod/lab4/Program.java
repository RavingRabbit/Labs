package com.ravingdev.itirod.lab4;

import com.ravingdev.itirod.lab4.data.ConcurrentRepository;
import com.ravingdev.itirod.lab4.data.Repository;
import com.ravingdev.itirod.lab4.model.Account;
import com.ravingdev.itirod.lab4.model.Client;
import org.apache.log4j.Logger;

import java.io.IOException;
import java.math.BigDecimal;
import java.util.*;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.atomic.AtomicLong;

public class Program {
    private static final Logger LOGGER = Logger.getLogger(Program.class);

    private static final int INITIAL_DEPOSIT = 10000000;
    private static final int ACCOUNTS_COUNT = 60;
    private static final int THREADS_COUNT = 50;
    private static final int CHECKING_PERIOD = 250;
    private static final List<UUID> ACCOUNTS;
    private static final BlockingQueue<Cashier> CASHIERS;
    private static final Repository<Account> ACCOUNT_REPOSITORY;
    private static final Repository<Client> CLIENT_REPOSITORY;
    private static final Bank BANK;
    private static final CancellationToken STOP_THREADS_CANCELLATION_TOKEN = new CancellationToken();
    private static final AtomicLong TRANSACTIONS_COUNT = new AtomicLong();

    static {
        ACCOUNTS = new ArrayList<>(ACCOUNTS_COUNT);
        ACCOUNT_REPOSITORY = new ConcurrentRepository<>();
        CLIENT_REPOSITORY = new ConcurrentRepository<>();
        BANK = new Bank(ACCOUNT_REPOSITORY, CLIENT_REPOSITORY);
        CASHIERS = new ArrayBlockingQueue<>(THREADS_COUNT);
        for (int i = 0; i < THREADS_COUNT; i++) {
            CASHIERS.add(new Cashier(BANK));
        }
    }

    public static void main(String[] args) {
        createTestAccounts();
        LOGGER.info("Test started.");
        Checker checker = new Checker(BANK.transactionBroker, ACCOUNT_REPOSITORY, CHECKING_PERIOD);
        Collection<Thread> clientThreads = new ArrayList<>(THREADS_COUNT);
        for (int i = 0; i < THREADS_COUNT; i++) {
            Thread clientThread = new Thread(Program::clientLoop);
            clientThreads.add(clientThread);
            clientThread.start();
        }
        int key = 'e';
        do {
            try {
                key = System.in.read();
            } catch (IOException e) {
                LOGGER.error(e);
            }
            LOGGER.info(String.format("Transactions count = %s.", TRANSACTIONS_COUNT));
        } while (key != 'e' && key != -1);
        STOP_THREADS_CANCELLATION_TOKEN.cancel();
        try {
            checker.close();
            for (Thread clientThread : clientThreads) {
                clientThread.join();
            }
        } catch (InterruptedException e) {
            LOGGER.error(e);
        }
        LOGGER.info("Test finished.");
    }

    private static void clientLoop() {
        while (!STOP_THREADS_CANCELLATION_TOKEN.isCancellationRequested()) {
            Cashier cashier = null;
            try {
                UUID fromAccount = getRandomAccountFromList();
                UUID toAccount;
                do {
                    toAccount = getRandomAccountFromList();
                } while (toAccount.equals(fromAccount));
                cashier = CASHIERS.take();
                cashier.serve(fromAccount);
                BigDecimal balance = cashier.getBalance();
                if (balance.compareTo(BigDecimal.ZERO) == 0) {
                    continue;
                }
                BigDecimal transferAmount = balance.divide(new BigDecimal(5));
                cashier.transfer(toAccount, transferAmount);
                TRANSACTIONS_COUNT.incrementAndGet();
            } catch (NotEnoughBalanceException e) {
                LOGGER.warn("Client attempted to transfer more more money then it is on account.");
            } catch (Exception e) {
                LOGGER.error("Transaction was not finished. " + e.getMessage(), e);
            } finally {
                if (cashier != null) {
                    cashier.endServe();
                }
                try {
                    CASHIERS.put(cashier);
                } catch (InterruptedException e) {
                    LOGGER.error(e);
                }
            }
        }
    }

    private static UUID getRandomAccountFromList() {
        Random random = new Random();
        return ACCOUNTS.get(random.nextInt(ACCOUNTS.size() - 1));
    }

    private static void createTestAccounts() {
        for (int i = 0; i < ACCOUNTS_COUNT; i++) {
            Account testAccount = new Account(UUID.randomUUID(), UUID.randomUUID());
            testAccount.deposit(new BigDecimal((double) INITIAL_DEPOSIT / (double) ACCOUNTS_COUNT));
            ACCOUNT_REPOSITORY.create(testAccount);
            ACCOUNTS.add(testAccount.getId());
        }
    }
}
