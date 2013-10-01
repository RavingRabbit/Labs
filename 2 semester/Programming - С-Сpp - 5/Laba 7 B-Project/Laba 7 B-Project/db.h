#ifndef H_DB
#define H_DB

#include "basicstructures.h"

/* Открыть файл проекта */
Project* OpenDB(const char *path);

/* Записать в файл проекта */
void WriteDB(const char *path, Project* project);

#endif