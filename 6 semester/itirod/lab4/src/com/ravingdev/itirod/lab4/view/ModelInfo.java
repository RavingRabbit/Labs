package com.ravingdev.itirod.lab4.view;

import com.ravingdev.common.Requires;

import java.io.Serializable;
import java.util.UUID;

public class ModelInfo {
    private final UUID id;

    public ModelInfo(UUID id) {
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

        ModelInfo entity = (ModelInfo) o;

        return id.equals(entity.id);
    }

    @Override
    public int hashCode() {
        return id.hashCode();
    }
}