#include <stdlib.h> 
#include <string.h>   
#include <stdio.h>
#include <conio.h>
#include <iostream>
#include "interface.h"
#include "project.h"
#include "basicstructures.h"
#include "linkedlist.h"
#include <windows.h>

void printColor(const char* text, int color)
{
	HANDLE hConsole;
	hConsole = GetStdHandle( STD_OUTPUT_HANDLE );
	SetConsoleTextAttribute( hConsole, color);
	printf("%s",text);
	SetConsoleTextAttribute( hConsole, 15);
}

void printHotKeys()
{
	HANDLE hCon = GetStdHandle(STD_OUTPUT_HANDLE);              
	COORD cPos; 
	cPos.Y = 23;                       
	cPos.X = 0;    
	SetConsoleCursorPosition(hCon, cPos);
	printColor("Enter", 11);
	printf(" - confirm, ");
	printColor("F1", 11);
	printf(" - help, ");
	printColor("Esc", 11);
	printf(" - main menu, ");
	printColor("Alt+F4", 11);
	printf(" - exit");
	cPos.Y = 0;                       
	cPos.X = 0;    
	SetConsoleCursorPosition(hCon, cPos);
}

void DisplayMenu(Menu menu)
{
	printHotKeys();
	switch (menu)
	{
	case MainMenuOn: 
		{
			printColor("Main menu \n\n", 10);
			printf("1. Create new project\n2. Open project\n");
			break;
		}
	case MenuAfter:
		{
			printColor("Main menu <- project menu \n\n", 10);
			break;
		}
	case MenuEdit:
		{
			printColor("Main menu <- project menu <- edit menu \n\n", 10);
			break;
		}
	case AddTaskMenu:
		{
			printColor("Main menu <- project menu <- add new task\n\n", 10);
			break;
		}
	case EditMenu:
		{
			printColor("Main menu <- project menu <- edit menu\n\n", 10);
			break;
		}
	case OpenProjectMenu:
		{
			printColor("Main menu <- open project\n", 10);
			break;
		}
	case CreateProjectMenu:
		{
			printColor("Main menu <- create new project\n", 10);
			break;
		}
	case HelpMenu:
		{
			printColor("Help menu\n\n", 10);
			printf("To confirm input, press enter. To close the program, press Alt + F4. Before closing the program save the project.");
			break;
		}
	}
}

void ClearBuff()
{
	std::cin.clear();
	std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}

void InputLong(const char *label, long *lp) 
{ 
	int k = 0;
	do
	{
		if (k != 0) 
			printColor("Error. Please re-enter.", 12);
		ClearBuff();
		printf(label); 
		k++;
	}
	while (scanf("%d", lp) != 1);
} 

void InputInt(const char *label, int *lp) 
{ 
	int k = 0;
	do
	{
		if (k != 0) 
			printColor("Error. Please re-enter. ", 12);
		ClearBuff();
		printf(label); 
		k++;
	}
	while (scanf("%d", lp) != 1);
} 

void InputChar(const char *label, char *cp) 
{ 
	ClearBuff();
	char buffer[128]; 
	printf(label); 
	gets(buffer); 
	strcpy(cp, buffer); 
} 

int months[13] = {0,31,28,31,30,31,30,31,31,30,31,30,31};

void InputDate(const char *label, tm *dp)  
{
	printf(label); 
	do
	{
		InputInt("Year: ", &dp->tm_year);
		if (dp->tm_year < 1990 || dp->tm_year > 2200)
			printf("Incorrect date. Please re-enter. ");
	}
	while (dp->tm_year < 1990 || dp->tm_year > 2200);
	do
	{
		InputInt("Month: ", &dp->tm_mon);
		if (dp->tm_mon < 1 || dp->tm_mon > 12)
			printf("Incorrect date. Please re-enter. ");
	}
	while (dp->tm_mon < 1 || dp->tm_mon > 12);
	do
	{
		InputInt("Day: ", &dp->tm_mday);
		if (dp->tm_mday < 1 || dp->tm_mday > months[dp->tm_mon])
			printf("Incorrect date. Please re-enter. ");
	}
	while (dp->tm_mday < 1 || dp->tm_mday > months[dp->tm_mon]);
}

int CompareDate(tm dp1, tm dp2) //если dp1 > dp2 = 1, dp1 == dp2 = 0, dp1 < dp2 = -1
{
	if (dp1.tm_year > dp2.tm_year)
		return 1;
	if (dp1.tm_year < dp2.tm_year)
		return -1;
	if ((dp1.tm_mon > dp2.tm_mon) && (dp1.tm_year == dp2.tm_year))
		return 1;
	if ((dp1.tm_mon < dp2.tm_mon) && (dp1.tm_year == dp2.tm_year))
		return -1;
	if ((dp1.tm_mday > dp2.tm_mday) && (dp1.tm_mon == dp2.tm_mon) && (dp1.tm_year == dp2.tm_year))
		return 1;
	if ((dp1.tm_mday < dp2.tm_mday) && (dp1.tm_mon == dp2.tm_mon) && (dp1.tm_year == dp2.tm_year))
		return -1;
	if ((dp1.tm_year == dp2.tm_year) && (dp1.tm_mon == dp2.tm_mon) && (dp1.tm_mday == dp2.tm_mday))
		return 0;
	return -1;
}

void printDate(tm date)
{
	printf("%d\.%d\.%d", date.tm_mday, date.tm_mon, date.tm_year);
}

bool IsDatesIntersect(tm start1, tm end1, tm start2, tm end2) 
{
	if ((CompareDate(start1, start2) == -1 &&  CompareDate(start2, end1)) == -1 || (CompareDate(start1, end2) == -1 &&  CompareDate(end2, end1) == -1))
		return true;
	else return false;
}


void InputDouble(const char *label, double *dp)    
{ 
	char buffer[128];  
	printf(label); 
	gets(buffer); 
	*dp = atof(buffer); 
}

void InputBool(const char *label, bool *bp)
{
	char yORn;
	do
	{
		printf("\n");
		printColor(label, 14);
		yORn = getche();
		printf("\n");
		switch (yORn)
		{
		case 'y':
			{
				*bp = true;
				return;
			}
		case 'n':
			{
				*bp = false;
				return;
			}
		default: break;
		}
	}
	while(1);
}

void printfBool(const char *label, bool bp)
{
	if (bp)
		printf("%s %s", label, "y");
	else
		printf("%s %s", label, "n");
}

Project* MainMenuOnStart()
{
	char action;
	Project* project = NULL;
start:
	system("cls");
	printColor("Menu\n", 11);
	DisplayMenu(MainMenuOn);
	ClearBuff();
	action = getch();
	switch (action)
	{
	case '1': 
		{				
			project = CreateProject();
			break;
		}
	case '2': 
		{
			project = OpenProject();
			break;
		}
	case 107: 
		{
			bool confirm;
			InputBool("Are you sure? (y/n)", &confirm);
			if (confirm)
				exit(1);
		}
	case 0:
		{
			if(getch() == 59)
				DisplayMenu(HelpMenu);
			getch();
			break;
		}
	}
	if (project == NULL) 
		goto start;
	return project;
}

void OpenedProjectMenu(Project* project)
{
	char action;
	do
	{
		system("cls");
		DisplayMenu(MenuAfter);
		printColor("Information about project:\n", 11);
		printf("The name of the project - ");
		printf(project->Name);
		printf("\n%s%d\n", "The amount of money - ", project->money);
		printf("%s%d", "The number of workers - ", project->NumberOfWorkers);
		printf("\nThe date of the beginning of the project - ");
		printDate(project->StartDate);
		printf("\nThe date of the end of the project - ");
		printDate(project->EndDate);
		printColor("\n\nMenu\n", 11);
		printf("1. Add new task\n2. Edit task\n3. Display a list of tasks\n4. Save project\n");
		action = _getch();
		switch (action)
		{
		case '1': 
			{
				if(project != NULL)
					AddTask(project);
				else 
				{
					printColor("\nError! Project is not opened", 12);
					getch();
				}
				break;
			}
		case '4':
			{
				if(project != NULL)
				{
					SaveProject(project);
					printColor("\n\nProject is saved.\n", 10);
					printf("Press any key to continue...");
				}
				else 
					printColor("\nError! Project is not opened.", 12);
				getch();
				break;
			}
		case '3': 
			{
				DisplayList(project->TasksHead);
				getch();
				break;
			}
		case 27:
			{
				MainMenuOnStart();
				break;
			}
		case 107: 
			{	
				bool confirm;
				InputBool("Are you sure? (y/n)", &confirm);
				if (confirm)
					return;
			}
		case '2':
			{
				EditTask(project);
				break;
			}
		case 0:
			{
				if(getch() == 59)
				{
					system("cls");
					DisplayMenu(HelpMenu);
				}
				getch();				
				break;
			}
		}
	}
	while(true);
}