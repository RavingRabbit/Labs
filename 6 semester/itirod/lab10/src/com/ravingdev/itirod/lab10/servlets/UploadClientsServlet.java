package com.ravingdev.itirod.lab10.servlets;

import com.ravingdev.itirod.lab10.model.Client;
import com.ravingdev.itirod.lab10.services.ClientService;
import com.ravingdev.itirod.lab10.xml.ClientConverter;
import org.apache.log4j.Logger;

import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

@MultipartConfig
public class UploadClientsServlet extends HttpServlet {
    private static final Logger LOGGER = Logger.getLogger(UploadClientsServlet.class);

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.getWriter().println("<html><body><h1>Clients uploading (xml)</h1><br /><div>" +
                "<form method='POST' enctype='multipart/form-data'><input type='file' name='file' />\n" +
                "<input type='submit' value='Send file' /></form>" +
                "</div></body></html>");
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        Part filePart = req.getPart("file"); // Retrieves <input type="file" name="file">
        InputStream fileStream = filePart.getInputStream();
        try {
            List<Client> clients = new ClientConverter().fromXml(fileStream);
            ClientService clientService = new ClientService();
            for (Client client : clients) {
                clientService.createClient(client.getFirstName(), client.getLastName(), client.getEmail());
            }
        } catch (Exception e) {
            LOGGER.error(e);
            resp.sendError(HttpServletResponse.SC_INTERNAL_SERVER_ERROR);
            return;
        }
        resp.sendRedirect("/xslt/clients");
    }
}