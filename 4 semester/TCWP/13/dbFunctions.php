<?php
	require("db.php");
	
	function AddSubject($name)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		if ($link == false)
			echo 'Ошибка подключения';
		$query = "INSERT INTO subject (Name) VALUES ('$name')";
		mysqli_query($link, $query);
	}
	
	function GetSubjects()
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$subjects = array();
		$result = mysqli_query($link, "SELECT Id, Name FROM subject");		
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($subjects, array("id" => $row[0], "name" => $row[1]));
		return $subjects;
	}
	
	function GetSubjectById($subjectsId)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$subjects = array();
		$result = mysqli_query($link, "SELECT Id, Name FROM subject WHERE Id = $subjectsId");		
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($subjects, array("id" => $row[0], "name" => $row[1]));
		return $subjects[0];
	}
	
	function GetSubjectsForSpecialty($specialityId)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$subjectIds = array();
		$result = mysqli_query($link, "SELECT SubjectId FROM specialitysubjects WHERE SpecialityId = $specialityId");		
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($subjectIds, $row[0]);
		$subjects = array();
		foreach ($subjectIds as $subjectId)
		{
			$result = mysqli_query($link, "SELECT Id, Name FROM subject WHERE Id = $subjectId");		
			if ($result)
				while ($row = mysqli_fetch_row($result))
					array_push($subjects, array("id" => $row[0], "name" => $row[1]));
		}
		return $subjects;
	}
	
	function AddSpecialty($name, $subjects, $budget)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$specialties = array();
		$query = "INSERT INTO specialties (Name, BudgetPlacesNumber) VALUES ('$name', $budget)";
		mysqli_query($link, $query);
		$row = mysqli_fetch_row(mysqli_query($link, "SELECT LAST_INSERT_ID()"));
		$id = $row[0];
		foreach ($subjects as $subjectId)
			mysqli_query($link, "INSERT INTO specialitysubjects (SubjectId, SpecialityId) VALUES ($subjectId, $id)");		
	}
	
	function GetSpecialties()
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$specialties = array();
		$result = mysqli_query($link, 'SELECT Id, Name, BudgetPlacesNumber FROM specialties');
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($specialties, array("id" => $row[0], "name" => $row[1], "budgetPlacesNumber" => $row[2]));
		return $specialties;
	}
	
	function GetSpecialty($specialtyId)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$specialties = array();
		$result = mysqli_query($link, "SELECT Id, Name, BudgetPlacesNumber FROM specialties WHERE Id = $specialtyId");
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($specialties, array("id" => $row[0], "name" => $row[1], "budgetPlacesNumber" => $row[2]));
		return $specialties[0];
	}
	
	function AddApplicant($fio, $specialityId, $marks)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		mysqli_query($link, "INSERT INTO applicant (Fio, SpecialityId) VALUES ('$fio', $specialityId)");
		$row = mysqli_fetch_row(mysqli_query($link, "SELECT LAST_INSERT_ID()"));
		$applicantId = $row[0];
		foreach ($marks as $mark)
		{
			$subjectId = $mark["id"];
			$mark = $mark["mark"];
			mysqli_query($link, "INSERT INTO applicantsubjects (ApplicantId, SubjectId, Mark) VALUES ($applicantId, $subjectId, $mark)");
		}
	}
	
	function GetApplicant($id)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$result = mysqli_query($link, "SELECT Id, Fio, SpecialityId FROM applicant WHERE Id = $id");
		$applicants = array();
		if (!$result) echo '!$result';
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($applicants, array("id" => $row[0], "fio" => $row[1], "specialityId" => $row[2]));
		return $applicants[0];
	}
	
	function GetOnBungetApplicants($specialty)
	{
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$budgetPlaces = $specialty["budgetPlacesNumber"];
		$applicants = array();
		$result = mysqli_query($link, 'SELECT Id, Name, BudgetPlacesNumber FROM specialties');
		if ($result)
			while ($row = mysqli_fetch_row($result))
				array_push($specialties, array("id" => $row[0], "name" => $row[1], "budgetPlacesNumber" => $row[2]));
		return $specialties;
	}		

    function GetBestApplicants($specialityId)
    {
		$applicants = array();
		$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
		$result = mysqli_query($link, "SELECT Id, Fio FROM applicant WHERE SpecialityId = $specialityId");
        while ($row = mysqli_fetch_row($result))
        {
			$sum = 0;
			$result2 = mysqli_query($link, "SELECT Mark FROM applicantsubjects WHERE ApplicantId = " . $row[0]);
			while ($row2 = mysqli_fetch_row($result2))
			{
				$sum += $row2[0];
			}
			$name = $row[1];
			array_push($applicants, array("fio" => $row[1], "mark" => $sum));
			arsort($applicants);
		}
		return $applicants;
   }

?>