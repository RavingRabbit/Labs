<%@ page import="com.ravingdev.itirod.lab9.model.Client" %>
<%@ page import="com.ravingdev.itirod.lab9.services.ClientService" %>
<%@ page import="java.util.Collection" %>
<%@ taglib prefix="tags" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="ext" uri="/WEB-INF/custom.tld" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>Clients | RavingDev-jsp</title>
</head>
<body>

<div>
    <h1>Clients</h1>

    <div>
        <table border="1">
            <tr>
                <th>First name</th>
                <th>Last name</th>
                <th>Email</th>
                <th>Actions</th>
            </tr>
            <%
                ClientService clientService = new ClientService();
                Collection<Client> clients = clientService.getAllClients();
                for (Client client : clients) {
            %>
            <tr>
                <td><%= client.getFirstName() %>
                </td>
                <td><%= client.getLastName() %>
                </td>
                <td><%= client.getEmail() %>
                </td>
                <td>
                    <tags:clientActions clientId="<%= client.getId() %>"/>
                </td>
            </tr>
            <%
                }
            %>
        </table>
        <a href="/client/new" title="Add new client">Add new client</a>
    </div>
</div>
Current date: <tags:now/>. Requests: <ext:requests />.
</body>
</html>
