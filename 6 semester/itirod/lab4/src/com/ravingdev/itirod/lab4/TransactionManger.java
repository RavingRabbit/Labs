package com.ravingdev.itirod.lab4;

import com.ravingdev.common.Requires;
import java.util.Arrays;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;


public class TransactionManger {
    private final Map<UUID, Lock> lockedForTransaction = new ConcurrentHashMap<>();
    private final Map<UUID, Lock> lockedForWithdraw = new ConcurrentHashMap<>();
    private final Map<UUID, Lock> lockedForChecking = new ConcurrentHashMap<>();
    private final Map<UUID, ResetEvent> checkingMap = new ConcurrentHashMap<>();
    private final ReadWriteLock allowNewCheckingCycleLock = new ReentrantReadWriteLock();

    public TransactionManger() {

    }

    public void beginWithdraw(UUID accountId) {
        Requires.notNull(accountId, "accountId");

        Lock lock = new ReentrantLock();
        Lock lockOrNull = lockedForWithdraw.putIfAbsent(accountId, lock);
        if (lockOrNull != null) {
            lock = lockOrNull;
        }
        lock.lock();
    }

    public void endWithdraw(UUID accountID) {
        Requires.notNull(accountID, "accountUUID");

        lockedForWithdraw.get(accountID).unlock();
    }

    public void beginChecking() {
        try {
            allowNewCheckingCycleLock.writeLock().lock();
            for (ResetEvent event : checkingMap.values()) {
                event.reset();
            }
        } finally {
            allowNewCheckingCycleLock.writeLock().unlock();
        }
    }

    public void endChecking() {
        for (ResetEvent event : checkingMap.values()) {
            event.set();
        }
    }

    public void beginTransaction(UUID... transactionObjects) {
        Requires.notNull(transactionObjects, "transactionObjects");

        Arrays.sort(transactionObjects);
        for (UUID id : transactionObjects) {
            lockForTransaction(id);
        }
        for (UUID id : transactionObjects) {
            lockForChecking(id);
        }
        blockNewCheckingCycle();
        boolean haveSameState = isAccountsHaveSameCheckingState(transactionObjects);
        if (!haveSameState) {
            for (UUID id : transactionObjects) {
                unlockForChecking(id);
            }
            for (UUID id : transactionObjects) {
                waitChecked(id);
            }
            for (UUID id : transactionObjects) {
                lockForChecking(id);
            }
        }
        allowNewCheckingCycle();
    }

    private void lockForTransaction(UUID accountId) {
        Lock lock = new ReentrantLock();
        Lock lockOrNull = lockedForTransaction.putIfAbsent(accountId, lock);
        lock = lockOrNull != null ? lockOrNull : lock;
        lock.lock();
    }

    public void endTransaction(UUID... transactionObjects) {
        Requires.notNull(transactionObjects, "transactionObjects");

        for (UUID id : transactionObjects) {
            unlockAfterTransaction(id);
            unlockForChecking(id);
        }
    }

    private void unlockAfterTransaction(UUID accountId) {
        Lock lock = lockedForTransaction.get(accountId);
        lock.unlock();
    }

    private boolean isAccountsHaveSameCheckingState(UUID... transactionObjects) {
        boolean isFirstChecked = isAccountChecked(transactionObjects[0]);
        for (int i = 1; i < transactionObjects.length; i++) {
            if (isFirstChecked != isAccountChecked(transactionObjects[i])) {
                return false;
            }
        }
        return true;
    }

    private boolean isAccountChecked(UUID accountId) {
        ResetEvent newEvent = new ManualResetEvent(false);
        ResetEvent previousEvent = checkingMap.putIfAbsent(accountId, newEvent);
        return previousEvent != null && previousEvent.isSignalled();
    }

    private void waitChecked(UUID accountId) {
        ResetEvent newEvent = new ManualResetEvent(false);
        ResetEvent previousEvent = checkingMap.putIfAbsent(accountId, newEvent);
        ResetEvent checkingEvent = previousEvent != null ? previousEvent : newEvent;
        try {
            checkingEvent.waitOne();
        } catch (InterruptedException e) {
            //do nothing
        }
    }

    public void beginAccountChecking(UUID accountId) {
        lockForChecking(accountId);
    }

    private void lockForChecking(UUID accountID) {
        Lock newLock = new ReentrantLock();
        Lock lockOrNull = lockedForChecking.putIfAbsent(accountID, newLock);
        Lock lock = lockOrNull != null ? lockOrNull : newLock;
        lock.lock();
    }

    public void setAccountChecked(UUID accountId) {
        ResetEvent newEvent = new ManualResetEvent(true);
        ResetEvent previousEvent = checkingMap.putIfAbsent(accountId, newEvent);
        if (previousEvent != null) {
            previousEvent.set();
        }
        unlockForChecking(accountId);
    }

    private void unlockForChecking(UUID accountID) {
        Lock lock = lockedForChecking.getOrDefault(accountID, null);
        if (lock != null) {
            lock.unlock();
        }
    }

    private void blockNewCheckingCycle() {
        allowNewCheckingCycleLock.readLock().lock();
    }

    private void allowNewCheckingCycle() {
        allowNewCheckingCycleLock.readLock().unlock();
    }
}