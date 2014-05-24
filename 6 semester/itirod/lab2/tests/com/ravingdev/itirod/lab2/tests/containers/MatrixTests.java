package com.ravingdev.itirod.lab2.tests.containers;

import com.ravingdev.itirod.lab2.containers.ArrayListMatrix;
import com.ravingdev.itirod.lab2.containers.ArrayMatrix;
import com.ravingdev.itirod.lab2.containers.Matrix;
import org.junit.Assert;
import org.junit.Test;

public class MatrixTests {
    private static final int MATRIX_SIZE = 5;
    private final Matrix zeroMatrix;
    private final Matrix randomMatrix;
    private final Matrix identityMatrix;

    public MatrixTests() {
        zeroMatrix = new ArrayListMatrix(MATRIX_SIZE, MATRIX_SIZE);
        randomMatrix = new ArrayListMatrix(MATRIX_SIZE, MATRIX_SIZE);
        randomMatrix.fillByRandomValues();
        identityMatrix = new ArrayListMatrix(MATRIX_SIZE, MATRIX_SIZE);
        identityMatrix.fillDiagonalBy(1);
    }

    @Test
    public void testMultiply() {
        Assert.assertEquals(zeroMatrix, zeroMatrix.multiply(randomMatrix));
        Assert.assertEquals(zeroMatrix, randomMatrix.multiply(zeroMatrix));
        Assert.assertEquals(identityMatrix, identityMatrix.multiply(identityMatrix));
        Assert.assertEquals(randomMatrix, randomMatrix.multiply(identityMatrix));
        Assert.assertFalse(randomMatrix.equals(randomMatrix.multiply(randomMatrix)));
    }

    @Test
    public void testDifferentTypesMatrixMultiply() {
        Matrix arrayMatrix = new ArrayMatrix(MATRIX_SIZE, MATRIX_SIZE);
        Matrix arrayListMatrix = new ArrayListMatrix(MATRIX_SIZE, MATRIX_SIZE);
        Matrix linkedListMatrix = new ArrayListMatrix(MATRIX_SIZE, MATRIX_SIZE);

        arrayMatrix.fillByRandomValues();
        arrayListMatrix.fillBy(arrayMatrix);
        linkedListMatrix.fillBy(arrayMatrix);

        Matrix m1 = arrayMatrix.multiply(arrayListMatrix);
        Matrix m2 = arrayMatrix.multiply(linkedListMatrix);
        Matrix m3 = arrayListMatrix.multiply(linkedListMatrix);
        Assert.assertEquals(m1, m2);
        Assert.assertEquals(m1, m3);
    }

    @Test
    public void testEquals() {
        Assert.assertTrue(randomMatrix.equals(randomMatrix));
        //noinspection ObjectEqualsNull
        Assert.assertFalse(randomMatrix.equals(null));
        Assert.assertFalse(identityMatrix.equals(zeroMatrix));
    }
}

