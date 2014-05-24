package com.ravingdev.itirod.lab5.data;

import com.ravingdev.itirod.lab5.model.Entity;

import java.util.UUID;

public interface Repository<TEntity extends Entity> {
    void create(TEntity newEntity);

    TEntity get(UUID id);

    void update(TEntity entity);

    void delete(UUID id);
}