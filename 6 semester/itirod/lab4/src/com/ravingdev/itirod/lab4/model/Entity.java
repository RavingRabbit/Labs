package com.ravingdev.itirod.lab4.model;

import com.ravingdev.common.Requires;

import java.io.Serializable;
import java.util.UUID;

public class Entity implements Serializable {
    private final UUID id;
    private boolean deleted;

    public Entity(UUID id) {
        Requires.notNull(id, "id");

        this.id = id;
    }

    public UUID getId() {
        return id;
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

    public boolean isDeleted() {
        return deleted;
    }

    public void setDeleted(boolean deleted) {
        this.deleted = deleted;
    }
}
