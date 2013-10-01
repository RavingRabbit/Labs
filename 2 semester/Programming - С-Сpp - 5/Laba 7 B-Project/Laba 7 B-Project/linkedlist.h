#ifndef H_LIST
#define H_LIST

#include "basicstructures.h"

void Insert(ListItem **head, ListItem **teil, Task *task);
void Delete(ListItem **head, ListItem **teil, Task *task);
void DisplayList(ListItem *head);

#endif