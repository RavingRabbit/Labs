package com.ravingdev.itirod.lab9.data;

import com.ravingdev.common.Requires;
import org.apache.log4j.Logger;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public final class MssqlUnitOfWork implements UnitOfWork, AutoCloseable {
    private static final Logger LOGGER = Logger.getLogger(MssqlUnitOfWork.class);
    @SuppressWarnings("SpellCheckingInspection")
    private static final String MSSQL_SERVER_DRIVER_CLASS_NAME = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private static final boolean MSSQL_SERVER_DRIVER_INITIALIZED;

    static {
        boolean mssqlServerDriverInitialized;
        try {
            Class.forName(MSSQL_SERVER_DRIVER_CLASS_NAME);
            mssqlServerDriverInitialized = true;
        } catch (ClassNotFoundException e) {
            //noinspection SpellCheckingInspection
            LOGGER.error("Cannot load mssql jdbc driver.", e);
            mssqlServerDriverInitialized = false;
        }
        MSSQL_SERVER_DRIVER_INITIALIZED = mssqlServerDriverInitialized;
    }

    private final Connection connection;

    public MssqlUnitOfWork(String url) {
        Requires.notNull(url, "url");

        if (!MSSQL_SERVER_DRIVER_INITIALIZED) {
            throw new DataException("Cannot find MsSql server driver class. " + MSSQL_SERVER_DRIVER_CLASS_NAME);
        }
        connection = createConnection(url);
    }

    @Override
    public ClientSqlRepository getClientRepository() {
        return new ClientSqlRepository(connection);
    }

    private Connection createConnection(String url) {
        try {
            return DriverManager.getConnection(url);
        } catch (SQLException e) {
            LOGGER.error("Can not establish a connection to the database.", e);
            throw new DataException("Cannot connect to database.", e);
        }
    }

    @Override
    public void close() {
        try {
            if (!connection.isClosed())
                connection.close();
        } catch (SQLException e) {
            LOGGER.error("An error occurred while trying to close the connection.", e);
            throw new DataException(e);
        }
    }
}
