package com.ravingdev.itirod.lab3;

import com.ravingdev.common.Requires;

import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;
import java.io.StringReader;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class CharacterFrequencyMapGenerator {
    public static Map<Character, Double> generateForFile(String filePath) throws IOException {
        Requires.notNull(filePath, "filePath");

        try (FileReader fileReader = new FileReader(filePath)) {
            return generate(fileReader);
        }
    }

    public static Map<Character, Double> generate(String text) {
        Requires.notNull(text, "text");

        try (StringReader stringReader = new StringReader(text)) {
            return generate(stringReader);
        } catch (IOException e) {
            throw new RuntimeException(); //todo что делать, когда IOException быть не может?
        }
    }

    public static Map<Character, Double> generate(Reader reader) throws IOException {
        Requires.notNull(reader, "reader");

        HashMap<Character, Integer> characterMap = new HashMap<>();
        int ch;
        int characterNumber = 0;
        while ((ch = reader.read()) != -1) {
            if (!Character.isAlphabetic(ch)) continue;
            updateCharacterMap(characterMap, (char) ch);
            characterNumber++;
        }
        return generateFrequencyMap(characterMap, characterNumber);
    }

    private static void updateCharacterMap(Map<Character, Integer> characterMap, char character) {
        if (characterMap.containsKey(character)) {
            Integer number = characterMap.get(character);
            characterMap.put(character, ++number);
        } else {
            characterMap.put(character, 1);
        }
    }

    private static Map<Character, Double> generateFrequencyMap(Map<Character, Integer> characterMap, int characterNumber) {
        HashMap<Character, Double> frequencyTable = new HashMap<>();
        Set<Map.Entry<Character, Integer>> characters = characterMap.entrySet();
        for (Map.Entry<Character, Integer> entry : characters) {
            Double characterFrequency = (double) entry.getValue() / characterNumber;
            frequencyTable.put(entry.getKey(), characterFrequency);
        }
        return frequencyTable;
    }
}
