<?php
	if ($_POST["register"] == 1)
	{
		$checkingResults = array();
		$mail = $_POST["mail"];
		if ($mail == '')
			array_push($checkingResults, 'Электронный адрес не задан');
		else
		{
			if (!ereg(".+@.+\..+", $mail))
				array_push($checkingResults, 'Электронный адрес некорректен');
		}
		$phone = $_POST["phone"];
		if ($phone == '')
			array_push($checkingResults, 'Телефон не задан');
		else
		{
			if (!preg_match("/^ *\(\d{3}\)\d{3}-\d{2}-\d{2} *$/", $phone))
				array_push($checkingResults, 'Тенефон не соответствует формату (ххх)ххх-хх-хх');
			else
			{
				$matches = array();
				preg_match("(\(\d{3}\)\d{3}-\d{2}-\d{2})", $phone, $matches);
				$phone = $matches[0];
			}
		}
		$password = $_POST["password"];	
		if (strlen($password) == 0)
			array_push($checkingResults, 'Пароль не задан');
		else
		{
			if (strlen($password) < 8)
				array_push($checkingResults, 'Пароль короче 8 символов');
			if (!preg_match("/^.*\d.*\d.*$/", $password))
				array_push($checkingResults, 'Пароль должен содержать хотя бы две цифры');
			if (!ereg("[A-Z]", $password))
				array_push($checkingResults, 'Пароль должен содержать хотя бы одну букву в верхнем регистре');
			if (!ereg("[a-z]", $password))
				array_push($checkingResults, 'Пароль должен содержать хотя бы одну букву в нижнем регистре');
			if (ereg(" ", $password))
				array_push($checkingResults, 'Пароль не должен содержать пробелов');
		}		
		if (count($checkingResults) == 0)
			include("thanks.php");
		else
			include("form.php");
	}
	else
	{
		include("form.php");
	}
?>