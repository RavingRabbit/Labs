package com.ravingdev.itirod.lab4;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.data.Repository;
import com.ravingdev.itirod.lab4.model.Account;
import org.apache.log4j.Logger;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.UUID;

public final class Checker implements AutoCloseable {
    private static final Logger LOGGER = Logger.getLogger(Checker.class);
    private static final int DEFAULT_CHECKING_PERIOD = 250;

    private final int checkingPeriod;
    private final CancellationToken checkingCancellationToken = new CancellationToken();
    private final Thread checkingThread;
    private final BigDecimal initialDeposit;
    private Repository<Account> accountRepository;
    private TransactionManger transactionManger;

    public Checker(TransactionManger transactionManger, Repository<Account> accountRepository) {
        this(transactionManger, accountRepository, DEFAULT_CHECKING_PERIOD);
    }

    public Checker(TransactionManger transactionManger, Repository<Account> accountRepository, int checkingPeriod) {
        Requires.notNull(transactionManger, "transactionManger");
        Requires.notNull(accountRepository, "accountRepository");
        Requires.argument(checkingPeriod > 0, "checkingPeriod > 0");

        this.transactionManger = transactionManger;
        this.accountRepository = accountRepository;
        this.checkingPeriod = checkingPeriod;
        this.initialDeposit = calculateBalance();
        this.checkingThread = new Thread(this::checkingLoop);
        this.checkingThread.start();
    }

    private void checkingLoop() {
        while (!checkingCancellationToken.isCancellationRequested()) {
            transactionManger.beginChecking();
            BigDecimal currentBalance = calculateBalance().setScale(0, RoundingMode.HALF_UP);
            BigDecimal expectedBalance = initialDeposit.setScale(0, RoundingMode.HALF_UP);
            boolean balanceEquals = currentBalance.compareTo(expectedBalance) == 0;
            if (balanceEquals) {
                LOGGER.info(String.format("Checking succeed. Expected - %s, actual - %s.",
                        expectedBalance, currentBalance));
            } else {
                LOGGER.error(String.format("Checking failed. Expected - %s, actual - %s.",
                        expectedBalance, currentBalance));
            }
            transactionManger.endChecking();
            try {
                Thread.sleep((long) checkingPeriod);
            } catch (InterruptedException e) {
                //do nothing
            }
        }
    }

    private BigDecimal calculateBalance() {
        BigDecimal balance = new BigDecimal(0);
        for (Account account : accountRepository) {
            UUID accountId = account.getId();
            transactionManger.beginAccountChecking(accountId);
            account = accountRepository.get(accountId);
            BigDecimal accountBalance = account.getBalance();
            balance = balance.add(accountBalance);
            transactionManger.setAccountChecked(accountId);
        }
        return balance;
    }

    @Override
    public void close() throws InterruptedException {
        checkingCancellationToken.cancel();
        checkingThread.join();
    }
}
