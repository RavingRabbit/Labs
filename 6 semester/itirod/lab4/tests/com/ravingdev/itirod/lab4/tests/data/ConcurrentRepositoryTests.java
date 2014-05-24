package com.ravingdev.itirod.lab4.tests.data;

import com.ravingdev.itirod.lab4.data.ConcurrentRepository;
import com.ravingdev.itirod.lab4.model.Client;
import org.apache.log4j.Logger;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.UUID;

public class ConcurrentRepositoryTests {
    private static final Logger LOGGER = Logger.getLogger(ConcurrentRepositoryTests.class);

    private final Client testClient;
    private ConcurrentRepository<Client> clientMockRepository;

    public ConcurrentRepositoryTests() {
        testClient = new Client(UUID.randomUUID(), "Andrey", "Xyz","example@mail.com");
        clientMockRepository = new ConcurrentRepository<>();
    }

    @Before
    public void setUp() {
        LOGGER.debug("Test started.");
        clientMockRepository.create(testClient);
        LOGGER.debug("Test client created.");
    }

    @After
    public void tearDown() throws Exception {
        LOGGER.debug("Test finished.");
    }

    @Test
    public void testReading() {
        LOGGER.debug("Reading test started.");
        try {
            Client clientFromRepository = clientMockRepository.get(testClient.getId());
            Assert.assertEquals(testClient.getId(), clientFromRepository.getId());
            Assert.assertEquals(testClient.getFirstName(), clientFromRepository.getFirstName());
            Assert.assertEquals(testClient.getLastName(), clientFromRepository.getLastName());
            Assert.assertEquals(testClient.getEmail(), clientFromRepository.getEmail());
        } catch (Exception e) {
            LOGGER.info("Reading test failed.", e);
            throw e;
        }
        LOGGER.debug("Reading test completed.");
    }

    @Test
    public void testUpdating() throws Exception {
        LOGGER.debug("Updating test started.");
        try {
            testClient.setFirstName("NewName");
            clientMockRepository.update(testClient);
            Client clientFromRepository = clientMockRepository.get(testClient.getId());

            Assert.assertEquals(clientFromRepository.getFirstName(), testClient.getFirstName());
        } catch (Exception e) {
            LOGGER.info("Updating test failed.", e);
            throw e;
        }
        LOGGER.debug("Updating test completed.");
    }

    @Test
    public void testDeleting() throws Exception {
        LOGGER.debug("Deleting test started.");
        try {
            clientMockRepository.delete(testClient.getId());
            Client deletedClient = clientMockRepository.get(testClient.getId());

            Assert.assertEquals(null, deletedClient);
        } catch (Exception e) {
            LOGGER.info("Deleting test failed.", e);
            throw e;
        }
        LOGGER.debug("Deleting test completed.");
    }
}
