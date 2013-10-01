#include <iostream>
#include <conio.h>

int fib_iteratively (int n);
int fib_recur(int n);

int main()
{
	setlocale(LC_ALL, "");
    int n;
    std::cout << "Введите n: "; 
    std::cin >> n;
    std::cout << "\n";
	std::cout << "Итерационно: " << fib_iteratively(n);
	std::cout << "\nРекурсивно: " << fib_recur(n);
	_getch();
    return 0;
}


int fib_iteratively (int n)
{
	int tmp, f1=1, f2=1, amount=2;
	for (int i=2; i<n; i++)
	{
		tmp = f1;
		f1 = f2;
		f2 = f1 + tmp;
		amount += f2;
	}
	return amount;
}

int fib(int n)
{
	if (n<3) return 1;
	else
		return fib(n-1)+fib(n-2);
}
 
int fib_recur(int n)
{
	if (n<1) return 0;
	else
		return fib_recur(n-1) + fib(n);
}