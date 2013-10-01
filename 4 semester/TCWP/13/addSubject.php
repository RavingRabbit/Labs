<?php
	if ($_POST["addSubject"] == 1)
	{
		$checkingResults = array();
		$name = $_POST["name"];
		if ($name == '')
			array_push($checkingResults, 'Название дисциплины не задано');
		if (count($checkingResults) == 0)
		{
			require("dbFunctions.php");
			AddSubject($name);
			$operation = "Добавление дисциплины";
			include("operationComplete.php");
		}
		else
			include("addSubjectForm.php");
	}
	else
	{
		include("addSubjectForm.php");
	}
?>