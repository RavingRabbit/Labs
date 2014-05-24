package com.ravingdev.itirod.lab4.model;

import com.ravingdev.itirod.lab4.data.Specification;

public class AllSatisfiedSpecification<TEntity extends Entity> implements Specification<TEntity> {
    @Override
    public boolean isSatisfiedBy(TEntity candidate) {
        return true;
    }
}
