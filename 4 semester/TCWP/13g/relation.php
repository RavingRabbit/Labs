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

		
		
		
		//GetSpecialtiesUl();
		GetDisciplines();
		
		
/*function GetDisciplines()
{
$result = mysql_query('SELECT * FROM disciplines');
echo "<p>Список дисципилин :";
while ($row = mysql_fetch_array($result))
{
    echo '<li>';
	echo "<t>[#$row[0]]";
    echo "<t>$row[1]";
    echo '</a>';
    echo '</li>';
}
}*/

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

function GetSpecialitesSelectList() {
	$specialites = GetSpecialites();
	$list = "<select name='specId'>";
	
	for($i = 0; $i < sizeof($specialites); $i++) {
		$list .= "<option value='{$specialites[$i]['id']}'>{$specialites[$i]['name']}</option>";
	}
	
	$list .= "</select>";
	
	return $list;
}

function GetSpecialites() {
	$result = mysql_query('SELECT * FROM speciality');
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


?>



<form action="showRelation.php" method='POST'>
		<fieldset>
			<legend>Введите номер специльности и номер дисциплины , которые желаете связать</legend>
			<table>
				<tr><p>
					<td><label for="specId">Номер специальности:</label></td>
					<!--<td><input type="text" id="specId" name="specId" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['specId'];?>></td>-->
					<td><?php echo GetSpecialitesSelectList(); ?></td>
				</p></tr>
				<tr><p>
					<td><label for="disId">Номер дисциплины:</label></td>
					<!--<td><input type="text" id="disId" name="disId" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['disId'];?>></td>-->
					<td><?php echo GetDisciplinesSelectList(); ?></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Связать'/>
</form>
 <p><em><a href ="index.php">Вернуться на главную</a></em></p>

</body>
</html>