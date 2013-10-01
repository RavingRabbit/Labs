#include <conio.h>
#include <iostream>
#define MAX_LINE_LENGTH 1000	/* количество символов в строке */ 
#define MAX_WORD_FILE 5000 /* максимальное количество слов в файле */

struct words
{
	char *word;
	unsigned int count;
};

void readFileToArr(FILE *fl, words *arr);
void addWordToArr(words *arr, char *word);
void sort(words *arr);
int wordCount = 0;

int main(int argc, char *argv[]) 
{   
	setlocale(LC_ALL, "");
	FILE *fl = fopen("text.txt", "r"); 
	if (!fl)	/* file not found → exit */
		return 0;	 
	words *dictionary = new words[5000];	/* create array */
	readFileToArr(fl, dictionary);
	sort(dictionary);	/* sort an array using bubble sort */
	for (int i = 0; i <= 19; ++i)	/* print the most popular words */
		printf ("\n%d. \"%s\" втречается в файле %d раз\n", i+1, dictionary[i].word, dictionary[i].count);  
	_getch();
	fclose(fl);
	delete []dictionary;
	return 0;
}

void readFileToArr(FILE *fl, words *arr)
{
	char separator[] = " ,.?!;:“”\r\n", Str[MAX_LINE_LENGTH];
	int i = 0;
	while (fgets(Str, MAX_LINE_LENGTH, fl) != NULL)
	{
		Str[MAX_LINE_LENGTH - 1] = '\0';
		char *word;
		word = strtok(Str, separator);
		while (word)              
		{
			addWordToArr(arr, word);
			word = strtok(NULL, separator);
		}
	}    
}

void addWordToArr(words *arr, char *word)
{
	/* the word is alredy in the array? word.count++ : copy the word into the array */
	for (int i=0; i < wordCount; ++i)	
		if (strcmp(arr[i].word, word)==0)
		{
			arr[i].count++;
			return;
		}
	arr[wordCount].word = new char [strlen(word)+1];
	strcpy(arr[wordCount].word, word);
	arr[wordCount].count = 1;
	wordCount++;
}


void sort(words *arr)
{ 
	for (int i = wordCount - 1; i > 0; --i)
		for (int j = 0; j < i; ++j)
			if (arr[j].count < arr[j+1].count) 
			{
				words tmp = arr[j+1]; 
				arr[j+1] = arr[j]; 
				arr[j] = tmp;
			}
}