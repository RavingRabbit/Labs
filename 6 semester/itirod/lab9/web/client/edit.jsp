<%@ page import="com.ravingdev.itirod.lab9.model.Client" %>
<%@ page import="com.ravingdev.itirod.lab9.services.ClientService" %>
<%@ page import="java.util.UUID" %>
<%@ taglib prefix="tags" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="ext" uri="/WEB-INF/custom.tld" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    ClientService clientService = new ClientService();
    boolean isPostMethod = request.getMethod().equals("POST");
    if (isPostMethod) {
        String idAsString = request.getParameter("id");
        UUID id = UUID.fromString(idAsString);
        String newFirstName = request.getParameter("newFirstName");
        String newLastName = request.getParameter("newLastName");
        String newEmail = request.getParameter("newEmail");
        clientService.updateClient(id, newFirstName, newLastName, newEmail);
        response.sendRedirect("/clients");
    }
%>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>Client editing | RavingDev-jsp</title>
</head>
<body>
<div>
    <h1>Client editing</h1>

    <div>
        <%
            String idAsString = request.getParameter("id");
            UUID id = UUID.fromString(idAsString);
            Client client = clientService.getClient(id);
        %>
        <form action="/client/edit" method="post">
            <input type="hidden" name="id" value="<%= client.getId() %>"/>
            <tags:labeledInput id="newFirstName" label="Email" type="text" value="<%= client.getFirstName() %>"/>
            <tags:labeledInput id="newLastName" label="Email" type="text" value="<%= client.getLastName() %>"/>
            <tags:labeledInput id="newEmail" label="Email" type="text" value="<%= client.getEmail() %>"/>
            <p>
                <button>Save</button>
            </p>
        </form>
    </div>
</div>
Current date: <tags:now/>. Requests: <ext:requests />.
</body>
</html>
