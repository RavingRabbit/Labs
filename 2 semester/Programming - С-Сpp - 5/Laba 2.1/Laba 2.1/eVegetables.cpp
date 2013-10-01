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
	setlocale(LC_ALL, "Russian"); //выводим в консоль русский текст
	
	beginning_of_the_program:
	printf("\n1.Заказать картофель. \n 2. Заказать марковку. \n 3. Заказать свеклу.\n");
	printf("4. Корзина. \n 5. Расчет стоимости заказа. \n 6. Инфо. \n 7. Выход \n");
	char action;
	do
	{
		action = _getch();
		switch(action)
		{
			case '1': 
				{ 
					printf("\nСколько килограммов картофеля вы желаете заказать?\n");
					totalWeightPotatoes += orderVegetables(); 
					break; 
				}
			case '2': 
				{ printf("\nСколько килограммов марковки вы желаете заказать?\n");
				totalWeighCarrots += orderVegetables(); 
				break; }
			case '3': 
				{ printf("\nСколько килограммов свеклы вы желаете заказать?\n");
				totalWeighBeets += orderVegetables(); 
				break; }
			case '4': 
				{ cart(totalWeightPotatoes, totalWeighCarrots, totalWeighBeets);
				printf("%s", "\n*цены приведены без учёта скидки\n"); 
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
	printf("\nВведите число большее 0: ");
	scanf_s("%d", &weight);
	printf("\nВ корзину добавлено %d кг\n", weight);
	return weight;
}

void cart(int PotatoesWeight, int CarrotsWeight, int BeetsWeight)
{
	printf("\nСейчас в корзине:\n");
	printf("\t%d кг картофеля, стоимостью %d рублей;\n", PotatoesWeight, PotatoesWeight*PotatoesPrice);
	printf("\t%d кг марковки, стоимостью %d рублей;\n", CarrotsWeight, CarrotsWeight*CarrotsPrice);
	printf("\t%d кг свеклы, стоимостью %d рублей.\n", BeetsWeight, BeetsWeight*BeetsPrice);
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
	printf("\nОбщая стоимость заказа с учётом скидки: %d рублей.\n", totalPrice);
	printf("С учётом стоимости доставки: %d рублей.\n", totalPrice+DeliveryCost);
}

void about()
{
	printf("\nСправочная информация. Предприятие продает картофель по цене 500р. за кг,\n");
	printf("морковь – 1000 р. за кг и свеклу – 700р. за кг. Стоимость доставки по\n");
	printf("городу составляет 15 000р. eVegetables предоставляет 10%%-ную скидку\n");
	printf("на заказы весом более 10 кг, 20%%-ную – более 25 кг и 30%%-ную – более 50 кг.\n");
}