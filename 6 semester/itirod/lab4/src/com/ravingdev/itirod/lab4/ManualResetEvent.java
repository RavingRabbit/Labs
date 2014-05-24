package com.ravingdev.itirod.lab4;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

public final class ManualResetEvent implements ResetEvent {
    private volatile CountDownLatch event;
    private final Object mutex;

    public ManualResetEvent(boolean signalled) {
        mutex = new Object();
        event = new CountDownLatch(signalled ? 0 : 1);
    }

    public void set() {
        event.countDown();
    }

    public void reset() {
        synchronized (mutex) {
            if (event.getCount() == 0) {
                event = new CountDownLatch(1);
            }
        }
    }

    public void waitOne() throws InterruptedException {
        event.await();
    }

    public boolean waitOne(long timeout, TimeUnit unit) throws InterruptedException {
        return event.await(timeout, unit);
    }

    public boolean isSignalled() {
        return event.getCount() == 0;
    }

}

