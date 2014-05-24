package com.ravingdev.itirod.lab8.data;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab8.model.Entity;
import org.apache.log4j.Logger;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public abstract class SqlRepository<TEntity extends Entity> implements Repository<TEntity> {
    protected final Logger logger = Logger.getLogger(getClass());
    private final Connection connection;

    protected SqlRepository(Connection connection) {
        Requires.notNull(connection, "connection");
        try {
            Requires.argument(!connection.isClosed(), "connection is closed.");
        } catch (SQLException e) {
            throw new DataException(e);
        }

        this.connection = connection;
    }

    protected void execute(String sql) {
        Requires.notNull(sql, "sql");

        try (Statement statement = connection.createStatement()) {
            statement.execute(sql);
        } catch (SQLException e) {
            logger.error("Sql query execution failed. Query: " + sql, e);
            throw new DataException(e);
        }
        logger.debug("Sql query executed: " + sql);
    }

    protected int executeUpdate(String sql) {
        Requires.notNull(sql, "sql");

        try (Statement statement = connection.createStatement()) {
            int updatingResult = statement.executeUpdate(sql);
            logger.debug("Sql query executed: " + sql);
            return updatingResult;
        } catch (SQLException e) {
            logger.error("Sql query execution failed. Query: " + sql, e);
            throw new DataException(e);
        }
    }

    protected ResultSet executeQuery(String sql) {
        Requires.notNull(sql, "sql");

        try {
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(sql);
            logger.debug("Sql query executed: " + sql);
            return resultSet;
        } catch (SQLException e) {
            logger.error("Sql query execution failed. Query: " + sql, e);
            throw new DataException(e);
        }
    }
}
