#ifndef H_BASIC
#define H_BASIC
#include <time.h>
#define NAMELEN 200  

typedef struct task { 
	char Name[NAMELEN];		/* �������� ������ */ 
	tm StartDate;			/* ���� ������ */
	tm EndDate;				/* ���� ��������� */ 
	long NumberOfWorkers;	/* ���������� ������� */
	long money;				/* ���������� ������� */ 
} Task; 

typedef struct listItem {
	struct task *Task;		/* ������ */
	struct listItem *next;
	struct listItem *prev;
} ListItem;

typedef struct project { 
	char Name[NAMELEN];			/* �������� ������� */ 
	long NumberOfWorkers;		/* ���������� ������� */
	long money;					/* ���������� ������� */	
	struct tm StartDate;		/* ���� ������ */
	struct tm EndDate;			/* ���� ��������� */ 
	struct listItem* TasksHead;	/* ��������� �� head ������ �� task'�� */
	struct listItem* TasksTail;	/* ��������� �� tail ������ �� task'�� */
} Project; 

#endif