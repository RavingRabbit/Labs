#ifndef H_DB
#define H_DB

#include "basicstructures.h"

/* ������� ���� ������� */
Project* OpenDB(const char *path);

/* �������� � ���� ������� */
void WriteDB(const char *path, Project* project);

#endif