package com.ravingdev.itirod.lab4.model;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.data.Specification;

import java.util.UUID;

public class AccountByOwnerIdSpecification implements Specification<Account> {
    private final UUID ownerId;

    public AccountByOwnerIdSpecification(UUID ownerId) {
        Requires.notNull(ownerId, "ownerId");

        this.ownerId = ownerId;
    }

    @Override
    public boolean isSatisfiedBy(Account candidate) {
        return candidate.getOwner().equals(ownerId);
    }
}
