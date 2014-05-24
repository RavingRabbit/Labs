package com.ravingdev.itirod.lab2.tests.io;

import com.ravingdev.itirod.lab2.containers.ArrayMatrix;
import com.ravingdev.itirod.lab2.containers.Matrix;
import org.junit.Assert;
import org.junit.Test;

import java.io.*;

public class MatrixSerializationTests {
    private static final int MATRIX_SIZE = 5;
    private final Matrix randomMatrix;

    public MatrixSerializationTests() {
        randomMatrix = new ArrayMatrix(MATRIX_SIZE, MATRIX_SIZE);
        randomMatrix.fillByRandomValues();
    }

    @Test
    public void testSerializationAndDeserialization() throws IOException, ClassNotFoundException {
        byte[] serializedMatrix;
        try (ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
            serializeMatrix(randomMatrix, outputStream);
            serializedMatrix = outputStream.toByteArray();
        }
        Matrix deserializedMatrix;
        try (ByteArrayInputStream inputStream = new ByteArrayInputStream(serializedMatrix)) {
            deserializedMatrix = deserializeMatrix(inputStream);
        }
        Assert.assertEquals(randomMatrix, deserializedMatrix);
    }

    private void serializeMatrix(Matrix matrix, OutputStream outputStream) throws IOException {
        ObjectOutputStream oos = new ObjectOutputStream(outputStream);
        oos.writeObject(matrix);
    }

    private Matrix deserializeMatrix(InputStream inputStream) throws IOException, ClassNotFoundException {
        ObjectInputStream ois = new ObjectInputStream(inputStream);
        return (Matrix) ois.readObject();
    }
}
