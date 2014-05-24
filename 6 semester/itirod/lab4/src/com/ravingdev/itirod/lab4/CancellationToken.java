package com.ravingdev.itirod.lab4;


public final class CancellationToken {
    private enum TokenState { FIXED, NOT_FIXED }

    private TokenState tokenState;
    private boolean isCancellationRequested;
    CancellationToken() {
        tokenState = TokenState.NOT_FIXED;
        isCancellationRequested = false;
    }
    public CancellationToken(boolean canceled) {
        tokenState = TokenState.FIXED;
        isCancellationRequested = canceled;
    }
    public synchronized boolean isCancellationRequested() {
        return isCancellationRequested;
    }

    public synchronized void cancel() throws IllegalStateException {
        if (isCancellationRequested) return;
        if (tokenState == TokenState.FIXED)
            throw new IllegalStateException("Cannot change the state of a fixed cancellation token");

        isCancellationRequested = true;
        tokenState = TokenState.FIXED;
    }
}
