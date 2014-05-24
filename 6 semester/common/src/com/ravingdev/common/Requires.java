package com.ravingdev.common;

public final class Requires {
    public static void  notNull(Object value, String parameterName)
    {
        if (value == null) {
            throw new IllegalArgumentException(String.format("%s is null.", parameterName));
        }
    }

    public static void argument(Boolean condition)
    {
        argument(condition, "");
    }

    public static void argument(Boolean condition, String message)
    {
        if (!condition) {
            throw new IllegalArgumentException(message);
        }
    }
}
