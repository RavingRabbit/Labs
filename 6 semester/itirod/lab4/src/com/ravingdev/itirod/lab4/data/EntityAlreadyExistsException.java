package com.ravingdev.itirod.lab4.data;

import java.util.UUID;

public class EntityAlreadyExistsException extends RuntimeException {
    public EntityAlreadyExistsException(UUID uuid) {
        super(uuid.toString());
    }
}
