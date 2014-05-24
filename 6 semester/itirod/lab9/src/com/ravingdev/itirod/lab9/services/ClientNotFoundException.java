package com.ravingdev.itirod.lab9.services;

import java.util.UUID;

public class ClientNotFoundException extends RuntimeException {
    private UUID id;

    public ClientNotFoundException(UUID id) {
        super(String.format("Client with id %s not found.", id));

        this.id = id;
    }

    public UUID getClientId() {
        return id;
    }
}