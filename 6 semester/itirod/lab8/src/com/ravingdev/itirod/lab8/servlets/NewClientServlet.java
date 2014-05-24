package com.ravingdev.itirod.lab8.servlets;

import com.ravingdev.itirod.lab8.html.HtmlPageBuilder;
import com.ravingdev.itirod.lab8.model.Client;
import com.ravingdev.itirod.lab8.services.ClientService;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.UUID;

public class NewClientServlet extends HttpServlet {
    private final ClientService clientService;

    public NewClientServlet() {
        clientService = new ClientService();
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String newFirstName = request.getParameter("firstName");
        String newLastName = request.getParameter("lastName");
        String newEmail = request.getParameter("email");
        clientService.createClient(newFirstName, newLastName, newEmail);
        response.sendRedirect("/clients");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        response.setCharacterEncoding("utf-8");
        HtmlPageBuilder htmlPageBuilder = new HtmlPageBuilder();
        htmlPageBuilder.setHeader("New client");
        StringBuilder pageContentBuilder = new StringBuilder();
        pageContentBuilder.append("<form action=\"/client/new\" method=\"post\">");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"firstName\">First name: </label>");
        pageContentBuilder.append("<input id=\"firstName\" type=\"text\" name=\"firstName\" value=\"\"/>");
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"lastName\">Last name: </label>");
        pageContentBuilder.append("<input id=\"lastName\" type=\"text\" name=\"lastName\" value=\"\"/>");
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<label for=\"email\">Email: </label>");
        pageContentBuilder.append("<input id=\"email\" type=\"text\" name=\"email\" value=\"\"/>");
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("<p>");
        pageContentBuilder.append("<button>Save</button>");
        pageContentBuilder.append("</p>");
        pageContentBuilder.append("</form>");
        htmlPageBuilder.setContent(pageContentBuilder.toString());
        response.getWriter().println(htmlPageBuilder.build());
    }
}
