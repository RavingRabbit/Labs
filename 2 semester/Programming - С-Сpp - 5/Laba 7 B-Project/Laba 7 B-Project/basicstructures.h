#ifndef H_BASIC
#define H_BASIC
#include <time.h>
#define NAMELEN 200  

typedef struct task { 
	char Name[NAMELEN];		/* название задачи */ 
	tm StartDate;			/* дата начала */
	tm EndDate;				/* дата окончания */ 
	long NumberOfWorkers;	/* количество рабочих */
	long money;				/* выделенные ресурсы */ 
} Task; 

typedef struct listItem {
	struct task *Task;		/* задача */
	struct listItem *next;
	struct listItem *prev;
} ListItem;

typedef struct project { 
	char Name[NAMELEN];			/* название проекта */ 
	long NumberOfWorkers;		/* количество рабочих */
	long money;					/* выделенные ресурсы */	
	struct tm StartDate;		/* дата начала */
	struct tm EndDate;			/* дата окончания */ 
	struct listItem* TasksHead;	/* указатель на head списка из task'ов */
	struct listItem* TasksTail;	/* указатель на tail списка из task'ов */
} Project; 

#endif