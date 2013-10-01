#ifndef H_PROJECT
#define H_PROJECT

#include "basicstructures.h"

Project* CreateProject();
Project* OpenProject();
void AddTask(Project *project);
void SaveProject(Project *project);
void EditTask(Project *project);

#endif