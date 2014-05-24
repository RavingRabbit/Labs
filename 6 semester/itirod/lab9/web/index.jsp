<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="tags" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="ext" uri="/WEB-INF/custom.tld" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>RavingDev-jsp</title>
</head>
<body>
<div>
    <h1>RavingDev company jsp</h1>

    <p>
        Our <a href="/clients" title="clients">clients</a>.
    </p>
</div>
Current date: <tags:now/>. Requests: <ext:requests />.
</body>
</html>
<ext:log message="Index page was rendered."/>