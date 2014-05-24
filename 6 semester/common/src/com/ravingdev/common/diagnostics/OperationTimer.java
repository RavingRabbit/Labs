package com.ravingdev.common.diagnostics;

import java.lang.AutoCloseable;
import java.lang.Override;
import java.lang.String;
import java.lang.System;

public class OperationTimer implements AutoCloseable {
    private final Stopwatch stopwatch;

    public OperationTimer() {
        stopwatch = Stopwatch.startNew();
    }

    @Override
    public void close() {
        stopwatch.stop();
        long elapsedMillis = stopwatch.elapsedMilliseconds();
        System.out.println(String.format("Elapsed millis: %d.", elapsedMillis));
    }
}
