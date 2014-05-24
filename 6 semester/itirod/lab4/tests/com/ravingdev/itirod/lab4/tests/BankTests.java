package com.ravingdev.itirod.lab4.tests;

import com.ravingdev.itirod.lab4.Bank;
import com.ravingdev.itirod.lab4.data.ConcurrentRepository;
import com.ravingdev.itirod.lab4.data.Repository;
import com.ravingdev.itirod.lab4.model.Account;
import com.ravingdev.itirod.lab4.model.Client;
import org.apache.log4j.Logger;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.math.BigDecimal;
import java.math.MathContext;
import java.util.UUID;

public class BankTests {
    private static final Logger LOGGER = Logger.getLogger(BankTests.class);

    private UUID testClientId;
    private UUID[] testAccountsId;
    private final Repository<Account> accountRepository;
    private final Repository<Client> clientRepository;
    private final Bank bank;

    public BankTests() {
        accountRepository = new ConcurrentRepository<>();
        clientRepository = new ConcurrentRepository<>();
        bank = new Bank(accountRepository, clientRepository);
    }

    @Before
    public void setUp() {
        LOGGER.debug("Test started.");
        testAccountsId = new UUID[2];
        testClientId = bank.createClient("Andrey", "Xyz", "example@mail.com");
        testAccountsId[0] = bank.createAccount(testClientId);
        testAccountsId[1] = bank.createAccount(testClientId);

        BigDecimal deposit = new BigDecimal(10000);
        bank.deposit(testAccountsId[0], deposit.multiply(new BigDecimal(3d/5)));
        bank.deposit(testAccountsId[1], deposit.multiply(new BigDecimal(2d/5)));
        LOGGER.debug("Test client and accounts created.");
    }

    @After
    public void tearDown() throws Exception {
        LOGGER.debug("Test finished.");
    }

    @Test
    public void testDepositWithdraw() {
        LOGGER.debug("Deposit-Withdraw test started.");
        BigDecimal balanceBefore = calculateBalance();
        BigDecimal deposit = new BigDecimal(5000);
        BigDecimal balance1Before = bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2Before = bank.getAccount(testAccountsId[1]).getBalance();
        bank.deposit(testAccountsId[0], deposit.multiply(new BigDecimal(4d/5)));
        bank.deposit(testAccountsId[1], deposit.multiply(new BigDecimal(1d/5)));
        bank.withdraw(testAccountsId[0], deposit.multiply(new BigDecimal(2d/5)));

        BigDecimal expectedBalance = balanceBefore.add(deposit.multiply(new BigDecimal(3d/5)));
        BigDecimal balance = calculateBalance();
        MathContext mathContext = new MathContext(2);
        Assert.assertEquals(expectedBalance.round(mathContext), balance.round(mathContext));
        BigDecimal expectedBalance1 = balance1Before.add(deposit.multiply(new BigDecimal(2d/5)));
        BigDecimal expectedBalance2 = balance2Before.add(deposit.multiply(new BigDecimal(1d/5)));
        BigDecimal balance1 = bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2 = bank.getAccount(testAccountsId[1]).getBalance();
        Assert.assertEquals(expectedBalance1.round(mathContext), balance1.round(mathContext));
        Assert.assertEquals(expectedBalance2.round(mathContext), balance2.round(mathContext));
        LOGGER.debug("Deposit-Withdraw test completed.");
    }

    @Test
    public void testTransfer() {
        LOGGER.debug("Transfer test started.");
        BigDecimal balanceBefore = calculateBalance();
        BigDecimal transfer = new BigDecimal(1000);
        BigDecimal balance1Before = bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2Before = bank.getAccount(testAccountsId[1]).getBalance();

        bank.transfer(testAccountsId[0], testAccountsId[1], transfer);
        BigDecimal balance = calculateBalance();
        MathContext mathContext = new MathContext(2);
        BigDecimal balance1 = bank.getAccount(testAccountsId[0]).getBalance();
        BigDecimal balance2 = bank.getAccount(testAccountsId[1]).getBalance();

        Assert.assertEquals(balanceBefore.round(mathContext), balance.round(mathContext));
        Assert.assertEquals(balance1Before.subtract(transfer).round(mathContext), balance1.round(mathContext));
        Assert.assertEquals(balance2Before.add(transfer).round(mathContext), balance2.round(mathContext));
        LOGGER.debug("Transfer test completed.");
    }

    private BigDecimal calculateBalance() {
        BigDecimal balance = new BigDecimal(0);
        for (Account account : accountRepository) {
            balance = balance.add(account.getBalance());
        }
        return balance;
    }
}