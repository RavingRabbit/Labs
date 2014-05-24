package com.ravingdev.itirod.lab4.data;

import java.util.UUID;

public class EntityNotFoundException extends RuntimeException {
    private UUID id;

    public EntityNotFoundException(UUID id) {
        super(String.format("Entity with id %s not found.", id));

        this.id = id;
    }

    public UUID getEntityId() {
        return id;
    }
}
