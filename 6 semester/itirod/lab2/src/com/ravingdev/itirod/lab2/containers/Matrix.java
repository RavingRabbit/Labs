package com.ravingdev.itirod.lab2.containers;

import com.ravingdev.common.Requires;

import java.io.Serializable;
import java.util.Random;

public abstract class Matrix implements Serializable {
    private final int rowCount;
    private final int colCount;

    protected Matrix(int rowCount, int colCount) {
        Requires.argument(rowCount >= 1, "rowCount must be greater then zero.");
        Requires.argument(colCount >= 1, "colCount must be greater then zero.");

        this.rowCount = rowCount;
        this.colCount = colCount;
    }

    public int getRowCount() {
        return rowCount;
    }

    public int getColCount() {
        return colCount;
    }

    public Matrix multiply(Matrix otherMatrix) {
        Requires.notNull(otherMatrix, "otherMatrix");
        Requires.argument(getColCount() == otherMatrix.getRowCount(),
                "otherMatrix rowCount must be equals current matrix colCount");

        int m1RowCount = getRowCount();
        int m1ColCount = getColCount();
        int m2ColCount = otherMatrix.getColCount();
        Matrix resultMatrix = createEmptyMatrix(m1RowCount, m2ColCount);
        for (int i = 0; i < m1RowCount; i++) {
            for (int j = 0; j < m2ColCount; j++) {
                double elementValue = 0;
                for (int r = 0; r < m1ColCount; r++) {
                    elementValue += getElementValue(i, r) * otherMatrix.getElementValue(r, j);
                }
                resultMatrix.setElementValue(i, j, elementValue);
            }
        }
        return resultMatrix;
    }

    public abstract double getElementValue(int i, int j);

    public abstract void setElementValue(int i, int j, double value);

    protected abstract Matrix createEmptyMatrix(int rowCount, int colCount);

    protected void checkBounds(int i, int j) {
        Requires.argument(i >= 0 && i < getRowCount(), "Row index is out of matrix bounds.");
        Requires.argument(j >= 0 && j < getColCount(), "Col index is out of matrix bounds.");
    }

    public void fillBy(Double[][] elementValues) {
        Requires.notNull(elementValues, "elementValues");
        Requires.argument(getRowCount() == elementValues.length, "Wrong array size.");
        Requires.argument(getColCount() == elementValues[0].length, "Wrong array size.");

        int rowCount = getRowCount();
        int colCount = getColCount();
        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                setElementValue(i, j, elementValues[i][j]);
            }
        }
    }

    public void fillBy(Matrix otherMatrix) {
        Requires.notNull(otherMatrix, "otherMatrix");
        Requires.argument(getRowCount() == otherMatrix.getRowCount(), "Matrix must have the same size.");
        Requires.argument(getColCount() == otherMatrix.getColCount(), "Matrix must have the same size.");

        int rowCount = getRowCount();
        int colCount = getColCount();
        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                double elementValue = otherMatrix.getElementValue(i, j);
                setElementValue(i, j, elementValue);
            }
        }
    }

    public void fillDiagonalBy(double value) {
        Requires.argument(getRowCount() == getColCount(), "matrix must be square.");

        int size = getRowCount();
        for (int i = 0; i < size; i++) {
            setElementValue(i, i, value);
        }
    }

    public void fillByRandomValues() {
        int rowCount = getRowCount();
        int colCount = getColCount();
        Random random = new Random();
        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                double value = random.nextDouble();
                setElementValue(i, j, value);
            }
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < getRowCount(); i++) {
            for (int j = 0; j < getColCount(); j++) {
                sb.append(getElementValue(i, j));
                sb.append(' ');
            }
            if (i != (getRowCount() - 1)) { //if not last iteration
                sb.append(System.lineSeparator());
            }
        }
        return sb.toString();
    }

    @Override
    public boolean equals(Object obj) {
        if ((obj == null) || !(obj instanceof Matrix))
            return false;
        Matrix otherMatrix = (Matrix) obj;
        int m1RowCount = getRowCount();
        int m1ColCount = getColCount();
        if ((m1RowCount != otherMatrix.getRowCount()) || (m1ColCount != otherMatrix.getColCount())) {
            return false;
        }
        for (int i = 0; i < m1RowCount; i++) {
            for (int j = 0; j < m1ColCount; j++) {
                if (getElementValue(i, j) != otherMatrix.getElementValue(i, j)) {
                    return false;
                }
            }
        }
        return true;
    }

    @Override
    public int hashCode() {
        int result = rowCount;
        result = 31 * result + colCount;
        return result;
    }
}
