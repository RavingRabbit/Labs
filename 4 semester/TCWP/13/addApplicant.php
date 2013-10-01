<?php 
	session_start();
	header("Content-Type: text/html; charset=utf-8");
?>
<?php
	if ($_POST["addApplicant"] == 1)
	{		
		if ($_POST["step"] == 1)
		{
			$checkingResults = array();
			$fio = $_POST["fio"];
			if ($fio == '')
				array_push($checkingResults, 'ФИО абитуриента не задано');
			$speciality = $_POST["speciality"];
			if ($speciality == '')
				array_push($checkingResults, 'Специальность не выбрана');
			if (count($checkingResults) == 0)
			{
				require_once("dbFunctions.php");
				$_SESSION["speciality"] = GetSpecialty($_POST["speciality"]);				
				$_SESSION["fio"] = $fio;					
				include("addApplicantForm2.php");
			}
			else
				include("addApplicantForm1.php");
		}
		else
		{
			$checkingResults = array();
			///
			if (count($checkingResults) == 0)
			{	
				$marks = array();
				foreach ($_POST as $key => $value)
				{
					if (((int)$key) != 0)
						array_push($marks, array("id" => $key, "mark" => $value));
				}
				require_once("dbFunctions.php");
				$spec = $_SESSION["speciality"];
				$specId = $spec["id"];				
				AddApplicant($_SESSION["fio"], $specId, $marks);
				$operation = "Добавление абитуриента";
				include("operationComplete.php");
				$_SESSION["speciality"] = '';
				$_SESSION["fio"] = '';
			}
			else
				include("addApplicantForm2.php");
		}
	}
	else
	{
		include("addApplicantForm1.php");
	}
?>