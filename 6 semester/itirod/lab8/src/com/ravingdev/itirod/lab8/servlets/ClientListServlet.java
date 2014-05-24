package com.ravingdev.itirod.lab8.servlets;

import com.ravingdev.itirod.lab8.html.HtmlPageBuilder;
import com.ravingdev.itirod.lab8.model.Client;
import com.ravingdev.itirod.lab8.services.ClientService;

import java.io.IOException;
import java.util.Collection;

public class ClientListServlet extends javax.servlet.http.HttpServlet {
    private final ClientService clientService;

    public ClientListServlet() {
        clientService = new ClientService();
    }

    @Override
    protected void doPost(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        response.sendRedirect("/clients");
    }

    @Override
    protected void doGet(javax.servlet.http.HttpServletRequest request, javax.servlet.http.HttpServletResponse response) throws javax.servlet.ServletException, IOException {
        response.setContentType("text/html");
        response.setCharacterEncoding("utf-8");
        HtmlPageBuilder htmlPageBuilder = new HtmlPageBuilder();
        htmlPageBuilder.setHeader("Clients");
        Collection<Client> clients = clientService.getAllClients();
        StringBuilder pageContentBuilder = new StringBuilder();
        pageContentBuilder.append("<div><table border=\"1\">");
        pageContentBuilder.append("<tr><th>First name</th><th>Last name</th><th>Email</th><th>Actions</th></tr>");
        String actionButtonsPattern = "<a href=\"/client/edit?id=%s\">edit</a> <form action=\"/client/delete\" method=\"post\">" +
                "<input type=\"hidden\" name=\"id\" value=\"%s\"/><button>delete</button></form>";
        for (Client client : clients) {
            pageContentBuilder.append("<tr>");
            pageContentBuilder.append(String.format("<td>%s</td><td>%s</td><td>%s</td>",
                    client.getFirstName(), client.getLastName(), client.getEmail()));
            pageContentBuilder.append(String.format("<td>" + actionButtonsPattern + "</td>", client.getId(), client.getId()));
            pageContentBuilder.append("</tr>");
        }
        pageContentBuilder.append("</table></div>");
        pageContentBuilder.append("<a href=\"/client/new\" title=\"Add new client\">Add new client</a>");
        htmlPageBuilder.setContent(pageContentBuilder.toString());
        response.getWriter().println(htmlPageBuilder.build());
    }
}
