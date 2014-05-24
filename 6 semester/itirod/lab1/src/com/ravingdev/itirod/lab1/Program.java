package com.ravingdev.itirod.lab1;

import com.ravingdev.itirod.lab1.models.Person;

public class Program {
    public static void main(String[] args) {
        String userName;
        if (args.length != 0) {
            userName = args[0];
        } else {
            userName = "World";
        }
        Person robot = new Person("Robot");
        Person user = new Person(userName);
        robot.greet(user);
    }
}
