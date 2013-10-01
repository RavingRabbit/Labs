#include <windows.h>
#include <conio.h>
#include <iostream>
#define MAX_LINE_LENGTH 1000 //������������ ����� ������
#define MAX_WORD 40 //������������ ���������� ���� � ������
bool isDifferentLetters (char *p);
 
int main() 
{ 
	setlocale(LC_ALL, "");
	int i, max_word_length = 0; 
	char *p, separator[] = " ,.?!;:", Str[MAX_LINE_LENGTH], *LongestWord; 
	printf("������� �����. ���� ������ ��������� �������� Enter. \n"); 
	std::cin.getline(Str, MAX_LINE_LENGTH);
	Str[MAX_LINE_LENGTH - 1] = '\0';
	p = strtok(Str, separator); 
	while (p) 
	{ 
		if (isDifferentLetters(p))                        
			if (strlen(p) > max_word_length) 
			{
				max_word_length = strlen(p);
				LongestWord = p;
			}
		p = strtok(NULL, separator);
	}                             
	CharToOem(LongestWord,LongestWord);
	printf("����� ������� �����, � ������� ��� ����� ������ ");
	puts(LongestWord);
	_getch();
}

bool isDifferentLetters (char *Str)
{
	int StrLength = strlen(Str);
	for (int i=0; i<StrLength; i++)
		for (int j=i+1; j<(StrLength-1); j++)
			if (Str[i] == Str[j]) return false;
	return true;
}