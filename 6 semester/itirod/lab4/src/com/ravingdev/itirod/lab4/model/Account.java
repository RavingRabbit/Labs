package com.ravingdev.itirod.lab4.model;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.NotEnoughBalanceException;

import java.math.BigDecimal;
import java.util.UUID;

public class Account extends Entity {
    private final UUID owner;
    private BigDecimal balance;

    public Account(UUID uuid, UUID owner) {
        super(uuid);
        Requires.notNull(owner, "owner");

        this.owner = owner;
        balance = new BigDecimal(0);
    }

    public UUID getOwner() {
        return owner;
    }

    public BigDecimal getBalance() {
        return balance;
    }

    public synchronized void deposit(BigDecimal amount) {
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");

        balance = balance.add(amount);
    }

    public synchronized void withdraw(BigDecimal amount) {
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");

        if (amount.compareTo(getBalance()) > 0) {
            throw new NotEnoughBalanceException();
        }
        balance = balance.subtract(amount);
    }
}
