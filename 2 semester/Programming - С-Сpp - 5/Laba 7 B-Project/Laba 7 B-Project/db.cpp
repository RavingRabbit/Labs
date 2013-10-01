#include "basicstructures.h"
#include "linkedlist.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

Project* OpenDB(const char *path)
{
	FILE *fp;
	char* fullPath = new char[200];
	strcat(strcpy(fullPath, "projects/"), path);
	fp = fopen(fullPath, "rb");
	if (!fp)
		return NULL;
	Project* project = (Project*)malloc(sizeof(Project));
	strcpy(project->Name, path);
	fread(project, sizeof(Project), 1, fp);
	project->TasksHead = project->TasksTail = NULL;
	Task *task;
	while (!feof(fp))
	{
		task = (Task*)malloc(sizeof(Task));
		fread(task, sizeof(Task), 1, fp);
		Insert(&project->TasksHead, &project->TasksTail, task);
	}
	Delete(&project->TasksHead, &project->TasksTail, task);
	fclose(fp);
	return project;
}

void WriteDB(const char *path, Project* project)
{
	FILE *fp;
		
	char* fullPath = new char[200];
	strcat(strcpy(fullPath, "projects/"), path);
	fp = fopen(fullPath, "wb");
	if (!fp)
		return;
	fwrite(project, sizeof(Project), 1, fp);
	ListItem *p = project->TasksHead;
	while (p != NULL)
	{
		fwrite(p->Task, sizeof(Task), 1, fp);
		p = p->next;
	}
	fclose(fp);
}
