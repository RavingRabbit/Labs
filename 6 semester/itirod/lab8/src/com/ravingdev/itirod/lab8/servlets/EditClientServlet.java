package com.ravingdev.itirod.lab8.servlets;

import com.ravingdev.itirod.lab8.html.HtmlPageBuilder;
import com.ravingdev.itirod.lab8.model.Client;
import com.ravingdev.itirod.lab8.services.ClientService;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.Collection;
import java.util.UUID;

public class EditClientServlet extends HttpServlet {
    private final ClientService clientService;

    public EditClientServlet() {
        clientService = new ClientService();
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String idAsString = request.getParameter("id");
        UUID id = UUID.fromString(idAsString);
        String newFirstName = request.getParameter("newFirstName");
        String newLastName = request.getParameter("newLastName");
        String newEmail = request.getParameter("newEmail");
        clientService.updateClient(id, newFirstName, newLastName, newEmail);
        response.sendRedirect("/clients");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String idAsString = request.getParameter("id");
        UUID id = UUID.fromString(idAsString);
        Client client = clientService.getClient(id);
        response.setContentType("text/html");
        response.setCharacterEncoding("utf-8");
        HtmlPageBuilder htmlPageBuilder = new HtmlPageBuilder();
        htmlPageBuilder.setHeader("Client editing");
        StringBuilder pageContentBuilder = new StringBuilder();
        pageContentBuilder.append("<form action=\"/client/edit\" method=\"post\">");
        pageContentBuilder.append(String.format("<input type=\"hidden\" name=\"id\" value=\"%s\"/>", client.getId()));
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"newFirstName\">First name: </label>");
        pageContentBuilder.append(String.format("<input id=\"newFirstName\" type=\"text\" name=\"newFirstName\" value=\"%s\"/>", client.getFirstName()));
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"newLastName\">Last name: </label>");
        pageContentBuilder.append(String.format("<input id=\"newLastName\" type=\"text\" name=\"newLastName\" value=\"%s\"/>", client.getLastName()));
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"newEmail\">Email: </label>");
        pageContentBuilder.append(String.format("<input id=\"newEmail\" type=\"text\" name=\"newEmail\" value=\"%s\"/>", client.getEmail()));
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<button>Save</button>");
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("</form>");
        htmlPageBuilder.setContent(pageContentBuilder.toString());
        response.getWriter().println(htmlPageBuilder.build());
    }
}
