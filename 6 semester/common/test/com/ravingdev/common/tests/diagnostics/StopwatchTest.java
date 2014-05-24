package com.ravingdev.common.tests.diagnostics;

import com.ravingdev.common.diagnostics.Stopwatch;
import org.junit.Assert;
import org.junit.Test;

public class StopwatchTest {
    private static final int MEASURING_ERROR_MILLIS = 50;

    @Test
    public void TestStopwatch() throws InterruptedException {
        int millis = 1000;
        Stopwatch sw = Stopwatch.startNew();
        Thread.sleep(millis);
        long elapsedMillis = sw.elapsedMilliseconds();
        Assert.assertTrue(Math.abs(elapsedMillis - millis) < MEASURING_ERROR_MILLIS);
    }
}
