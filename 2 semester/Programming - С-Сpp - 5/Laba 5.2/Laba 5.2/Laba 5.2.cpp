#include <iostream>
#include <conio.h>
#define MAX_LINE_LENGTH 100

/* ���������, ����������� ���� ������ */ 
typedef struct TREE { 
	char data; 
    struct TREE *left; 
    struct TREE *right; 
} TREE; 
 
void AddNode(char data, TREE **root); 
void LeftOrder(TREE *node);
void DestroyTree(TREE *root);
void StringIntoTree(char *Line, TREE **root);
int CountSheets(TREE *root);

void main(void) 
{ 
	setlocale(LC_ALL, "");
	TREE *root = NULL;
	char Line[MAX_LINE_LENGTH];
	do
	{
		std::cout << "������� �����. ���� ������ ��������� �������� Enter. \n";
		std::cin.getline(Line, MAX_LINE_LENGTH);
		StringIntoTree(Line, &root); 
		std::cout << "���������� ������:\n";
		LeftOrder(root);
		std::cout << "\n����� ������� � ������ ����� " << CountSheets(root) << std::endl;
		DestroyTree(root);
		root = NULL;
		std::cout << "����� �� ��������� (y/n)? \n";
	}
	while(_getch() != 'y');
	return;
} 

/* ������������� ������ � ������ ������ */
void StringIntoTree(char *Line, TREE **root)
{
	for(int i = 0; i < strlen(Line); ++i)
		AddNode(Line[i], root);
}

/* �������� ���� � �������� ������ ������ */ 
void AddNode(char data, TREE **root) 
{ 
    if (*root == NULL) 
	{ 
		*root = (TREE *)calloc(1, sizeof(TREE)); 
        (*root)->data = data; 
        (*root)->left = (*root)->right = NULL; 
    } 
	else  
        if (data < (*root)->data) 
            AddNode(data, &(*root)->left);
		else 
			if (data > (*root)->data) 
				AddNode(data, &(*root)->right); 
} 

/* ����� ������ ����� (����� �� �����������) */ 
void LeftOrder(TREE *node) 
{ 
    if (node->left) 
        LeftOrder(node->left); 
    std::cout << node->data << ' '; 
    if (node->right) 
        LeftOrder(node->right); 
}

/* ��������� ���������� ������� � ������ */
int N = 0;
int Count(TREE *root)
{
	if (root != NULL) 
    {
		if ((root->left == NULL) && (root->right == NULL))
			N++;
		Count(root->left);
		Count(root->right);
    }
	return N;
}

int CountSheets(TREE *root) 
{
	N = 0;
	return Count(root);
} 


/* ��������� ������ */
void DestroyTree(TREE *root)
{
	if (root != NULL) 
    {
		DestroyTree(root->left);
		DestroyTree(root->right);
		delete root;
		root = NULL;
    }
}