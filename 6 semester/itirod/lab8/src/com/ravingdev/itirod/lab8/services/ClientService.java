package com.ravingdev.itirod.lab8.services;

import com.ravingdev.itirod.lab8.data.ClientRepository;
import com.ravingdev.itirod.lab8.model.Client;

import java.util.Collection;
import java.util.UUID;

public class ClientService extends Service {
    public Client createClient(String firstName, String lastName, String email) {
        ClientRepository clientRepository = getClientRepository();
        Client newClient = new Client(UUID.randomUUID(), firstName, lastName, email);
        clientRepository.create(newClient);
        return newClient;
    }

    public Client getClient(UUID clientId) {
        ClientRepository clientRepository = getClientRepository();
        Client client =  clientRepository.get(clientId);
        if (client == null) {
            throw new ClientNotFoundException(clientId);
        }
        return client;
    }

    public Collection<Client> getAllClients() {
        ClientRepository clientRepository = getClientRepository();
        return clientRepository.getAll();
    }

    public void updateClient(UUID clientId, String newFirstName, String newLastName, String newEmail) {

        ClientRepository clientRepository = getClientRepository();
        Client client =  clientRepository.get(clientId);
        if (client == null) {
            throw new ClientNotFoundException(clientId);
        }
        client.setFirstName(newFirstName);
        client.setLastName(newLastName);
        client.setEmail(newEmail);
        clientRepository.update(client);
    }

    public void deleteClient(UUID clientId) {
        ClientRepository clientRepository = getClientRepository();
        clientRepository.delete(clientId);
    }

    private ClientRepository getClientRepository() {
        return getUnitOfWork().getClientRepository();
    }
}
