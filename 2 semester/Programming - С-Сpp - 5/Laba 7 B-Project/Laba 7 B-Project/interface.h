#ifndef H_INTERFACE
#define H_INTERFACE
#include "basicstructures.h"

typedef enum Menu { MainMenuOn, MenuAfter, AddTaskMenu, EditMenu, ReportMenu, OpenProjectMenu, CreateProjectMenu, MenuEdit, HelpMenu };

void DisplayMenu(Menu menu);

Project* MainMenuOnStart();

void OpenedProjectMenu(Project* project);

void printColor(const char* text, int color);

void printHotKeys();

void InputLong(const char *label, long *lp);

void InputChar(const char *label, char *cp);

void InputDouble(const char *label, double *dp);

void InputBool(const char *label, bool *bp);

void printfBool(const char *label, bool bp);

void InputDate(const char *label, tm *dp);

int CompareDate(tm dp1, tm dp2);

void printDate(tm date);

bool IsDatesIntersect(tm start1, tm end1, tm start2, tm end2);

#endif