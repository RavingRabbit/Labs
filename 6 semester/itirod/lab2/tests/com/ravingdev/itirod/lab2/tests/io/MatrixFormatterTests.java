package com.ravingdev.itirod.lab2.tests.io;

import com.ravingdev.itirod.lab2.containers.ArrayMatrix;
import com.ravingdev.itirod.lab2.containers.Matrix;
import com.ravingdev.itirod.lab2.io.InvalidFileFormatException;
import com.ravingdev.itirod.lab2.io.MatrixFormatter;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.io.File;
import java.io.IOException;

public class MatrixFormatterTests {
    private static final int MATRIX_SIZE = 5;
    private final Matrix randomMatrix;
    private final String tmpFilePath;

    public MatrixFormatterTests() {
        randomMatrix = new ArrayMatrix(MATRIX_SIZE, MATRIX_SIZE);
        randomMatrix.fillByRandomValues();
        String tmpDir = System.getProperty("java.io.tmpdir");
        tmpFilePath = tmpDir + "matrix-02fac7b6-5efd-4e57-9a7c-b4bf27aff72d";
    }

    @Before
    public void setUp() throws java.lang.Exception {
        new File(tmpFilePath);
    }

    @After
    public void tearDown() throws java.lang.Exception {
        //noinspection ResultOfMethodCallIgnored
        new File(tmpFilePath).delete();
    }

    @Test
    public void testSaveLoad() throws IOException, InvalidFileFormatException {
        MatrixFormatter matrixFormatter = new MatrixFormatter();
        matrixFormatter.save(randomMatrix, tmpFilePath);
        Matrix loadedRandomMatrix = matrixFormatter.load(tmpFilePath);
        Assert.assertEquals(randomMatrix, loadedRandomMatrix);
    }
}
