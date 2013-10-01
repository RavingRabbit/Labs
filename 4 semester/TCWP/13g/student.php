<?php

require_once('config.php');
mysql_query("SET NAMES UTF8");

if($_POST["specId"]) {
		$specId = (int) $_POST["specId"];
		$studentName = $_POST["studentName"];
		
		$sql = "INSERT INTO `students`(`name`, `specialityId`) VALUE ('{$studentName}', {$specId})";
		$res = mysql_query($sql);
		
		if(!$res) {
			echo "Возникла ошибка. обратитесь к администратору";
		}
		else {
			header("Location: student.php");
		}
}

function GetSpecialites() {
	$result = mysql_query('SELECT * FROM speciality');
	$rows = array();
	
	while ($row = mysql_fetch_array($result)) {
		$rows[] = $row;
	}
	
	return $rows;
}
function GetSpecialitesSelectList() {
	$specialites = GetSpecialites();
	$list = "<select name='specId'>";
	
	for($i = 0; $i < sizeof($specialites); $i++) {
		$list .= "<option value='{$specialites[$i]['id']}'>{$specialites[$i]['name']}</option>";
	}
	
	$list .= "</select>";
	
	return $list;
}


function GetStudentSpeciality() {
	$sql = "SELECT sp.id as specId, sp.name as specName, s.id as studId, s.name as studName FROM `students` s 
			LEFT JOIN `speciality` sp ON s.specialityId = sp.id 
			ORDER BY s.name
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
	<h3>Выберите специльность и укажите свое имя</h3>
	<?php 
		
	?>
	<form action="student.php" method='POST'>
		<fieldset>
			<legend></legend>
			<table>
				<tr><p>
					<td><label for="specId">Специльность:</label></td>
					<!--<td><input type="text" id="specId" name="specId" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['specId'];?>></td>-->
					<td><?php echo GetSpecialitesSelectList(); ?></td>
				</p></tr>
				<tr><p>
					<td><label for="studentName">Имя:</label></td>
					<td><input type="text" id="studentName" name="studentName" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['studentName'];?>></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Связать'/>
</form>
 <p><em><a href ="index.php">Вернуться на главную</a></em></p>
 <div>
	<p>Студенты:</p>
	<?php
		$students = GetStudentSpeciality();
		
		for($i = 0; $i < sizeof($students); $i++) {
			echo "<p>{$students[$i]["studName"]} -> {$students[$i]["specName"]}</p>";
		}
	?>
 </div>
</body>
</html>