#include "iostream" 
#include <string.h> 
#include <conio.h> 
#include <stdio.h> 
#include <stdlib.h> 
#include "windows.h" 
#include "iomanip" 

using namespace std; 

struct stack
{ 
    char d; 
    stack *next; 
}; 

struct Node
{  
	char d;
    Node *p;
};

// 3aнeceние в стек 
void push (char d, stack**top) 
{ 
	stack*pv = new stack; 
	pv->d = d; 
	pv->next = *top; 
	*top = pv; 
} 

// 3aнeceние в очередь 
void add (char d, Node **pend) 
{ 
	Node*pv = new Node; 
	pv->d = d; 
	(*pend)->p = pv;
	*pend = pv;
} 

 
// Выборка из стека 
void pop (stack**top) 
{  
	stack *pv= *top; 
	*top=(*top)->next;
	delete pv; 
}

// Выборка из очереди 
void del (Node **pbeg) 
{  
	Node *pv = *pbeg;
	*pbeg = (*pbeg)->p;
	delete pv;
}


//MAIN
void main() 
{
    setlocale(0,"Russian");
    stack *top=NULL;
    Node *pbeg = NULL;
	Node *pend = pbeg;
    setlocale(0,"Russian");
FILE*fp=fopen("1.txt","r"); 
if (fp) 
{ 
while (!feof(fp)) 
{ 
    char g=fgetc(fp);
    if (isdigit(g)) {push(g, &top);}
        else cout<<pop(&top);
        if (isalpha(g)) {add(g, &pend);}
        else cout<<del(&pend);
while (pbeg) std::cout<<del(&pbeg); 
fclose(fp);
} 
_getch(); 
}