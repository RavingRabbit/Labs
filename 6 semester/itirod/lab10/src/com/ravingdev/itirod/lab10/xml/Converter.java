package com.ravingdev.itirod.lab10.xml;

import com.ravingdev.itirod.lab10.model.Entity;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.TransformerException;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public interface Converter<T extends Entity> {
    String toXml(Iterable<T> entities) throws ParserConfigurationException, TransformerException;

    List<T> fromXml(InputStream stream) throws ParserConfigurationException, SAXException, IOException;
}
