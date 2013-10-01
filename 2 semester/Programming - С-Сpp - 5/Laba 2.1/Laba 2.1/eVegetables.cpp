#include <iostream>
#include "conio.h"

int orderVegetables ();
void cart(int PotatoesWeight, int CarrotsWeight, int BeetsWeight);
void totalPrice(int PotatoesWeight, int CarrotsWeight, int BeetsWeight);
void about();
const int PotatoesPrice = 500, CarrotsPrice = 1000, BeetsPrice = 700, DeliveryCost = 15000;

int main()
{
	int totalWeightPotatoes = 0, totalWeighCarrots = 0, totalWeighBeets = 0;
	setlocale(LC_ALL, "Russian"); //������� � ������� ������� �����
	
	beginning_of_the_program:
	printf("\n1.�������� ���������. \n 2. �������� ��������. \n 3. �������� ������.\n");
	printf("4. �������. \n 5. ������ ��������� ������. \n 6. ����. \n 7. ����� \n");
	char action;
	do
	{
		action = _getch();
		switch(action)
		{
			case '1': 
				{ 
					printf("\n������� ����������� ��������� �� ������� ��������?\n");
					totalWeightPotatoes += orderVegetables(); 
					break; 
				}
			case '2': 
				{ printf("\n������� ����������� �������� �� ������� ��������?\n");
				totalWeighCarrots += orderVegetables(); 
				break; }
			case '3': 
				{ printf("\n������� ����������� ������ �� ������� ��������?\n");
				totalWeighBeets += orderVegetables(); 
				break; }
			case '4': 
				{ cart(totalWeightPotatoes, totalWeighCarrots, totalWeighBeets);
				printf("%s", "\n*���� ��������� ��� ����� ������\n"); 
				break; }
			case '5': 
				{ totalPrice(totalWeightPotatoes, totalWeighCarrots, totalWeighBeets); 
				break; }
			case '6': 
				{ about();
				break; }
			case '7': return 0;
		}
	}
	while (true);
	return 0;
}

int orderVegetables ()
{
	int weight;
	printf("\n������� ����� ������� 0: ");
	scanf_s("%d", &weight);
	printf("\n� ������� ��������� %d ��\n", weight);
	return weight;
}

void cart(int PotatoesWeight, int CarrotsWeight, int BeetsWeight)
{
	printf("\n������ � �������:\n");
	printf("\t%d �� ���������, ���������� %d ������;\n", PotatoesWeight, PotatoesWeight*PotatoesPrice);
	printf("\t%d �� ��������, ���������� %d ������;\n", CarrotsWeight, CarrotsWeight*CarrotsPrice);
	printf("\t%d �� ������, ���������� %d ������.\n", BeetsWeight, BeetsWeight*BeetsPrice);
}

void totalPrice(int PotatoesWeight, int CarrotsWeight, int BeetsWeight)
{
	cart(PotatoesWeight, CarrotsWeight, BeetsWeight);
	int totalWeight = PotatoesWeight + CarrotsWeight + BeetsWeight;
	int totalPrice = PotatoesWeight*PotatoesPrice + CarrotsWeight*CarrotsPrice + BeetsWeight*BeetsPrice;
	if (totalWeight > 50) totalPrice *= 0.7;
	else 
		if (totalWeight > 25)  totalPrice *= 0.8;
		else
			if (totalWeight > 10)  totalPrice *= 0.9;	
	printf("\n����� ��������� ������ � ������ ������: %d ������.\n", totalPrice);
	printf("� ������ ��������� ��������: %d ������.\n", totalPrice+DeliveryCost);
}

void about()
{
	printf("\n���������� ����������. ����������� ������� ��������� �� ���� 500�. �� ��,\n");
	printf("������� � 1000 �. �� �� � ������ � 700�. �� ��. ��������� �������� ��\n");
	printf("������ ���������� 15 000�. eVegetables ������������� 10%%-��� ������\n");
	printf("�� ������ ����� ����� 10 ��, 20%%-��� � ����� 25 �� � 30%%-��� � ����� 50 ��.\n");
}