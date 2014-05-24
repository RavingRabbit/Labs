package com.ravingdev.itirod.lab3.tests;

import com.ravingdev.itirod.lab3.CharacterFrequencyMapGenerator;
import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Test;

import java.util.HashMap;
import java.util.Map;

public class CharacterFrequencyMapGeneratorTests {
    private static final String TEST_TEXT;
    private static final Map<Character, Double> TEST_TEXT_FREQUENCY_MAP;
    private static final  double EPSILON = 0.000001;

    static {
        TEST_TEXT = "Short text for testing.";
        TEST_TEXT_FREQUENCY_MAP = new HashMap<>();
        TEST_TEXT_FREQUENCY_MAP.put('S', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('h', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('o', 2.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('r', 2.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('t', 5.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('e', 2.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('x', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('f', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('s', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('i', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('n', 1.0/19);
        TEST_TEXT_FREQUENCY_MAP.put('g', 1.0/19);
    }

    private static final Logger LOGGER = Logger.getLogger(CharacterFrequencyMapGeneratorTests.class);

    @Test
    public void testGenerate() {
        Map<Character, Double> frequencyMap = CharacterFrequencyMapGenerator.generate(TEST_TEXT);

        Assert.assertTrue(Math.abs(frequencyMap.get('S') - TEST_TEXT_FREQUENCY_MAP.get('S')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('h') - TEST_TEXT_FREQUENCY_MAP.get('h')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('o') - TEST_TEXT_FREQUENCY_MAP.get('o')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('r') - TEST_TEXT_FREQUENCY_MAP.get('r')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('t') - TEST_TEXT_FREQUENCY_MAP.get('t')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('e') - TEST_TEXT_FREQUENCY_MAP.get('e')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('x') - TEST_TEXT_FREQUENCY_MAP.get('x')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('f') - TEST_TEXT_FREQUENCY_MAP.get('f')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('s') - TEST_TEXT_FREQUENCY_MAP.get('s')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('i') - TEST_TEXT_FREQUENCY_MAP.get('i')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('n') - TEST_TEXT_FREQUENCY_MAP.get('n')) < EPSILON);
        Assert.assertTrue(Math.abs(frequencyMap.get('g') - TEST_TEXT_FREQUENCY_MAP.get('g')) < EPSILON);
    }
}
