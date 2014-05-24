package com.ravingdev.itirod.lab9.tags;

import org.apache.log4j.Logger;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;

public class LogTag extends SimpleTagSupport {
    private static final Logger LOGGER = Logger.getLogger(LogTag.class);
    private String message;

    public void setMessage(String message) {
        this.message = message;
    }

    public void doTag() throws JspException, IOException {
        LOGGER.info(message);
    }
}