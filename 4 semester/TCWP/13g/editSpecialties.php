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

		$speciality = $_REQUEST['speciality'];
		$budjet = $_REQUEST['budjet'];
		
		mysql_query("INSERT INTO speciality (name,budjet)
		VALUES ('$speciality','$budjet')");
		
		$specialityDelete = $_REQUEST['specialityDelete'];
		$id = $_REQUEST['id'];
		
		mysql_query("DELETE FROM speciality WHERE name = '$specialityDelete'");
		mysql_query("DELETE FROM speciality WHERE id = '$id'");

		GetSpecialties();

function GetSpecialties()
{
$result = mysql_query('SELECT * FROM speciality');
echo "<p>Список специльностей - количества их бюджетных мест :";
while ($row = mysql_fetch_array($result))
{
    echo '<li>';
	echo "<t>[#$row[0]]";
    echo "<t>$row[1]";
	echo "<t> - $row[2]";
    echo '</a>';
    echo '</li>';
}
}
?>

<form action="editSpecialties.php" method='POST'>
		<fieldset>
			<legend>Введите специльность и количество бюджетных мест для данной специальности</legend>
			<table>
				<tr><p>
					<td><label for="speciality">Название специльности:</label></td>
					<td><input type="text" id="speciality" name="speciality" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['speciality'];?>></td>
				</p></tr>
				<tr><p>
					<td><label for="budjet">Количество бюджетных мест:</label></td>
					<td><input type="text" id="budjet" name="budjet" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['budjet'];?>></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Добавить'/>
</form>

<form action="editSpecialties.php" method='POST'>
		<fieldset>
			<legend>Введите номер или название специальности , которую желаете удалить</legend>
			<table>
				<tr><p>
					<td><label for="specialityDelete">Название специльности:</label></td>
					<td><input type="text" id="specialityDelete" name="specialityDelete" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['specialityDelete'];?>></td>
				</p></tr>
				<tr><p>
					<td><label for="id">Идентификационный номер:</label></td>
					<td><input type="text" id="id" name="id" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['id'];?>></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Удалить'/>
</form>

<p><em><a href ="index.php">Вернуться на главную</a></em></p>
</body>
</html>