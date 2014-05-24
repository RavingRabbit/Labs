package com.ravingdev.itirod.lab2.containers;

import java.util.LinkedList;

public class LinkedListMatrix extends Matrix {
    private final LinkedList<Double> matrixElements;

    public LinkedListMatrix(int rowCount, int colCount) {
        super(rowCount, colCount);

        matrixElements = new LinkedList<>();
        for (int i = 0; i < rowCount * colCount; i++) {
            matrixElements.add(0.0);
        }
    }

    @Override
    public double getElementValue(int i, int j) {
        checkBounds(i, j);

        int index = calculateIndex(i, j);
        return matrixElements.get(index);
    }

    @Override
    public void setElementValue(int i, int j, double value) {
        checkBounds(i, j);

        int index = calculateIndex(i, j);
        matrixElements.set(index, value);
    }

    @Override
    protected Matrix createEmptyMatrix(int rowCount, int colCount) {
        return new LinkedListMatrix(rowCount, colCount);
    }

    private int calculateIndex(int i, int j) {
        return i * getColCount() + j;
    }
}
