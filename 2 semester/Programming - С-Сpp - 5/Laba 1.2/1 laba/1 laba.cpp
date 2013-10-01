// 1 laba.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <conio.h>

void ClearBuff() //"очищаем" буфер, чтобы можно было ввод вызвать несколько раз подряд
{
	std::cin.clear();
    	std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}

int main()
{
	setlocale(LC_ALL, "Russian"); //поддержка консолью русского текста
	//ввод исходных данных
	int n;
	do
	{
		printf("\nВведите натуральное число не менее 10: ");
		scanf_s("%d", &n);
		ClearBuff();
	}
	while (n < 10);
	//проверям числа на соответствие условию задачи, и выводим, в случае удачи
	printf("\nВозрастающая последовательность цифр: \n");
	for (int i=10; i<=n; i++) 
		if (isIncrease(i)) 
			printf("%d  ", i);
	printf("\n\nУбывающая последовательность цифр: \n");
	for (int i=10; i<=n; i++) 
		if (isDecrease(i)) 
			printf("%d ", i);
	printf("\n\nДля выхода из программы нажмите любую клавишу...");
	_getch();
	return 0;
}

bool isIncrease (int n)
{
	int units, tens;

	while (n > 0) 
	{
		units = n % 10;
		n /= 10;
		tens = n % 10;
		if (units <= tens) 
			return false;
	}
	return true;
}

bool isDecrease (int n)
{
	int units, tens;

	while (n > 10)  
	{
		units = n % 10; 
		n /= 10;
		tens = n % 10;
		if (units >= tens)
			return false;
	}
	return true;	
}
