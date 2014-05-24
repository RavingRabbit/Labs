package com.ravingdev.itirod.lab2.io;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab2.containers.ArrayMatrix;
import com.ravingdev.itirod.lab2.containers.Matrix;

import java.io.*;

public class MatrixFormatter {
    private static final char ELEMENT_SEPARATOR = ' ';
    private final StringBuffer buffer;

    public MatrixFormatter() {
        this.buffer = new StringBuffer();
    }

    public void save(Matrix matrix, String filePath) throws IOException {
        Requires.notNull(matrix, "matrix");
        Requires.notNull(filePath, "filePath");

        try (FileWriter fileWriter = new FileWriter(filePath)) {
            save(matrix, fileWriter);
        }
    }

    public void save(Matrix matrix, Writer writer) throws IOException {
        Requires.notNull(matrix, "matrix");
        Requires.notNull(writer, "writer");

        int rowCount = matrix.getRowCount();
        int colCount = matrix.getColCount();

        writeStringWithSeparator(writer, String.valueOf(rowCount));
        writeStringWithSeparator(writer, String.valueOf(colCount));

        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                Double elementValue = matrix.getElementValue(i, j);
                writeStringWithSeparator(writer, String.valueOf(elementValue));
            }
        }
    }

    private void writeStringWithSeparator(Writer writer, String str) throws IOException {
        writer.write(str);
        writer.write(ELEMENT_SEPARATOR);
    }

    public Matrix load(String filePath) throws InvalidFileFormatException, IOException {
        Requires.notNull(filePath, "filePath");

        try (FileReader fileReader = new FileReader(filePath)) {
            return load(fileReader);
        }
    }

    public Matrix load(Reader reader) throws InvalidFileFormatException {
        Requires.notNull(reader, "reader");

        int rowCount = readInteger(reader, buffer);
        int colCount = readInteger(reader, buffer);
        if (rowCount <= 0 || colCount <= 0)
            throw new InvalidFileFormatException();

        Matrix matrix = new ArrayMatrix(rowCount, colCount);
        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                double elementValue = readDouble(reader, buffer);
                matrix.setElementValue(i, j, elementValue);
            }
        }
        return matrix;
    }

    private Integer readInteger(Reader reader, StringBuffer buffer) throws InvalidFileFormatException {
        readString(reader, buffer);
        Integer value = Integer.valueOf(buffer.toString());
        buffer.delete(0, buffer.length());
        return value;
    }

    private Double readDouble(Reader reader, StringBuffer buffer) throws InvalidFileFormatException {
        readString(reader, buffer);
        Double value = Double.valueOf(buffer.toString());
        buffer.delete(0, buffer.length());
        return value;
    }

    private void readString(Reader reader, StringBuffer buffer) throws InvalidFileFormatException {
        int ch;

        try {
            while ((ch = reader.read()) != -1 && ch != ELEMENT_SEPARATOR) {
                buffer.append((char) ch);
            }
        } catch (IOException e) {
            throw new InvalidFileFormatException(e);
        }
        if (ch == -1) {
            throw new InvalidFileFormatException();
        }
    }
}
