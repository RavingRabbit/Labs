package com.ravingdev.itirod.lab5.tests.data;

import com.ravingdev.itirod.lab5.data.ClientSqlRepository;
import com.ravingdev.itirod.lab5.data.MssqlUnitOfWork;
import com.ravingdev.itirod.lab5.model.Client;
import org.apache.log4j.Logger;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.UUID;

public class ClientSqlRepositoryTests {
    private static final String MSSQL_DB_URL;
    private static final Logger LOGGER = Logger.getLogger(ClientSqlRepositoryTests.class);

    static {
        //noinspection SpellCheckingInspection
        MSSQL_DB_URL = "jdbc:sqlserver://PROUSERPC\\RAVINGDEVSQLSERV;"
                + "databaseName=Itirod.Lab5.Test;integratedSecurity=true";
    }

    private final MssqlUnitOfWork unitOfWork;
    private final ClientSqlRepository clientSqlRepository;
    private Client testClient;

    public ClientSqlRepositoryTests() {
        unitOfWork = new MssqlUnitOfWork(MSSQL_DB_URL);
        clientSqlRepository = unitOfWork.getClientRepository();
    }

    @Before
    public void setUp() {
        LOGGER.debug("Test started.");
        Client client = new Client(UUID.randomUUID(), "Andrey", "Xyz", "example@mail.com");
        clientSqlRepository.create(client);
        LOGGER.debug("Test client created.");
        testClient = client;
    }

    @After
    public void tearDown() {
        unitOfWork.close();
        LOGGER.debug("Connection closed.");
        LOGGER.debug("Test finished.");
    }

    @Test
    public void testReading() {
        LOGGER.debug("Reading test started.");
        try {
            Client clientFromRepository = clientSqlRepository.get(testClient.getId());

            Assert.assertEquals(testClient.getId(), clientFromRepository.getId());
            Assert.assertEquals(testClient.getFirstName(), clientFromRepository.getFirstName());
            Assert.assertEquals(testClient.getLastName(), clientFromRepository.getLastName());
            Assert.assertEquals(testClient.getEmail(), clientFromRepository.getEmail());
            Assert.assertEquals(testClient.isDeleted(), clientFromRepository.isDeleted());
        } catch (Exception e) {
            LOGGER.info("Reading test failed.", e);
            throw e;
        }
        LOGGER.debug("Reading test completed.");
    }

    @Test
    public void testUpdating() {
        LOGGER.debug("Updating test started.");
        try {
            testClient.setFirstName("NewName");
            clientSqlRepository.update(testClient);
            Client clientFromRepository = clientSqlRepository.get(testClient.getId());

            Assert.assertEquals(clientFromRepository.getFirstName(), testClient.getFirstName());
        } catch (Exception e) {
            LOGGER.info("Updating test failed.", e);
            throw e;
        }
        LOGGER.debug("Updating test completed.");
    }

    @Test
    public void testDeleting() {
        LOGGER.debug("Deleting test started.");
        try {
            clientSqlRepository.delete(testClient.getId());
            Client deletedClient = clientSqlRepository.get(testClient.getId());

            Assert.assertEquals(null, deletedClient);
        } catch (Exception e) {
            LOGGER.info("Deleting test failed.", e);
            throw e;
        }
        LOGGER.debug("Deleting test completed.");
    }
}
