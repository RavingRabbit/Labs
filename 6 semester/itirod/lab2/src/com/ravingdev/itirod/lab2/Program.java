package com.ravingdev.itirod.lab2;

import com.ravingdev.common.diagnostics.OperationTimer;
import com.ravingdev.itirod.lab2.containers.ArrayListMatrix;
import com.ravingdev.itirod.lab2.containers.ArrayMatrix;
import com.ravingdev.itirod.lab2.containers.LinkedListMatrix;
import com.ravingdev.itirod.lab2.containers.Matrix;

public class Program {
    public static void main(String[] args) {
        int matrixSize = 100;

        ArrayMatrix arrayMatrix = new ArrayMatrix(matrixSize, matrixSize);
        ArrayListMatrix arrayListMatrix = new ArrayListMatrix(matrixSize, matrixSize);
        LinkedListMatrix linkedListMatrix = new LinkedListMatrix(matrixSize, matrixSize);
        arrayMatrix.fillByRandomValues();
        arrayListMatrix.fillByRandomValues();
        linkedListMatrix.fillByRandomValues();

        int arrayMatrixTestCount = 50;
        int arrayListMatrixTestCount = 50;
        int linkedListMatrixTestCount = 1;
        int linkedListArrayMatrixTestCount = 1;

        testMatrixMultiplying(arrayMatrix, arrayMatrix, arrayMatrixTestCount);
        testMatrixMultiplying(arrayListMatrix, arrayListMatrix, arrayListMatrixTestCount);
        testMatrixMultiplying(linkedListMatrix, linkedListMatrix, linkedListMatrixTestCount);
        testMatrixMultiplying(linkedListMatrix, arrayMatrix, linkedListArrayMatrixTestCount);
    }

    private static void testMatrixMultiplying(Matrix matrix1, Matrix matrix2, int testCount) {
        String matrix1Name = matrix1.getClass().getSimpleName();
        String matrix2Name = matrix2.getClass().getSimpleName();
        System.out.println(String.format("%s * %s (%d times):", matrix1Name, matrix2Name, testCount));
        try (OperationTimer ignored = new OperationTimer()) {
            for (int i = 0; i < testCount; i++) {
                matrix1.multiply(matrix2);
            }
        }
    }
}
