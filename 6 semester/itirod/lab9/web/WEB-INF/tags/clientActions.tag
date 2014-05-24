<%@ attribute name="clientId" required="true" type="java.util.UUID" %>

<ul>
    <li>
        <a href="/client/edit?id=${clientId}">edit</a>
    </li>
    <li>
        <form action="/client/delete" method="post">
            <input type="hidden" name="id" value="${clientId}"/>
            <button>delete</button>
        </form>
    </li>
</ul>

