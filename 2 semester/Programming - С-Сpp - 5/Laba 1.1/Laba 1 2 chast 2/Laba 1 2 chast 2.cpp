// Laba 1 2 chast 2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <conio.h>

void ClearBuff();
int countSquares (int a, int b);

int main()
{
	setlocale(LC_ALL, "Russian"); //поддержка консолью русского текста
	//ввод исходных данных
	int a;
	do
	{
		printf("\nВведите сторону прямоугольника a: ");
		scanf_s("%d", &a);
		ClearBuff();
	}
	while (a < 0);
	int b;
	do
	{
		printf ("\nВведите сторону прямоугольника b: ");
		scanf_s("%d", &b);
		ClearBuff();
	}
	while (b < 0);
	//решаем задачу
	printf ("\nКоличество квадратов = %d", countSquares (a,b) );
	printf ("\n\nДля выхода из программы нажмите любую клавишу...");
	_getch();
	return 0;
}

int countSquares (int a, int b)
{
	int sideLength;
	int number_Of_Squares=0;
	while ((a > 0) && (b > 0))
	{
		if (a > b) 
		{
			sideLength = b;
			a -= sideLength;
		}
		else 
		{
			sideLength = a;
			b -= sideLength;
		}
		number_Of_Squares++;
	}
	return number_Of_Squares;
}

void ClearBuff() //"очищаем" буфер, чтобы можно было ввод вызвать несколько раз подряд
{
	std::cin.clear();
    std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}

