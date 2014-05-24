package com.ravingdev.common.diagnostics;

import java.lang.System;

public class Stopwatch {
    private static final long NANOSECONDS_PER_MILLISECOND = 1000000;
    private static final long NANOSECONDS_PER_SECOND = NANOSECONDS_PER_MILLISECOND * 1000;

    private long elapsed;
    private long startTimeStamp;
    private boolean isRunning;

    public Stopwatch() {
        reset();
    }

    public void start() {
        if (!isRunning) {
            startTimeStamp = getTimestamp();
            isRunning = true;
        }
    }

    public static Stopwatch startNew() {
        Stopwatch s = new Stopwatch();
        s.start();
        return s;
    }

    public void stop() {
        if (isRunning) {
            long endTimeStamp = getTimestamp();
            long elapsedThisPeriod = endTimeStamp - startTimeStamp;
            elapsed += elapsedThisPeriod;
            isRunning = false;
        }
    }

    public void reset() {
        elapsed = 0;
        isRunning = false;
        startTimeStamp = 0;
    }

    public void restart() {
        elapsed = 0;
        startTimeStamp = getTimestamp();
        isRunning = true;
    }

    public boolean isRunning() {
        return isRunning;
    }

    public long elapsedMilliseconds() {
        return GetRawElapsedNanoseconds() / NANOSECONDS_PER_MILLISECOND;
    }

    public long elapsedSeconds() {
        return GetRawElapsedNanoseconds() / NANOSECONDS_PER_SECOND;
    }

    public static long getTimestamp() {
        return System.nanoTime();
    }

    private long GetRawElapsedNanoseconds() {
        long timeElapsed = elapsed;

        if (isRunning) {
            long currentTimeStamp = getTimestamp();
            long elapsedUntilNow = currentTimeStamp - startTimeStamp;
            timeElapsed += elapsedUntilNow;
        }
        return timeElapsed;
    }
}
