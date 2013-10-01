#include <stdlib.h>
#include <stdio.h>
#include <string>
#include <conio.h>
#include "interface.h"
#include "basicstructures.h"
#include "linkedlist.h"
#include "db.h"
#include <Windows.h>
#define MAX_PATH 512
using namespace std;

int FreeWorkers;	/* количество свободных рабочих */
int FreeResources;	/* количество свободных ресурсов */

bool is_dots(const char* dir){
	if (strcmp(dir, ".")==0) return true;
	if (strcmp(dir, "..")==0) return true;
	return false;
}

void scan_directory(const char* dir, const char* mask){
	char filemask[MAX_PATH];
	sprintf(filemask, "%s\\%s", dir, mask);

	WIN32_FIND_DATA wf;
	HANDLE hf = FindFirstFile(filemask, &wf);
	if (hf != INVALID_HANDLE_VALUE){
		do{
			if (!is_dots(wf.cFileName)){
				if (wf.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY){
					char buf[MAX_PATH];     
					sprintf(buf, "%s\\%s", dir, wf.cFileName);
					scan_directory(buf, mask);      
				}
				else 
					printf("%s\n", wf.cFileName);
			}
		}while (FindNextFile(hf, &wf));
		FindClose(hf);
	}
}

void Calc(Project* project)
{
	ListItem* tmp = project->TasksHead;
	while (tmp != NULL)
	{
		FreeWorkers -= tmp->Task->NumberOfWorkers;
		FreeResources -= tmp->Task->money;
		tmp = tmp->next;
	}
}

Project* CreateProject()
{
	system("cls");
	DisplayMenu(CreateProjectMenu);
	Project* project = (Project*)malloc(sizeof(Project));
	InputChar("\nThe name of the project: ", project->Name);
	InputLong("The amount of money: ", &project->money);
	InputLong("The number of workers: ", &project->NumberOfWorkers);
	bool isCorrect;
	do
	{
		isCorrect = true;
		InputDate("\nThe date of the beginning of the project:\n", &project->StartDate);
		InputDate("\nThe date of the end of the project:\n", &project->EndDate);
		if (!CompareDate(project->StartDate, project->EndDate))
		{
			isCorrect = false;
			printColor("Error! The date of the beginning > The date of the end. Please re-enter dates.", 12);
		}
	}
	while (!isCorrect);
	project->TasksHead = project->TasksTail = NULL;
	FreeWorkers = project->NumberOfWorkers;
	FreeResources = project->money;
	return project;
}

Project* OpenProject()
{
	Project* project;
	do
	{
		system("cls");
		DisplayMenu(OpenProjectMenu);
		printColor("\nThe list of projects:\n", 11);
		WIN32_FIND_DATA wf;
		scan_directory("projects", "*");

		char path[200];
		InputChar("\nEnter the name of the project: ", path);
		project = OpenDB(path);
		if(project != NULL)
		{
			FreeWorkers = project->NumberOfWorkers;
			FreeResources = project->money;
			Calc(project);			
			ListItem *tmp = project->TasksHead;
		}
		if (project == NULL)
		{
			printColor("\nError! Project is not opened, it does not exist.\n", 12);
			printf("Press any key to continue...");
			if (getch() == 27) MainMenuOnStart();
		}
	}
	while (project == NULL);
	return project;
}

task *FindIntersectTask(Project *project, tm start, tm end)
{
	ListItem *head = project->TasksHead;
	while (head != NULL)
	{
		if (IsDatesIntersect(start, end, head->Task->StartDate, head->Task->EndDate))
			return head->Task;
		head = head->next;
	}
	return NULL;
}

void AddTask(Project *project)
{
	system("cls");
	DisplayMenu(AddTaskMenu);
	printf("%s%d\n", "Free money - ", FreeResources);
	printf("%s%d\n", "Free workers - ", FreeWorkers);
	printf("The date of the beginning of the project - %d\.%d\.%d", project->StartDate.tm_mday, project->StartDate.tm_mon, project->StartDate.tm_year);
	printf("\nThe date of the end of the project - %d\.%d\.%d\n\n", project->EndDate.tm_mday, project->EndDate.tm_mon, project->EndDate.tm_year);
	Task *task = (Task*)malloc(sizeof(Task));

	InputChar("Name of the task: ", task->Name);
	bool isCorrect;
	do
	{
		isCorrect = true;
		InputLong("Amount of money: ", &task->money);
		if (task->money > FreeResources)
		{
			isCorrect = false;
			printColor("\nError! Not enough free money. Re-enter amount of money\n", 12);
		}
	}
	while(!isCorrect);
	do
	{
		isCorrect = true;
		InputLong("Number of workers: ", &task->NumberOfWorkers);
		if (task->NumberOfWorkers > FreeWorkers)
		{
			isCorrect = false;
			printColor("\nError! Not enough free workers. Re-enter number of workers\n", 12);
		}
	}
	while(!isCorrect);

	do
	{
		isCorrect = true;
		InputDate("\nThe date of the beginning of the task:\n", &task->StartDate);
		InputDate("\nThe date of the end of the task:\n", &task->EndDate);
		if (CompareDate(task->EndDate, task->StartDate) == -1 || CompareDate(task->StartDate, project->StartDate) == -1 || CompareDate(project->EndDate, task->EndDate) == -1)
		{
			isCorrect = false;
			printColor("Error! Incorrect dates. Please re-enter.", 12);
		}
	}
	while (!isCorrect);
	Task *intersectTask = FindIntersectTask(project, task->StartDate, task->EndDate);
	if (intersectTask == NULL)
	{
		FreeWorkers -= task->NumberOfWorkers;
		FreeResources -= task->money;
		Insert(&project->TasksHead, &project->TasksTail, task);
	}
	else 
	{
		string str = "\nCan the task be carried out simultaneously with the";
		str = str + " " + intersectTask->Name + "? (y/n)";
		InputBool(str.c_str(), &isCorrect);
		if (isCorrect)
		{
			FreeWorkers -= task->NumberOfWorkers;
			FreeResources -= task->money;
			Insert(&project->TasksHead, &project->TasksTail, task);
		}
		else AddTask(project);
	}
}

void EditTask(Project *project)
{
	system("cls");
	DisplayMenu(MenuEdit);
	printColor("List of tasks:\n", 11);
	ListItem *tmp = project->TasksHead;
	while (tmp != NULL)
	{
		printf(tmp->Task->Name);
		printf("\n");
		tmp = tmp->next;
	}
	Task *task = (Task*)malloc(sizeof(Task));
	InputChar("\nEnter the name of task: ", task->Name);
	tmp = project->TasksHead;
	while (tmp != NULL && strcmp(tmp->Task->Name, task->Name) != 0)
	{
		tmp = tmp->next;
	}
	if (tmp != NULL)
		task = tmp->Task;
	else 
	{
		printColor("\nError! Task not found.", 12);
		getch();
		return;
	}
	printColor("\nInformation about project:\n", 11);
	printf("Task name: ");
	printf(task->Name);
	printf("\nMoney - %d", task->money);
	printf("\nWorkers - %d", task->NumberOfWorkers);
	printf("\nStart date - ");
	printDate(task->StartDate);
	printf("\nEnd date - ");
	printDate(task->EndDate);
	InputChar("\n\nNew name of the task: ", task->Name);
	bool isCorrect;
	do
	{
		isCorrect = true;
		InputLong("Amount of money: ", &task->money);
		if (task->money > FreeResources)
		{
			isCorrect = false;
			printColor("\nError! Not enough free money. Re-enter amount of money\n", 12);
		}
	}
	while(!isCorrect);
	do
	{
		isCorrect = true;
		InputLong("Number of workers: ", &task->NumberOfWorkers);
		if (task->NumberOfWorkers > FreeWorkers)
		{
			isCorrect = false;
			printColor("\nError! Not enough free workers. Re-enter number of workers\n", 12);
		}
	}
	while(!isCorrect);

	do
	{
		isCorrect = true;
		InputDate("\nThe date of the beginning of the task:\n", &task->StartDate);
		InputDate("\nThe date of the end of the task:\n", &task->EndDate);
		if (CompareDate(task->EndDate, task->StartDate) == -1 || CompareDate(task->StartDate, project->StartDate) == -1 || CompareDate(project->EndDate, task->EndDate) == -1)
		{
			isCorrect = false;
			printColor("Error! Incorrect dates. Please re-enter.", 12);
		}
	}
	while (!isCorrect);
	Task *intersectTask = FindIntersectTask(project, task->StartDate, task->EndDate);
	if (intersectTask == NULL)
	{
		FreeWorkers -= task->NumberOfWorkers;
		FreeResources -= task->money;
		Insert(&project->TasksHead, &project->TasksTail, task);
	}
	else 
	{
		string str = "\nCan the task be carried out simultaneously with the";
		str = str + " " + intersectTask->Name + "? (y/n)";
		InputBool(str.c_str(), &isCorrect);
		if (isCorrect)
		{
			FreeWorkers -= task->NumberOfWorkers;
			FreeResources -= task->money;
			Insert(&project->TasksHead, &project->TasksTail, task);
		}
	}
}

void SaveProject(Project *project)
{
	WriteDB(project->Name, project);
}