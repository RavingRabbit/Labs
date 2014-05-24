package com.ravingdev.itirod.lab4.view;

import com.ravingdev.common.Requires;

import java.math.BigDecimal;
import java.util.UUID;

public class AccountInfo extends ModelInfo {
    private final UUID owner;
    private final BigDecimal balance;

    public AccountInfo(UUID uuid, UUID owner, BigDecimal balance) {
        super(uuid);
        Requires.notNull(owner, "owner");
        Requires.notNull(balance, "balance");

        this.owner = owner;
        this.balance = balance;
    }

    public UUID getOwner() {
        return owner;
    }

    public BigDecimal getBalance() {
        return balance;
    }
}
