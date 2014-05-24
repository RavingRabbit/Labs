package com.ravingdev.itirod.lab10.xml;

import com.ravingdev.itirod.lab10.model.Client;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import javax.xml.parsers.*;
import javax.xml.transform.Result;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class ClientConverter implements Converter<Client> {
    private static class NameFor {
        private static final String CLIENTS = "clients";
        private static final String CLIENT = "client";
        private static final String ID = "id";
        private static final String FIRST_NAME = "firstName";
        private static final String LAST_NAME = "lastName";
        private static final String EMAIL = "email";
    }

    @SuppressWarnings("FeatureEnvy")
    public String toXml(Iterable<Client> entities) throws ParserConfigurationException, TransformerException {
        DocumentBuilder docBuilderFactory = DocumentBuilderFactory.newInstance().newDocumentBuilder();
        Document document = docBuilderFactory.newDocument();
        Element root = document.createElement(NameFor.CLIENTS);

        for (Client client : entities) {
            Element node = document.createElement(NameFor.CLIENT);
            node.setAttribute(NameFor.ID, client.getId().toString());
            node.setAttribute(NameFor.FIRST_NAME, client.getFirstName());
            node.setAttribute(NameFor.LAST_NAME, client.getLastName());
            node.setAttribute(NameFor.EMAIL, client.getEmail());
            root.appendChild(node);
        }

        StringWriter stringWriter = new StringWriter();
        Result xmlTransformResult = new StreamResult(stringWriter);

        TransformerFactory.newInstance().newTransformer().transform(new DOMSource(root), xmlTransformResult);
        return stringWriter.toString();
    }

    public List<Client> fromXml(InputStream stream) throws ParserConfigurationException, SAXException, IOException {
        SAXParser parser = SAXParserFactory.newInstance().newSAXParser();
        List<Client> clients = new ArrayList<>();
        DefaultHandler handler = new DefaultHandler() {
            @Override
            public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
                if (qName.equals(NameFor.CLIENT)) {
                    String uuidAsString = attributes.getValue(NameFor.ID);
                    UUID id;
                    if (uuidAsString != null) {
                        id = UUID.fromString(uuidAsString);
                    } else {
                        id = new UUID(0L, 0L);
                    }
                    String firstName = attributes.getValue(NameFor.FIRST_NAME);
                    String lastName = attributes.getValue(NameFor.LAST_NAME);
                    String email = attributes.getValue(NameFor.EMAIL);
                    @SuppressWarnings("LocalVariableOfConcreteClass")
                    Client client = new Client(id, firstName, lastName, email);
                    clients.add(client);
                }
            }
        };
        parser.parse(stream, handler);
        return clients;
    }
}
