package com.ravingdev.itirod.lab4;

import java.util.UUID;

public class AccountNotFoundException extends RuntimeException {
    private UUID id;

    public AccountNotFoundException(UUID id) {
        super(String.format("Account with id %s not found.", id));

        this.id = id;
    }

    public UUID getAccountId() {
        return id;
    }
}
