<%@ attribute name="id" required="true" type="java.lang.String" %>
<%@ attribute name="value" type="java.lang.String" %>
<%@ attribute name="label" required="true" type="java.lang.String" %>
<%@ attribute name="type" required="true" type="java.lang.String" %>

<p>
    <label for="${id}">${label}: </label>
    <input type="${type}" id="${id}" name="${id}" value="${value}"/>
</p>
