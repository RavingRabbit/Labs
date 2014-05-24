package com.ravingdev.itirod.lab4;

public class NotEnoughBalanceException extends RuntimeException {
    public NotEnoughBalanceException() {
        super("Not enough balance to proceed this operation.");
    }
}
