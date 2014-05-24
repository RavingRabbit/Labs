package com.ravingdev.itirod.lab8.html;

import com.ravingdev.common.Requires;

public class HtmlPageBuilder {
    private String header;
    private String content;

    public void setHeader(String header) {
        Requires.notNull(header, "header");

        this.header = header;
    }

    public void setContent(String content) {
        Requires.notNull(content, "content");

        this.content = content;
    }

    public String build() {
        return String.format("<!DOCTYPE html><html>" +
                "<head><title>%s | RavingDev</title><meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/></head>" +
                "<body><h1>%s</h1><div>%s</div></body>" +
                "</html>", header, header, content);
    }
}
