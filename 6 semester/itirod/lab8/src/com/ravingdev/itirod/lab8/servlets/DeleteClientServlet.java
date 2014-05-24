package com.ravingdev.itirod.lab8.servlets;

import com.ravingdev.itirod.lab8.services.ClientService;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.UUID;

public class DeleteClientServlet extends HttpServlet {
    private final ClientService clientService;

    public DeleteClientServlet() {
        clientService = new ClientService();
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String idAsString = request.getParameter("id");
        UUID id = UUID.fromString(idAsString);
        clientService.deleteClient(id);
        response.sendRedirect("/clients");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.sendRedirect("/clients");
    }
}
