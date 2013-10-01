#include <iostream>
#include <conio.h>

struct queueElement
{ 
	int val; 
	queueElement *next;
}; 

struct queue
{
	queueElement *head, *teil;
};

struct stackOfQueue 
{ 
	queue *queue;
	stackOfQueue *prev; 
};

struct stackOfInt
{ 
	int val;
	stackOfInt *prev; 
};

queueElement *newQ()
{
	queueElement *t; 
	t = new queueElement;
	t->next = NULL;
	return t; 
}

void addQ(int val, queue **Q) //добавляем в конец очереди
{
	queueElement *tmp = newQ();
	tmp->val = val;
	if ((*Q)->head == NULL)
	{
		(*Q)->head = tmp;
		(*Q)->teil = tmp;
	}
	else
	{
		(*Q)->teil->next = tmp;
		tmp->next = NULL;
		(*Q)->teil = tmp;
	}
}

int readQ(queue *Q) //читаем из начала очереди и удаляем элемент из очереди
{
	queueElement *tmp;
	int val;
	if (Q->head == NULL) 
	{
		//очередь пуста :(
		return 0;
	}
	else
	{
		//очередь не пуста :)
		if (Q->head != Q->teil)
		{
			tmp = Q->head;
			val = tmp->val;
			Q->head = Q->head->next;
			delete tmp;
			return val;
		}
		else
		{
			val = Q->head->val;
			Q->head = NULL;
			Q->teil = NULL;
			return val;
		}
	}
}

void printQ(queue *Q) 
{
	if (Q->head != NULL)
	{
		std::cout << Q->head->val << ' ';
		queueElement *tmp = Q->head;
		while (tmp->next != NULL)
		{
			std::cout << tmp->next->val << ' ';
			tmp = tmp->next;
		}
	}
}

stackOfQueue *newStackOfQueue()
{
	stackOfQueue *t = new stackOfQueue; 
	t->prev = NULL;
	t->queue = new queue;
	t->queue->head = NULL;
	t->queue->teil = NULL;
	return t; 
}

stackOfInt *newStackOfInt()
{
	stackOfInt *t = new stackOfInt; 
	t->prev = NULL;
	return t; 
}

void pushQueue(stackOfQueue **p, queue *Q)
{
	if (*p == NULL) 
	{
		*p = newStackOfQueue();
		(*p)->queue = Q;
	}
	else
	{
		stackOfQueue *tmp = newStackOfQueue();
		tmp->queue = Q;
		tmp->prev = *p;
		*p = tmp;
	}
}

void pushInt(stackOfInt **p, int val)
{
	if (*p == NULL) 
	{
		*p = newStackOfInt();
		(*p)->val = val;
	}
	else
	{
		stackOfInt *tmp = newStackOfInt();
		tmp->val = val;
		tmp->prev = *p;
		*p = tmp;
	}
}

queue* pop(stackOfQueue **p)
{
	if (*p != NULL)
	{
		queue *q = (*p)->queue;
		stackOfQueue *tmp = *p;
		*p = (*p)->prev;
		delete tmp;
		return q;
	}
	else 
		return NULL;
}

struct entry
{
	queueElement *head;
	int summ;
	int max;
};

void analyze(stackOfQueue *p, entry *arr, int numOfQ)
{
	for(int i = 0; i < numOfQ; ++i)
	{
		arr[i].max = 0;
		arr[i].summ = 0;
	}
	stackOfQueue *t = p;
	for (int i = 0; t != NULL; t = t->prev, ++i)
	{
		arr[i].head = t->queue->head;
		if (arr[i].head != NULL)
		{
			queueElement *tmpQ = arr[i].head;
			int tmp;
			while (tmpQ != NULL)
			{
				tmp = tmpQ->val;
				if (tmp > arr[i].max) 
					arr[i].max = tmp;
				arr[i].summ += tmp;
				tmpQ = tmpQ->next;
			}
		}
	}
}

void findMaxItem(entry *arr, int numOfQ)
{
	int maxItem = 0;
	queueElement *maxQueue;
	for(int i = 0; i < numOfQ; ++i)
	{
		if (maxItem < arr[i].max)
		{
			maxItem = arr[i].max;
			maxQueue = arr[i].head;
		}
	}
	queue *tmp = new queue;
	tmp->head = maxQueue;
	printQ(tmp);
	std::cout << "Максимальный элемент: " << maxItem;
}

void findMaxSumm(entry *arr, int numOfQ)
{
	int maxSum = 0;
	queueElement *maxQueue;
	for(int i = 0; i < numOfQ; ++i)
	{
		if (maxSum < arr[i].summ)
		{
			maxSum = arr[i].summ;
			maxQueue = arr[i].head;
		}
	}
	queue *tmp = new queue;
	tmp->head = maxQueue;
	printQ(tmp);
	std::cout << "Сумма: " << maxSum;
}

stackOfInt* merge(stackOfQueue **p)
{
	stackOfInt *newStackOfInt = NULL;
	queue *tmpQ = pop(p);
	while(tmpQ != NULL)
	{
		while (tmpQ->head != NULL)
		{
			pushInt(&newStackOfInt, tmpQ->head->val);
			tmpQ->head = tmpQ->head->next;
		}
		tmpQ = pop(p);
	}
	return newStackOfInt;
}

void destroyQueue(queue* Q)
{
	queueElement* tmp;
	if (Q != NULL)
	{
		while (Q->head != NULL)
		{
			tmp = Q->head->next;
			free(Q->head);
			Q->head = tmp;
		}
	}
}

void destroyStackOfQ(stackOfQueue* stack)
{
	if (stack != NULL)
		while (stack)
		{
			queue* Q = pop(&stack);
			destroyQueue(Q);
		}
}

int main()
{
	setlocale(LC_ALL, "");
	std::cout << "Введите количество очередей: "; 
	int numOfQ;
	std::cin >> numOfQ;
	std::cout << std::endl << "Введите количество элементов в очереди: "; 
	int numOfItems;
	std::cin >> numOfItems;
	stackOfQueue *p = NULL; //пустой стэк
	//создём и заполняем очереди
	for (int i = 0; i < numOfQ; ++i)
	{
		queue *Q = new queue;
		Q->head = NULL;
		Q->teil = NULL;
		for (int j = 0; j < numOfItems; ++j)
			addQ(rand()%12, &Q);
		pushQueue(&p, Q);
	}
	std::cout << std::endl;
	stackOfQueue *t = p;
	int i = 1;
	while (t != NULL)
	{
		std::cout << i << ". ";
		printQ(t->queue);
		t = t->prev;
		i++;
		std::cout << std::endl;
	}
	std::cout << std::endl << std::endl;
	entry *arr = new entry [numOfQ];
	analyze(p, arr, numOfQ);
	findMaxItem(arr, numOfQ);
	std::cout << std::endl << std::endl;
	findMaxSumm(arr, numOfQ);
	std::cout << std::endl << std::endl;
	t = p;
	i = 1;
	while (t != NULL)
	{
		std::cout << i << ". ";
		printQ(t->queue);
		t = t->prev;
		i++;
		std::cout << std::endl;
	}
	stackOfInt* newStack = merge(&p);
	stackOfInt* tmpStack = newStack;
	std::cout << std::endl;
	while (tmpStack)
	{
		std::cout << tmpStack->val << ' ';
		tmpStack = tmpStack->prev;
	}
	destroyStackOfQ(p);
	system("pause");
	return 0;
}