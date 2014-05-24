package com.ravingdev.itirod.lab4;

import com.ravingdev.common.Requires;
import com.ravingdev.itirod.lab4.data.Repository;
import com.ravingdev.itirod.lab4.model.Account;
import com.ravingdev.itirod.lab4.model.AccountByOwnerIdSpecification;
import com.ravingdev.itirod.lab4.model.Client;
import com.ravingdev.itirod.lab4.view.AccountInfo;
import com.ravingdev.itirod.lab4.view.ClientInfo;
import org.apache.log4j.Logger;

import java.math.BigDecimal;
import java.util.Collection;
import java.util.UUID;
import java.util.stream.Collectors;

public final class Bank {
    private static final Logger LOGGER = Logger.getLogger(Bank.class);

    private final Repository<Account> accountRepository;
    private final Repository<Client> clientRepository;
    protected final TransactionManger transactionBroker;

    public Bank(Repository<Account> accountRepository, Repository<Client> clientRepository) {
        Requires.notNull(accountRepository, "accountRepository");
        Requires.notNull(clientRepository, "clientRepository");

        this.accountRepository = accountRepository;
        this.clientRepository = clientRepository;
        transactionBroker = new TransactionManger();
    }

    public AccountInfo getAccount(UUID accountId) {
        Requires.notNull(accountId, "accountId");

        Account account = accountRepository.get(accountId);
        if (account == null) {
            throw new AccountNotFoundException(accountId);
        }
        return extractInfo(account);
    }

    public ClientInfo getClient(UUID clientId) {
        Requires.notNull(clientId, "clientId");

        Client client = clientRepository.get(clientId);
        if (client == null) {
            throw new ClientNotFoundException(clientId);
        }
        return extractInfo(client);
    }

    public Collection<AccountInfo> getAccounts(UUID clientId) {
        Requires.notNull(clientId, "clientId");

        AccountByOwnerIdSpecification byOwnerIdSpecification = new AccountByOwnerIdSpecification(clientId);
        Collection<Account> accounts = accountRepository.getBySpecification(byOwnerIdSpecification);
        Collection<AccountInfo> accountInfos = accounts.stream().map(this::extractInfo).collect(Collectors.toList());
        return accountInfos;
    }

    private AccountInfo extractInfo(Account account) {
        return new AccountInfo(account.getId(), account.getOwner(), account.getBalance());
    }

    private ClientInfo extractInfo(Client client) {
        return new ClientInfo(client.getId(), client.getFirstName(), client.getLastName(), client.getEmail());
    }

    public UUID createClient(String firstName, String lastName, String email) {
        Requires.notNull(firstName, "firstName");
        Requires.notNull(lastName, "lastName");
        Requires.notNull(email, "email");

        UUID newClientUUID = UUID.randomUUID();
        Client newClient = new Client(newClientUUID, firstName, lastName, email);
        clientRepository.create(newClient);
        return newClientUUID;
    }

    public UUID createAccount(UUID clientId) {
        Requires.notNull(clientId, "clientId");

        UUID newAccountUUID = UUID.randomUUID();
        Account newAccount = new Account(newAccountUUID, clientId);
        accountRepository.create(newAccount);
        return newAccountUUID;
    }

    public void transfer(UUID fromAccountUUID, UUID toAccountUUID, BigDecimal amount) {
        Requires.notNull(fromAccountUUID, "fromAccountUUID");
        Requires.notNull(toAccountUUID, "fromAccountUUID");
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");
        Requires.argument(!fromAccountUUID.equals(toAccountUUID), "fromAccount == toAccount");

        boolean transactionStarted = false;
        try {
            transactionBroker.beginTransaction(fromAccountUUID, toAccountUUID);
            transactionBroker.beginWithdraw(fromAccountUUID);
            transactionStarted = true;
            LOGGER.debug(String.format("Transaction was started. From %s to %s.", fromAccountUUID, toAccountUUID));
            Account fromAccount = accountRepository.get(fromAccountUUID);
            Account toAccount = accountRepository.get(toAccountUUID);
            fromAccount.withdraw(amount);
            toAccount.deposit(amount);
            accountRepository.update(fromAccount, toAccount);
        } finally {
            if (transactionStarted) {
                LOGGER.debug(String.format("Transaction was finished. From %s to %s.", fromAccountUUID, toAccountUUID));
                transactionBroker.endWithdraw(fromAccountUUID);
                transactionBroker.endTransaction(fromAccountUUID, toAccountUUID);
            }
        }
    }

    public void deposit(UUID toAccountUUID, BigDecimal amount) {
        Requires.notNull(toAccountUUID, "toAccountUUID");
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater then zero.");

        try {
            transactionBroker.beginTransaction(toAccountUUID);
            Account toAccount = accountRepository.get(toAccountUUID);
            toAccount.deposit(amount);
            accountRepository.update(toAccount);
        } finally {
            transactionBroker.endTransaction(toAccountUUID);
        }
    }

    public void withdraw(UUID fromAccountUUID, BigDecimal amount) {
        Requires.notNull(fromAccountUUID, "fromAccountUUID");
        Requires.argument(amount.compareTo(BigDecimal.ZERO) > 0, "amount must be greater them zero.");

        try {
            transactionBroker.beginTransaction(fromAccountUUID);
            transactionBroker.beginWithdraw(fromAccountUUID);
            Account fromAccount = accountRepository.get(fromAccountUUID);
            fromAccount.withdraw(amount);
            accountRepository.update(fromAccount);
        } finally {
            transactionBroker.endWithdraw(fromAccountUUID);
            transactionBroker.endTransaction(fromAccountUUID);
        }
    }

    public void lockForWithdraw(UUID fromAccountId) {
        Requires.notNull(fromAccountId, "fromAccountId");

        transactionBroker.beginWithdraw(fromAccountId);
    }

    public void unlockForWithdraw(UUID fromAccountId) {
        Requires.notNull(fromAccountId, "fromAccountId");

        transactionBroker.endWithdraw(fromAccountId);
    }
}
