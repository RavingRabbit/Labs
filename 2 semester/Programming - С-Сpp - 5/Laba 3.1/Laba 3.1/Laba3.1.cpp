#include <iostream>
#include <conio.h>
void clearBuff();
int* kolokol(int *arr, int n);

int main()
{
	setlocale(LC_ALL,"");
	//ввод данных
	int n;
	do
	{
		clearBuff();
		printf("Введите размер массива n (натуральное число) ");	
	}
	while ((!scanf_s("%d", &n)) | (n<=0));
	//создание массива со случайными значениями
	int *arr = (int*) malloc(n*sizeof(int));
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand()%121; 
		printf("%d ", arr[i]);
	}	
	//перестановка значений в массиве — "колокол"
	arr = kolokol(arr,n);
	//вывод результата
	printf("\n\n");
	for (int i = 0; i < n; i++)
		printf("%d ", arr[i]);
	_getch();
	//освобождаем память
	free(arr);
	return 0;
}

void sort(int *arr, int n)
{
	for (int i = 0; i < n; i++)
		for (int j = 0; j < (n-1); j++)
			if (arr[j] > arr[j+1]) 
			{
				int tmp = arr[j+1]; 
				arr[j+1] = arr[j]; 
				arr[j] = tmp;
			}
}

int* kolokol(int *arr, int n)
{
	sort(arr,n);
	int *arrtmp = (int*) malloc(n*sizeof(int));
	for (int i = 0; i < n; i += 2)
		{
			arrtmp[i/2] = arr[i];
			arrtmp[n-1-i/2] = arr[i+1];
		}
	if (n%2) arrtmp[n/2] = arr[n-1];
	free(arr);
	return arrtmp;
}

void clearBuff()
{
	std::cin.clear();
    std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}