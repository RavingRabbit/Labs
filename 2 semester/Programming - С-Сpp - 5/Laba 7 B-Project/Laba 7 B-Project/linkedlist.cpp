#include "linkedlist.h"
#include "interface.h"
#include <stdlib.h>
#include <string>
#include <windows.h>
#include <stdlib.h> 
#include <string.h>   
#include <stdio.h>
#include <conio.h>
#include <iostream>

void Insert(ListItem **head, ListItem **teil, Task *task)
{
	ListItem *p;
	p = (ListItem*)malloc(sizeof(ListItem));
	p->Task = task;
	p->next = p->prev = NULL;

	if (*head == NULL)
	{
		*head = *teil = p;
		return;
	}
	else
	{
		(*teil)->next = p;
		(*teil)->next->prev = *teil;
		*teil = (*teil)->next;
	}
}

void Delete(ListItem **head, ListItem **teil, Task *task)
{
	ListItem *p = *head;

	while (p != NULL && strcmp(p->Task->Name, task->Name) != 0)
		p = p->next;
	if (p == NULL)
		return;
	if (p == *head && p == *teil)
	{
		(*head)->next = (*teil)->prev = NULL;
		*teil = *head = NULL;

	}
	else 
		if (p == *head)
		{
			*head = (*head)->next;
			(*head)->prev = NULL;
		}
		else 
			if (p == *teil)
			{
				*teil = (*teil)->prev;
				(*teil)->next = NULL;
			} 
			else
			{
				p->prev->next = p->next;
				p->next->prev = p->prev;
			}
	free(p);
}

void DisplayList(ListItem *head)
{
	system("cls");
	printHotKeys();
	printColor("Main menu <- task list\n\n", 10);
	ListItem* tmp = head;
	HANDLE hCon = GetStdHandle(STD_OUTPUT_HANDLE);              
	COORD cPos; 
	cPos.Y = 2;                       
	cPos.X = 0;    
	SetConsoleCursorPosition(hCon, cPos);
	printf("Task name");
	cPos.X = 20;
	SetConsoleCursorPosition(hCon, cPos);
	printf("Money");
	cPos.X = 35;
	SetConsoleCursorPosition(hCon, cPos);
	printf("Workers");
	cPos.X = 50;
	SetConsoleCursorPosition(hCon, cPos);
	printf("Start date");
	cPos.X = 65;
	SetConsoleCursorPosition(hCon, cPos);
	printf("End date");
	cPos.Y = 4;
	while (tmp != NULL)
	{		
		cPos.X = 0;    
		SetConsoleCursorPosition(hCon, cPos);
		printf(tmp->Task->Name);
		cPos.X = 20;
		SetConsoleCursorPosition(hCon, cPos);
		printf("%d", tmp->Task->money);
		cPos.X = 35;
		SetConsoleCursorPosition(hCon, cPos);
		printf("%d", tmp->Task->NumberOfWorkers);
		cPos.X = 50;
		SetConsoleCursorPosition(hCon, cPos);
		printDate(tmp->Task->StartDate);
		cPos.X = 65;
		SetConsoleCursorPosition(hCon, cPos);
		printDate(tmp->Task->EndDate);
		cPos.Y++;
		tmp = tmp->next;
	}
}