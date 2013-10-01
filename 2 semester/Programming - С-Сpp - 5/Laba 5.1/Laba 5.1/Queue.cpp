#include <iostream>
#include <conio.h>

struct queue
{ 
	int val; 
	queue *next;
	queue *prev;
}; 

queue *newQ()
{
	queue *t; 
	t = new queue;
	t->next = NULL;
	t->prev = NULL;
	return t; 
}

void addQ(int val, queue **begOfQ, queue **endOfQ) //добавляем в конец очереди
{
	queue *tmp = newQ();
	tmp->val = val;
	if (*begOfQ == NULL)
	{
		*endOfQ = tmp;
		*begOfQ = tmp;
	}
	else
	{
		(*endOfQ)->prev = tmp;
		tmp->next = *endOfQ;
		*endOfQ = tmp;
	}
}

int readQ(queue *begOfQ, queue *endOfQ) //читаем из начала очереди и удаляем элемент из очереди
{
	queue *tmp;
	int val;
	if (begOfQ == NULL) 
	{
		//очередь пуста :(
		return 0;
	}
	else
	{
		//очередь не пуста :)
		if (endOfQ != begOfQ)
		{
			tmp = begOfQ;
			val = tmp->val;
			tmp->prev->next = NULL;
			begOfQ = tmp->prev;
			delete tmp;
			return val;
		}
		else
		{
			tmp = endOfQ;
			val = endOfQ->val;
			begOfQ = NULL;
			endOfQ = NULL;
			return val;
		}
	}
}

void printQ(queue *begOfQ) 
{
	if (begOfQ != NULL)
	{
		std::cout << begOfQ->val << ' ';
		queue *tmp = begOfQ;
		while (tmp->prev != NULL)
		{
			std::cout << tmp->prev->val << ' ';
			tmp = tmp->prev;
		}
	}
}


stack *newS()
{
	stack *t; 
	t = new stack;
	t->next = NULL;
	t->begOfQ = NULL;
	t->endOfQ = NULL;
	return t; 
}

void addS(stack **p, queue *begOfQ, queue *endOfQ)
{
	if (*p == NULL) 
	{
		*p = newS();
		(*p)->begOfQ = begOfQ;
		(*p)->endOfQ = endOfQ;
		(*p)->next = NULL;
	}
	else
	{
		stack *tmp = newS();
		tmp->begOfQ = begOfQ;
		tmp->endOfQ = endOfQ;
		tmp->next = *p;
		*p = tmp;
	}
}

queue* readS(stack **p)
{
	queue *q = (*p)->begOfQ;
	stack *tmp = *p;
	*p = (*p)->next;
	delete tmp;
	return q;