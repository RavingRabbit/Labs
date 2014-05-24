<%@ page import="com.ravingdev.itirod.lab9.services.ClientService" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="tags" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="ext" uri="/WEB-INF/custom.tld" %>
<%
    ClientService clientService = new ClientService();
    boolean isPostMethod = request.getMethod().equals("POST");
    if (isPostMethod) {
        String newFirstName = request.getParameter("firstName");
        String newLastName = request.getParameter("lastName");
        String newEmail = request.getParameter("email");
        clientService.createClient(newFirstName, newLastName, newEmail);
        response.sendRedirect("/clients");
    }
%>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>New client | RavingDev-jsp</title>
</head>
<body>
<div>
    <h1>New client</h1>

    <div>
        <form action="/client/new" method="post">
            <tags:labeledInput id="firstName" label="First name" type="text"/>
            <tags:labeledInput id="lastName" label="Last name" type="text"/>
            <tags:labeledInput id="email" label="Email" type="text"/>
            <p>
                <button>Save</button>
            </p>
        </form>
    </div>
</div>
Current date: <tags:now/>. Requests: <ext:requests />.
</body>
</html>
