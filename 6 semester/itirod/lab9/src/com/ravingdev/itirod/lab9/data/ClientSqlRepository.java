package com.ravingdev.itirod.lab9.data;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab9.model.Client;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.UUID;

public final class ClientSqlRepository extends SqlRepository<Client> implements ClientRepository {
    private static final String TABLE_NAME = "Clients";

    public ClientSqlRepository(Connection connection) {
        super(connection);

        createTableIfNotExists();
    }

    private void createTableIfNotExists() {
        //noinspection SpellCheckingInspection
        String createTableIfNotExistsSql = String.format(
                "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[%1$s]') " +
                        "AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
                        "CREATE TABLE [dbo].[%1$s] ( " +
                        "[%2$s] UNIQUEIDENTIFIER NOT NULL, " +
                        "[%3$s] NVARCHAR (256) NOT NULL, " +
                        "[%4$s] NVARCHAR (256) NOT NULL, " +
                        "[%5$s] NVARCHAR (256) NOT NULL, " +
                        "[%6$s] BIT NOT NULL, " +
                        "PRIMARY KEY CLUSTERED ([Id])" +
                        ");", TABLE_NAME, ColumnNameFor.ID, ColumnNameFor.FIRST_NAME,
                ColumnNameFor.LAST_NAME, ColumnNameFor.EMAIL, ColumnNameFor.DELETED);
        execute(createTableIfNotExistsSql);
        logger.info("Clients table is created if it did not exist.");
    }

    @Override
    public void create(Client newClient) {
        Requires.notNull(newClient, "newClient");

        String insertNewClientSql = String.format(
                "INSERT INTO [dbo].[%1$s] (%2$s, %3$s, %4$s, %5$s, %6$s) " +
                        "VALUES ('%7$s', '%8$s', '%9$s', '%10$s', '%11$s');",
                TABLE_NAME, ColumnNameFor.ID, ColumnNameFor.FIRST_NAME, ColumnNameFor.LAST_NAME,
                ColumnNameFor.EMAIL, ColumnNameFor.DELETED, newClient.getId().toString(), newClient.getFirstName(),
                newClient.getLastName(), newClient.getEmail(), newClient.isDeleted() ? 1 : 0);
        execute(insertNewClientSql);
    }

    @Override
    public Client get(UUID id) {
        Requires.notNull(id, "id");

        String getSql = String.format(
                "SELECT [%1$s], [%2$s], [%3$s], [%4$s], [%5$s] " +
                        "FROM %6$s " +
                        "WHERE %1$s = '%7$s'",
                ColumnNameFor.ID, ColumnNameFor.FIRST_NAME, ColumnNameFor.LAST_NAME,
                ColumnNameFor.EMAIL, ColumnNameFor.DELETED, TABLE_NAME, id.toString());
        try (ResultSet resultSet = executeQuery(getSql)) {
            if (!resultSet.next())
                return null;
            return readClient(resultSet);
        } catch (SQLException e) {
            throw new DataException(e);
        }
    }

    @Override
    public Collection<Client> getAll() {

        String getSql = String.format(
                "SELECT [%1$s], [%2$s], [%3$s], [%4$s], [%5$s] FROM %6$s",
                ColumnNameFor.ID, ColumnNameFor.FIRST_NAME, ColumnNameFor.LAST_NAME,
                ColumnNameFor.EMAIL, ColumnNameFor.DELETED, TABLE_NAME);
        Collection<Client> clients = new ArrayList<>();
        try (ResultSet resultSet = executeQuery(getSql)) {
            while (resultSet.next()) {
                Client client = readClient(resultSet);
                clients.add(client);
            }
        } catch (SQLException e) {
            throw new DataException(e);
        }
        return clients;
    }

    @Override
    public void update(Client client) {
        Requires.notNull(client, "client");

        String updateSql = String.format(
                "UPDATE %1$s " +
                        "SET [%2$s] = '%3$s', " +
                        "    [%4$s] = '%5$s', " +
                        "    [%6$s] = '%7$s', " +
                        "    [%8$s] = '%9$s' " +
                        "WHERE [%10$s] = '%11$s';",
                TABLE_NAME, ColumnNameFor.FIRST_NAME, client.getFirstName(), ColumnNameFor.LAST_NAME,
                client.getLastName(), ColumnNameFor.EMAIL, client.getEmail(), ColumnNameFor.DELETED,
                client.isDeleted() ? 1 : 0, ColumnNameFor.ID, client.getId().toString());
        executeUpdate(updateSql);
    }

    @Override
    public void delete(UUID id) {
        Requires.notNull(id, "id");

        String deleteSql = String.format(
                "DELETE FROM [dbo].[%1$s] " +
                        "WHERE [%2$s] = '%3$s';",
                TABLE_NAME, ColumnNameFor.ID, id.toString());
        execute(deleteSql);
    }

    @Override
    public Collection<Client> getByName(String firstName, String lastName) {
        Requires.notNull(firstName, "firstName");
        Requires.notNull(lastName, "lastName");

        String getByNameSql = String.format(
                "SELECT [%1$s], [%2$s], [%3$s], [%4$s], [%5$s] " +
                        "FROM [dbo].[%6$s] " +
                        "WHERE [%2$s] = '%7$s' AND [%3$s] = '%8$s'",
                ColumnNameFor.ID, ColumnNameFor.FIRST_NAME, ColumnNameFor.LAST_NAME,
                ColumnNameFor.EMAIL, ColumnNameFor.DELETED, TABLE_NAME, firstName, lastName);
        try (ResultSet resultSet = executeQuery(getByNameSql)) {
            ArrayList<Client> clients = new ArrayList<>();
            while (resultSet.next()) {
                Client client = readClient(resultSet);
                clients.add(client);
            }
            return clients;
        } catch (SQLException e) {
            throw new DataException(e);
        }
    }

    @Override
    public Client getByEmail(String email) {
        Requires.notNull(email, "email");

        String getByNameSql = String.format(
                "SELECT [%1$s], [%2$s], [%3$s], [%4$s], [%5$s] " +
                        "FROM [%6$s] " +
                        "WHERE [%4$s] = '%7$s'",
                ColumnNameFor.ID, ColumnNameFor.FIRST_NAME, ColumnNameFor.LAST_NAME,
                ColumnNameFor.EMAIL, ColumnNameFor.DELETED, TABLE_NAME, email);
        try (ResultSet resultSet = executeQuery(getByNameSql)) {
            if (!resultSet.next())
                throw new DataException(String.format("Client with email %s does not exists.", email));
            return readClient(resultSet);
        } catch (SQLException e) {
            throw new DataException(e);
        }
    }

    private Client readClient(ResultSet resultSet) throws SQLException {
        UUID id = UUID.fromString(resultSet.getString(ColumnNameFor.ID));
        String firstName = resultSet.getNString(ColumnNameFor.FIRST_NAME);
        String lastName = resultSet.getNString(ColumnNameFor.LAST_NAME);
        String email = resultSet.getNString(ColumnNameFor.EMAIL);
        boolean deleted = resultSet.getBoolean(ColumnNameFor.DELETED);
        Client client = new Client(id, firstName, lastName, email);
        client.setDeleted(deleted);
        return client;
    }

    private static class ColumnNameFor {
        public static final String ID = "Id";
        public static final String FIRST_NAME = "FirstName";
        public static final String LAST_NAME = "LastName";
        public static final String EMAIL = "Email";
        public static final String DELETED = "Deleted";
    }
}
