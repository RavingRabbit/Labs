package com.ravingdev.itirod.lab5.data;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab5.model.Entity;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.UUID;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class MockRepository<TEntity extends Entity> implements Repository<TEntity> {
    private final ArrayList<TEntity> entities;
    private final ReentrantReadWriteLock readWriteLock;

    public MockRepository() {
        this(Collections.<TEntity>emptyList());
    }

    public MockRepository(Collection<TEntity> entities) {
        this.entities = new ArrayList<>(entities);
        readWriteLock = new ReentrantReadWriteLock();
    }

    @Override
    public void create(TEntity newEntity) {
        Requires.notNull(newEntity, "newEntity");

        try {
            readWriteLock.writeLock().lock();
            if (find(newEntity.getId()) != null) {
                throwEntityWithSameIdExists(newEntity.getId());
            }
            entities.add(newEntity);
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    @Override
    public TEntity get(UUID id) {
        Requires.notNull(id, "id");

        try {
            readWriteLock.readLock().lock();
            return find(id);
        } finally {
            readWriteLock.readLock().unlock();
        }
    }

    @Override
    public void update(TEntity entity) {
        Requires.notNull(entity, "entity");
        try {
            readWriteLock.writeLock().lock();
            TEntity oldEntity = find(entity.getId());
            if (oldEntity == null) {
                throwEntityNotExists(entity.getId());
            }
            entities.remove(oldEntity);
            entities.add(entity);
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    @Override
    public void delete(UUID id) {
        try {
            readWriteLock.writeLock().lock();
            TEntity oldEntity = find(id);
            if (oldEntity == null) {
                throwEntityNotExists(id);
            }
            entities.remove(oldEntity);
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    private static void throwEntityNotExists(UUID id) {
        throw new DataException(String.format("Entity with id %s do not exists.", id));
    }

    private static void throwEntityWithSameIdExists(UUID id) {
        throw new DataException(String.format("Entity with the same id %s is already exists.", id));
    }

    private TEntity find(UUID id) {
        for (TEntity entity : entities) {
            if (entity.getId().equals(id))
                return entity;
        }
        return null;
    }
}
