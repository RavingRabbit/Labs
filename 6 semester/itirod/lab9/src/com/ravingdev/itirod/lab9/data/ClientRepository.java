package com.ravingdev.itirod.lab9.data;

import com.ravingdev.itirod.lab9.model.Client;

import java.util.Collection;

public interface ClientRepository extends Repository<Client> {
    Collection<Client> getByName(String firstName, String lastName);

    Client getByEmail(String email);
}
