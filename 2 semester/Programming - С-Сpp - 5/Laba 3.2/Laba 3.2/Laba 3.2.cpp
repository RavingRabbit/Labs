#include <iostream>
#include <conio.h>
void clearBuff();
void printChessBoard (int **arr);

int** createArray(int n);
void destroyArray (int **arr);
bool isUnderThreat(int **arr, int i, int j);
const int n = 10;

int main()
{
	setlocale(LC_ALL, "");
	//�������� ������������� ���������� ������� 8*8
	int **arr = createArray(n);
	//�������� ������ ������
	int i;
	for (i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			arr[i][j] = 0;
	i = 0;
	int j;
	do
	{
		printf("������� ��������� ������ (��������: \"1 1\", ������ ������ ����� � A1): ");
		clearBuff();
	}
	while ((!scanf_s("%d %d", &j, &i)) | (i<1) | (j<1) | (j>8) | (i>8));
	arr[1][1] = 2;	arr[5][6] = 2;	arr[8][8] = 2; //���������� ������
	arr[i][j] = 1; //��������� ������
	printChessBoard (arr);
	if (isUnderThreat(arr,i,j)) 
		printf("������ ��� �������!");
	else
		printf("������ � ������������.");
	destroyArray(arr);
	_getch();
	return 0;
}

int** createArray(int n)
{
	int ** arr = new int * [n];
	for(int i = 0; i < n; i++)
		arr[i] = new int [n];
	return (arr);
}

void destroyArray (int ** arr)
{
	for (int i = 0; i < n; i++)
		delete []arr[i];
	delete []arr;
	arr = NULL;
}

void printChessBoard (int **arr)
{
	for (int a = (n-1); a > 0; a--)
	{
		for (int b = 1; b < n; b++)
			printf("%d ",arr[a][b]);
		printf("\n");
	}
}

bool isUnderThreat(int **arr,int i0,int j0)
{
	int i,j;
	for (i = i0, j = j0; ((i<n) && (j<=n)); i++, j++)
		if (arr[i][j] == 2) return true; 
	for (i = i0, j = j0; ((i>0) && (j>0)); i--, j--)
		if (arr[i][j] == 2) return true; 
	for (i= i0, j = j0; ((i<n) && (j>0)); i++, j--)
		if (arr[i][j] == 2) return true; 
	for (i= i0, j = j0; ((i>0) && (j<=n)); i--, j++)
		if (arr[i][j] == 2) return true; 
	for (i= i0, j = j0; i<n; i++)
		if (arr[i][j] == 2) return true; 
	for (i= i0, j = j0; i>0; i--)
		if (arr[i][j] == 2) return true; 
	for (i= i0, j = j0; j<n; j++)
		if (arr[i][j] == 2) return true; 
	for (i = i0, j = j0; j>0; j--)
		if (arr[i][j] == 2) return true; 
	return false;
}

void clearBuff()
{
	std::cin.clear();
    std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}