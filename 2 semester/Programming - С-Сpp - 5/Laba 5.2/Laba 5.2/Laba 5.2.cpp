#include <iostream>
#include <conio.h>
#define MAX_LINE_LENGTH 100

/* Структура, описывающая узел дерева */ 
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
		std::cout << "Введите текст. Ввод текста завершите нажатием Enter. \n";
		std::cin.getline(Line, MAX_LINE_LENGTH);
		StringIntoTree(Line, &root); 
		std::cout << "Полученное дерево:\n";
		LeftOrder(root);
		std::cout << "\nЧисло листьев в дереве равно " << CountSheets(root) << std::endl;
		DestroyTree(root);
		root = NULL;
		std::cout << "Выйти из программы (y/n)? \n";
	}
	while(_getch() != 'y');
	return;
} 

/* Преобразовать строку в дерево поиска */
void StringIntoTree(char *Line, TREE **root)
{
	for(int i = 0; i < strlen(Line); ++i)
		AddNode(Line[i], root);
}

/* Добавить узел в бинарное дерево поиска */ 
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

/* Обход дерева слева (вывод по возрастанию) */ 
void LeftOrder(TREE *node) 
{ 
    if (node->left) 
        LeftOrder(node->left); 
    std::cout << node->data << ' '; 
    if (node->right) 
        LeftOrder(node->right); 
}

/* Посчитать количество листьев в дереве */
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


/* Разрушить дерево */
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