package com.ravingdev.itirod.lab4.data;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.model.Entity;

import java.io.*;
import java.util.*;
import java.util.concurrent.locks.ReentrantReadWriteLock;
import java.util.stream.Collectors;

public final class ConcurrentRepository<TEntity extends Entity> implements Repository<TEntity> {
    private final class ConcurrentRepositoryIterator implements Iterator<TEntity> {
        private Iterator<UUID> entityIdIterator;

        private ConcurrentRepositoryIterator() {
            entityIdIterator = entities.keySet().stream().collect(Collectors.toList()).iterator();
        }

        @Override
        public boolean hasNext() {
            return entityIdIterator.hasNext();
        }

        @Override
        public TEntity next() {
            if (!hasNext()) {
                throw new NoSuchElementException();
            }
            UUID entityId = entityIdIterator.next();
            return get(entityId);
        }
    }

    private final Map<UUID, TEntity> entities;
    private final ReentrantReadWriteLock readWriteLock;

    public ConcurrentRepository() {
        this(Collections.<TEntity>emptyList());
    }

    public ConcurrentRepository(Collection<TEntity> entities) {
        this.entities = new HashMap<>(entities.size());
        for (TEntity entity : entities) {
            this.entities.put(entity.getId(), entity);
        }
        readWriteLock = new ReentrantReadWriteLock();
    }

    @Override
    public void create(TEntity newEntity) {
        Requires.notNull(newEntity, "newEntity");

        try {
            readWriteLock.writeLock().lock();
            if (find(newEntity.getId()) != null) {
                throw new EntityAlreadyExistsException(newEntity.getId());
            }
            addNewEntityInternal(newEntity);
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    private void addNewEntityInternal(TEntity entity) {
        TEntity entityDeepCopy = cloneEntity(entity);
        entities.put(entityDeepCopy.getId(), entityDeepCopy);
    }

    @Override
    public TEntity get(UUID id) {
        Requires.notNull(id, "id");

        try {
            readWriteLock.readLock().lock();
            TEntity entity = find(id);
            return cloneEntity(entity);
        } finally {
            readWriteLock.readLock().unlock();
        }
    }

    @Override
    public Collection<TEntity> getBySpecification(Specification<TEntity> specification) {
        Requires.notNull(specification, "specification");

        try {
            readWriteLock.readLock().lock();
            Collection<TEntity> satisfiedEntities = new ArrayList<>();

            entities.values().stream().filter(entity -> specification.isSatisfiedBy(entity)).forEach(entity -> {
                TEntity entityDeepCopy = cloneEntity(entity);
                satisfiedEntities.add(entityDeepCopy);
            });
            return satisfiedEntities;
        } finally {
            readWriteLock.readLock().unlock();
        }
    }

    @SafeVarargs
    @Override
    public final void update(TEntity... entities) {
        Requires.notNull(entities, "entities");

        try {
            readWriteLock.writeLock().lock();
            for (TEntity entity : entities) {
                TEntity oldEntity = find(entity.getId());
                if (oldEntity == null) {
                    throw new EntityNotFoundException(entity.getId());
                }
                updateEntityInternal(oldEntity, entity);
            }
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    private void updateEntityInternal(TEntity oldEntity, TEntity newEntity) {
        TEntity entityDeepCopy = cloneEntity(newEntity);
        entities.replace(oldEntity.getId(), oldEntity, entityDeepCopy);
    }

    @Override
    public void delete(UUID id) {
        try {
            readWriteLock.writeLock().lock();
            TEntity oldEntity = get(id);
            if (oldEntity == null) {
                throw new EntityNotFoundException(id);
            }
            oldEntity.setDeleted(true);
            update(oldEntity);
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    @Override
    public Iterator<TEntity> iterator() {
        try {
            readWriteLock.writeLock().lock();
            return new ConcurrentRepositoryIterator();
        } finally {
            readWriteLock.writeLock().unlock();
        }
    }

    private TEntity cloneEntity(TEntity entity) {
        if (entity == null) {
            return null;
        }

        byte[] serializedEntity;
        try (ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
            try (ObjectOutput objectOutputStream = new ObjectOutputStream(outputStream)) {
                objectOutputStream.writeObject(entity);
                objectOutputStream.close();
            }
            serializedEntity = outputStream.toByteArray();
        } catch (IOException e) {
            return null;
        }
        TEntity deserializedEntity;
        try (ByteArrayInputStream inputStream = new ByteArrayInputStream(serializedEntity)) {
            try (ObjectInput objectInputStream = new ObjectInputStream(inputStream)) {
                deserializedEntity = (TEntity) objectInputStream.readObject();
            }
        } catch (ClassNotFoundException e) {
            return null;
        } catch (IOException e) {
            return null;
        }
        return deserializedEntity;
    }

    private TEntity find(UUID id) {
        TEntity entity =  entities.getOrDefault(id, null);
        if (entity == null || entity.isDeleted()) {
            return null;
        }
        return entity;
    }
}
