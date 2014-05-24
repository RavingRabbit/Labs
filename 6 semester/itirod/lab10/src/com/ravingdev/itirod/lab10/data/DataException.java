package com.ravingdev.itirod.lab10.data;

public class DataException extends RuntimeException {
    public DataException(String message) {
        super(message);
    }

    public DataException(Throwable throwable) {
        super(throwable);
    }

    public DataException(String message, Throwable throwable) {
        super(message, throwable);
    }
}
