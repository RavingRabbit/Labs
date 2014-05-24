package com.ravingdev.itirod.lab1.models;

public class Person {
    private final String name;

    public Person(String name) {
        if (name == null) {
            throw new IllegalArgumentException("name is null");
        }

        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void greet(Person someone) {
        if (someone == null) {
            throw new IllegalArgumentException("someone");
        }

        String greeting = getGreeting(someone);
        System.out.print(greeting);
    }

    @Override
    public String toString() {
        return getName();
    }

    private String getGreeting(Person someone) {
        String someoneName = someone.getName();
        return String.format("Hello, %s!", someoneName);
    }
}
