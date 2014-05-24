package com.ravingdev.itirod.lab9.tags;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.tagext.SimpleTagSupport;
import java.io.IOException;
import java.util.concurrent.atomic.AtomicLong;

public class RequestsCounterTag extends SimpleTagSupport {
    private static AtomicLong counter = new AtomicLong();

    public void doTag() throws JspException, IOException
    {
        long requests = counter.incrementAndGet();
        getJspContext().getOut().print(requests);
    }
}