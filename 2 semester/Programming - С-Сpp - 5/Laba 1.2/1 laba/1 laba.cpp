// 1 laba.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
#include <conio.h>

void ClearBuff() //"�������" �����, ����� ����� ���� ���� ������� ��������� ��� ������
{
	std::cin.clear();
    	std::cin.seekg(std::cin.gcount()+1);
	std::cin.clear();
}

int main()
{
	setlocale(LC_ALL, "Russian"); //��������� �������� �������� ������
	//���� �������� ������
	int n;
	do
	{
		printf("\n������� ����������� ����� �� ����� 10: ");
		scanf_s("%d", &n);
		ClearBuff();
	}
	while (n < 10);
	//�������� ����� �� ������������ ������� ������, � �������, � ������ �����
	printf("\n������������ ������������������ ����: \n");
	for (int i=10; i<=n; i++) 
		if (isIncrease(i)) 
			printf("%d  ", i);
	printf("\n\n��������� ������������������ ����: \n");
	for (int i=10; i<=n; i++) 
		if (isDecrease(i)) 
			printf("%d ", i);
	printf("\n\n��� ������ �� ��������� ������� ����� �������...");
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
