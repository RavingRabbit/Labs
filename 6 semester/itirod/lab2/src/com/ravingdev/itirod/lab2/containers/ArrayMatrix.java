package com.ravingdev.itirod.lab2.containers;

public class ArrayMatrix extends Matrix {
    private final double[][] matrixElements;

    public ArrayMatrix(int rowCount, int colCount) {
        super(rowCount, colCount);

        matrixElements = new double[rowCount][colCount];
    }

    @Override
    public double getElementValue(int i, int j) {
        checkBounds(i, j);

        return matrixElements[i][j];
    }

    @Override
    public void setElementValue(int i, int j, double value) {
        checkBounds(i, j);

        matrixElements[i][j] = value;
    }

    @Override
    protected Matrix createEmptyMatrix(int rowCount, int colCount) {
        return new ArrayMatrix(rowCount, colCount);
    }
}
