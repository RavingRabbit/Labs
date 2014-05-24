package com.ravingdev.itirod.lab4.data;

import com.ravingdev.itirod.lab4.model.Entity;

import java.util.Collection;
import java.util.Iterator;
import java.util.UUID;

public interface Repository<TEntity extends Entity> extends Iterable<TEntity> {
    void create(TEntity newEntity);

    TEntity get(UUID id);

    Collection<TEntity> getBySpecification(Specification<TEntity> specification);

    void update(TEntity... entities);

    void delete(UUID id);

    Iterator<TEntity> iterator();
}
