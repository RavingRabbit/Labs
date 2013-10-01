<?php
include_once("config.php");

/*
 * студенты получившие более 80 баллов
*/
function budgetStudents() {
	$sql = "SELECT s.name as studName, d.name as discName, sdr.mark as mark FROM `students_disciplines_ref` sdr 
			INNER JOIN `students` s ON sdr.student_id = s.id
			INNER JOIN `disciplines` d ON sdr.discipline_id = d.id
			WHERE `mark` > 80
			ORDER BY sdr.mark desc
			LIMIT 0, 5
		";
	$res = mysql_query($sql);
	
	while($row = mysql_fetch_array($res)) {
		$rows[] = $row;
	}
	
	return $rows;
}

/*
 * студенты более 50 меньше 80
*/
function notBudgetStudents() {
	$sql = "SELECT s.name as studName, d.name as discName, sdr.mark as mark FROM `students_disciplines_ref` sdr 
			INNER JOIN `students` s ON sdr.student_id = s.id
			INNER JOIN `disciplines` d ON sdr.discipline_id = d.id
			WHERE `mark` < 80 AND `mark` >= 50
			ORDER BY sdr.mark desc
			LIMIT 0, 5
		";
	$res = mysql_query($sql);
	
	while($row = mysql_fetch_array($res)) {
		$rows[] = $row;
	}
	
	return $rows;
}


function GetDisciplines() {
	$sql = "SELECT * FROM disciplines d GROUP BY d.name";
	$res = mysql_query($sql);
	while($row = mysql_fetch_array($res)) {
		$rows[] = $row;
	}
	return $rows;
}


function GetBestStydentsByDiscipline($discId) {
	$sql = "SELECT s.name as studName, d.name as discName, sdr.mark as mark FROM students_disciplines_ref sdr
			INNER JOIN students s ON sdr.student_id=s.id
			INNER JOIN disciplines d ON sdr.discipline_id = d.id
			WHERE sdr.discipline_id = {$discId}
			ORDER BY sdr.mark DESC
			LIMIT 0, 3
	";
	$res = mysql_query($sql);
	
	while($row = mysql_fetch_array($res)) {
		$rows[] = $row;
	}
	
	return $rows;
}

?>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link href ="style.css" type ="text/css" rel ="stylesheet"/>
	<title>БД</title>
</head>
<body>

<h3>Отчет</h3>
<p>
	<b>Поступившие на бюджет:</b><br />
	<?php
		$students = budgetStudents();
		for($i = 0; $i < sizeof($students); $i++) {
			echo "<p>{$students[$i]["studName"]} - {$students[$i]["discName"]} = {$students[$i]["mark"]}</p>";
		}
	?>
</p>
<br />
<p>
	<b>неПоступившие на бюджет:</b><br />
	<?php
		$students = notBudgetStudents();
		for($i = 0; $i < sizeof($students); $i++) {
			echo "<p>{$students[$i]["studName"]} - {$students[$i]["discName"]} = {$students[$i]["mark"]}</p>";
		}
	?>
</p>

<br />

<p>
	<b>упорядоченный список студентов:</b><br />
	<?php
		$specialities = GetDisciplines();

		foreach($specialities as $spec) {
			echo "{$spec["name"]}:<br />";
			$bestStudents = GetBestStydentsByDiscipline($spec["id"]);
			
			foreach($bestStudents as $student) {
				echo "{$student["studName"]}[{$student["discName"]}]: {$student["mark"]}<br />";
			}
			
			echo "<br/><br />";
		}
	?>
</p>
 
</body>
</html>