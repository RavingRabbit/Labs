package com.ravingdev.itirod.lab10.servlets;

import com.ravingdev.itirod.lab10.model.Client;
import com.ravingdev.itirod.lab10.services.ClientService;
import com.ravingdev.itirod.lab10.xml.ClientConverter;
import com.ravingdev.itirod.lab10.xml.Converter;
import org.apache.log4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.Collection;

public class ClientsServlet extends HttpServlet {
    private static final Logger LOGGER = Logger.getLogger(ClientsServlet.class);

    private final ClientService clientService;
    private final Converter<Client> clientConverter;

    public ClientsServlet() {
        clientService = new ClientService();
        clientConverter = new ClientConverter();
    }


    @Override
    public void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        Collection<Client> clients = clientService.getAllClients();
        String clientsAsXml;
        try {
            clientsAsXml = clientConverter.toXml(clients);
        } catch (Exception e) {
            LOGGER.error(e);
            resp.sendError(HttpServletResponse.SC_INTERNAL_SERVER_ERROR);
            return;
        }
        resp.getWriter().println(clientsAsXml);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws IOException {
        String firstName = req.getParameter("firstName");
        String lastName = req.getParameter("lastName");
        String email = req.getParameter("email");
        clientService.createClient(firstName, lastName, email);
        resp.sendRedirect("/clients");
    }
}