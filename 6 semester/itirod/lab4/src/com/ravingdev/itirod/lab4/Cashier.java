package com.ravingdev.itirod.lab4;

import com.ravingdev.common.Requires;

import java.math.BigDecimal;
import java.util.UUID;

public final class Cashier {
    private final Bank bank;
    private UUID accountId;

    public Cashier(Bank bank) {
        Requires.notNull(bank, "bank");

        this.bank = bank;
    }

    public void serve(UUID accountId) {
        Requires.notNull(accountId, "accountId");

        if (this.accountId != null) {
            throw new IllegalStateException("Cashier is busy.");
        }
        this.accountId = accountId;
        bank.lockForWithdraw(accountId);
    }

    public BigDecimal getBalance() {
        return bank.getAccount(this.accountId).getBalance();
    }

    public void transfer(UUID toAccountId, BigDecimal amount) {
        Requires.notNull(toAccountId, "toAccountId");
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");
        Requires.argument(!this.accountId.equals(toAccountId), "fromAccount == toAccount");

        bank.transfer(accountId, toAccountId, amount);
    }

    public void deposit(BigDecimal amount) {
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");

        bank.deposit(accountId, amount);
    }

    public void withdraw(BigDecimal amount) {
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");

        bank.withdraw(accountId, amount);
    }

    public void endServe() {
        Requires.notNull(accountId, "accountId");

        if (accountId == null) {
            return;
        }
        bank.unlockForWithdraw(accountId);
        accountId = null;
    }
}
