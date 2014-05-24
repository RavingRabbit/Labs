package com.ravingdev.itirod.lab4;

public interface ResetEvent {
    void set();

    void reset();

    void waitOne() throws InterruptedException;

    boolean isSignalled();
}
