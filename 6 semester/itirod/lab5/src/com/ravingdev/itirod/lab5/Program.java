package com.ravingdev.itirod.lab5;

import com.ravingdev.itirod.lab5.data.ClientRepository;
import com.ravingdev.itirod.lab5.data.MssqlUnitOfWork;
import com.ravingdev.itirod.lab5.model.Client;
import org.apache.log4j.Logger;

import java.util.UUID;

public class Program {
    private static final Logger LOGGER = Logger.getLogger(Program.class);
    private static final String MSSQL_DB_URL;

    static {
        //noinspection SpellCheckingInspection
        MSSQL_DB_URL = "jdbc:sqlserver://PROUSERPC\\RAVINGDEVSQLSERV;databaseName=Itirod.Lab5;integratedSecurity=true";
    }

    public static void main(String[] args) {
        MssqlUnitOfWork unitOfWork = new MssqlUnitOfWork(MSSQL_DB_URL);
        ClientRepository clientRepository = unitOfWork.getClientRepository();
        Client newClient = generateClient();
        clientRepository.create(newClient);
        Client clientFromRepository = clientRepository.get(newClient.getId());
        LOGGER.info("Client creation succeed? " + newClient.equals(clientFromRepository));
        clientFromRepository.setDeleted(true);
        clientRepository.update(clientFromRepository);
        Client updatedClientFromRepository = clientRepository.get(newClient.getId());
        LOGGER.info("Client updating succeed? " + updatedClientFromRepository.equals(clientFromRepository));
        LOGGER.info("Program completed!");
    }

    private static Client generateClient() {
        return new Client(UUID.randomUUID(), "Andrey", "Xyz", "example@mail.com");
    }
}