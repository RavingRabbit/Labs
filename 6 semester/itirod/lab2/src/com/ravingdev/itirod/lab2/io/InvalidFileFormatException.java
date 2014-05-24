package com.ravingdev.itirod.lab2.io;

public class InvalidFileFormatException extends Exception {
    private static final String MESSAGE = "File has invalid format.";

    public InvalidFileFormatException() {
        super(MESSAGE);
    }

    public InvalidFileFormatException(Throwable cause) {
        super(MESSAGE, cause);
    }
}
