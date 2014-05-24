package com.ravingdev.itirod.lab9.model;

import com.ravingdev.common.Requires;

import java.util.UUID;

public class Entity {
    private final UUID id;
    private boolean deleted;

    public Entity(UUID id) {
        Requires.notNull(id, "id");

        this.id = id;
        deleted = false;
    }

    public UUID getId() {
        return id;
    }

    public boolean isDeleted() {
        return deleted;
    }

    public void setDeleted(boolean value) {
        deleted = value;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Entity entity = (Entity) o;

        return id.equals(entity.id);
    }

    @Override
    public int hashCode() {
        return id.hashCode();
    }
}
