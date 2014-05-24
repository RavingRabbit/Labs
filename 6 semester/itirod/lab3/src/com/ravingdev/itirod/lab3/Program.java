package com.ravingdev.itirod.lab3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Map;
import java.util.Set;

public class Program {
    public static void main(String[] args) {
        String filePath;
        if (args.length != 0) {
            filePath = args[0];
        } else {
            System.out.print("Enter file path: ");
            try {
                filePath = getLineFromSystemIn();
            } catch (IOException e) {
                System.out.println("IO error trying to read file path.");
                return;
            }
        }
        printCharacterFrequencyMapForFile(filePath);
    }

    private static void printCharacterFrequencyMapForFile(String filePath) {
        Map<Character, Double> characterFrequencyMap;
        try {
            characterFrequencyMap = CharacterFrequencyMapGenerator.generateForFile(filePath);
        } catch (IOException e) {
            System.out.println("IO error trying read file. " + e.getMessage());
            return;
        }
        System.out.println(String.format("File - %s", filePath));
        printCharacterFrequencyMap(characterFrequencyMap);
    }

    private static void printCharacterFrequencyMap(Map<Character, Double> characterFrequencyMap) {
        Set<Map.Entry<Character, Double>> mapEntrySet = characterFrequencyMap.entrySet();
        for (Map.Entry<Character, Double> entry : mapEntrySet) {
            System.out.println(String.format("%s - %.2f%%", entry.getKey(), entry.getValue() * 100));
        }
    }

    private static String getLineFromSystemIn() throws IOException {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(System.in))) {
            return br.readLine();
        }
    }
}
