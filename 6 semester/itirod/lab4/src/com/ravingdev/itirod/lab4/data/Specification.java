package com.ravingdev.itirod.lab4.data;

import com.ravingdev.itirod.lab4.model.Entity;

public interface Specification<TEntity extends Entity> {
    boolean isSatisfiedBy(TEntity candidate);
}
