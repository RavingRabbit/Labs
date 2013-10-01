<?php
	if ($_POST["addSpeciality"] == 1)
	{
		$checkingResults = array();
		$name = $_POST["name"];
		if ($name == '')
			array_push($checkingResults, 'Название специальности не задано');
		$budget = $_POST["budget"];
		if ($budget == '')
			array_push($checkingResults, 'Количество бюджетных мест не задано');
		else
		{
			if (!preg_match("/^ *\d+ *$/", $budget))
				array_push($checkingResults, 'Количество бюджетных мест должно быть положительным числом');
			else
			{
				$matches = array();
				preg_match("(\d+)", $budget, $matches);
				$budget = $matches[0];
			}
		}
		$subjects = array();
		if (isset($_POST['subjects']))
			foreach ($_POST['subjects'] as $subject)
				array_push($subjects, $subject);
		if (count($subjects) == 0)
			array_push($checkingResults, 'Дисциплины для поступления не заданы');
		if (count($checkingResults) == 0)
		{
			require("dbFunctions.php");
			AddSpecialty($name, $subjects, $budget);
			$operation = "Добавление специальности";
			include("operationComplete.php");
		}
		else
			include("addSpecialityForm.php");
	}
	else
	{
		include("addSpecialityForm.php");
	}
?>