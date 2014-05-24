package com.ravingdev.itirod.lab4.view;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.model.Entity;

import java.util.UUID;

public class ClientInfo extends ModelInfo {
    private final String firstName;
    private final String lastName;
    private final String email;

    public ClientInfo(UUID uuid, String firstName, String lastName, String email) {
        super(uuid);

        Requires.notNull(firstName, "firstName");
        Requires.notNull(lastName, "lastName");
        Requires.notNull(email, "email");

        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public String getEmail() {
        return email;
    }
}
