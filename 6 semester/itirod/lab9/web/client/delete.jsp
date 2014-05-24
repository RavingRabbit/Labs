<%@ page import="com.ravingdev.itirod.lab9.services.ClientService" %>
<%@ page import="java.util.UUID" %>
<%@ page language="java" %>
<%
    boolean isPostMethod = request.getMethod().equals("POST");

    if (!isPostMethod) {
        response.sendRedirect("/clients");
    }
    String idAsString = request.getParameter("id");
    UUID id = UUID.fromString(idAsString);
    ClientService clientService = new ClientService();
    clientService.deleteClient(id);
    response.sendRedirect("/clients");
%>