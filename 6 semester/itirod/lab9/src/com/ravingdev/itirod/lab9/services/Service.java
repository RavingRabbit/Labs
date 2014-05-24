package com.ravingdev.itirod.lab9.services;

import com.ravingdev.itirod.lab9.data.MssqlUnitOfWork;
import com.ravingdev.itirod.lab9.data.UnitOfWork;

public abstract class Service {
    private static final String MSSQL_DB_URL; //todo load from config

    static {
        //noinspection SpellCheckingInspection
        MSSQL_DB_URL = "jdbc:sqlserver://PROUSERPC\\RAVINGDEVSQLSERV;databaseName=Itirod.Lab8;integratedSecurity=true";
    }

    private final UnitOfWork unitOfWork;

    protected Service() {
        unitOfWork = new MssqlUnitOfWork(MSSQL_DB_URL);
    }

    protected UnitOfWork getUnitOfWork() {
        return unitOfWork;
    }
}
