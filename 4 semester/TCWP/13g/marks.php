<?php
include_once("config.php");

if($_POST["studentName"]) {
		$studentId = $_POST["studentName"];
		$disId = (int) $_POST["disId"];
		$mark = (float) $_POST["mark"];
		
		$sql = "INSERT INTO `students_disciplines_ref`(`student_id`, `discipline_id`, `mark`) VALUE ({$studentId}, {$disId}, '{$mark}')";
		$res = mysql_query($sql);
		
		if(!$res) {
			echo "Возникла ошибка. обратитесь к администратору";
		}
		else {
			header("Location: marks.php");
		}
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


<?php 
require_once('config.php');
mysql_query("SET NAMES UTF8");

		$specId = $_REQUEST['specId'];
		$disId = $_REQUEST['disId'];
		
		$spec = mysql_query("SELECT * FROM speciality WHERE id = '$specId'");
		$specArr = mysql_fetch_array($spec);
		
		$dis = mysql_query("SELECT * FROM disciplines WHERE id = '$disId'");
		$disArr = mysql_fetch_array($dis);
		
		echo "<p>$specArr[0]";
		echo "<p>$disArr[0]";
		
		mysql_query("INSERT INTO relation ('disciplinesId' ,'specialityId') VALUES ( '$disArr[0], '$specArr[0]')");

		
		
		
		
		GetDisciplines();
		
		


function GetSpecialtiesUl()
{
	echo "<p>Список специльностей - количества их бюджетных мест :";
	$specialites = GetSpecialites();
	
	for($i = 0; $i < sizeof($specialites); $i++)
	{
		echo '<li>';
		echo "<t>[#{$specialites[$i][0]}]";
		echo "<t>{$specialites[$i][1]}";
		echo "<t> - {$specialites[$i][2]}";
		echo '</a>';
		echo '</li>';
	}
}

function GetStudentsSelectList() {
	$students = GetStudents();
	$list = "<select name='studentName'>";
	
	for($i = 0; $i < sizeof($students); $i++) {
		$list .= "<option value='{$students[$i]['id']}'>{$students[$i]['name']}</option>";
	}
	
	$list .= "</select>";
	
	return $list;
}

function GetStudents() {
	$result = mysql_query('SELECT * FROM students');
	$rows = array();
	
	while ($row = mysql_fetch_array($result)) {
		$rows[] = $row;
	}
	
	return $rows;
}


function GetDisciplines()
{
	$result = mysql_query('SELECT * FROM disciplines');
	
	while ($row = mysql_fetch_array($result))
	{
		$rows[] = $row;
	}
	
	return $rows;
}

function GetDisciplinesSelectList() {
	$disciplines = GetDisciplines();
	$list = "<select name='disId'>";
	
	for($i = 0; $i < sizeof($disciplines); $i++) {
		$list .= "<option value='{$disciplines[$i]['id']}'>{$disciplines[$i]['name']}</option>";
	}
	
	$list .= "</select>";
	
	return $list;
}


function GetStudentsDisciplines() {
	$sql = "SELECT s.name as studName, d.name as dicpName, sdr.mark as mark FROM `students_disciplines_ref` sdr 
			LEFT JOIN `students` s ON sdr.student_id = s.id
			LEFT JOIN `disciplines` d ON sdr.discipline_id = d.id
			ORDER BY s.name
	";
	
	$res = mysql_query($sql);
	
	while($row = mysql_fetch_array($res)) {
		$rows[] = $row;
	}
	
	return $rows;
}


?>



<form action="marks.php" method='POST'>
		<fieldset>
			<legend>Введите номер специльности и номер дисциплины , которые желаете связать</legend>
			<table>
				<tr><p>
					<td><label for="studentName">Имя студента:</label></td>
					<!--<td><input type="text" id="specId" name="specId" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['studentName'];?>></td>-->
					<td><?php echo GetStudentsSelectList(); ?></td>
				</p></tr>
				<tr><p>
					<td><label for="disId">Дисциплина:</label></td>
					<!--<td><input type="text" id="disId" name="disId" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['disId'];?>></td>-->
					<td><?php echo GetDisciplinesSelectList(); ?></td>
				</p></tr>	
				<tr><p>
					<td><label for="disId">Набранный балл:</label></td>
					<td><input type="text" id="mark" name="mark" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['mark'];?>></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Связать'/>
</form>
 <p><em><a href ="index.php">Вернуться на главную</a></em></p>

 <div>
	<p>Абитуриенты:</p>
	
	<?php
		$abiturs = GetStudentsDisciplines();
		for($i = 0; $i < sizeof($abiturs); $i++) {
			echo "<p>{$abiturs[$i]["studName"]} - {$abiturs[$i]["dicpName"]} = {$abiturs[$i]["mark"]}</p>";
		}
	?>
 </div>
 
</body>
</html>