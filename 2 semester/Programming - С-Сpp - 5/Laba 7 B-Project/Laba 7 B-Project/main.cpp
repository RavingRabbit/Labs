#include <stdlib.h>
#include <stdio.h>
#include <string>
#include <conio.h>
#include "basicstructures.h"
#include "project.h"
#include "interface.h"

int main()
{
	Project* project = MainMenuOnStart();
	OpenedProjectMenu(project);
}
