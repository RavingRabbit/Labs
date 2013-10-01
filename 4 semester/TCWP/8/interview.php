<?php
	if ($_POST["register"] == 1)
	{
		$checkingResults = array();
		$firstname = $_POST["firstname"];
		if ($firstname == '')
			array_push($checkingResults, 'Имя не задано');
		$lastname = $_POST["lastname"];
		if ($lastname == '')
			array_push($checkingResults, 'Фамилия не задана');
		$middlename = $_POST["middlename"];	
		if ($middlename == '')
			array_push($checkingResults, 'Отчество не задано');
		$birthday = $_POST["birthday"];	
		if ($birthday == '')
			array_push($checkingResults, 'Дата рождения не задана');
		$gender = $_POST["gender"];	
		if ($gender == '')
			array_push($checkingResults, 'Пол не задан');
		$subscribe = $_POST["subscribe"] == 'on' ? 'да' : 'нет';
		$color = $_POST["color"];	
		if ($color == '')
			array_push($checkingResults, 'Любимый цвет не задан');
		$drinks = array();
		if (isset($_POST['drinks']))
			foreach ($_POST['drinks'] as $drink)
				array_push($drinks, $drink);
		if (count($drinks) == 0)
			array_push($checkingResults, 'Любимые напитки не заданы');
		$additionalInf = $_POST["additionalInf"];	
		if (count($checkingResults) == 0)
			include("biography.php");
		else
			include("form.php");
	}
	else
	{
		include("form.php");
	}
?>