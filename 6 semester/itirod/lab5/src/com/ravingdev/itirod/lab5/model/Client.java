package com.ravingdev.itirod.lab5.model;

import com.ravingdev.common.Requires;

import java.util.UUID;

public class Client extends Entity {
    private String firstName;
    private String lastName;
    private String email;

    public Client(UUID uuid, String firstName, String lastName, String email) {
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

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
