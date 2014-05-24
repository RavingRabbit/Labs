package com.ravingdev.itirod.lab9.data;

import com.ravingdev.itirod.lab9.model.Entity;

import java.util.Collection;
import java.util.UUID;

public interface Repository<TEntity extends Entity> {
    void create(TEntity newEntity);

    TEntity get(UUID id);

    Collection<TEntity> getAll();

    void update(TEntity entity);

    void delete(UUID id);
}