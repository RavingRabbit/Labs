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

		$discipline = $_REQUEST['discipline'];
	
		mysql_query("INSERT INTO disciplines (name)
		VALUES ('$discipline')");
		
		$disciplineDelete = $_REQUEST['disciplineDelete'];
		$id = $_REQUEST['id'];
		
		mysql_query("DELETE FROM disciplines WHERE name = '$disciplineDelete'");
		mysql_query("DELETE FROM disciplines WHERE id = '$id'");

		GetDisciplines();

function GetDisciplines()
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
}
?>

<form action="editDisciplines.php" method='POST'>
		<fieldset>
			<legend>Введите дисциплину ,которую желаете добавить</legend>
			<table>
				<tr><p>
					<td><label for="discipline">Название дисциплины:</label></td>
					<td><input type="text" id="discipline" name="discipline" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['discipline'];?>></td>
				</p></tr>				
			</table>
		</fieldset>
		<input type="submit" name="send" value='Добавить'/>
</form>

<form action="editDisciplines.php" method='POST'>
		<fieldset>
			<legend>Введите номер или название дисциплины , которую желаете удалить</legend>
			<table>
				<tr><p>
					<td><label for="disciplineDelete">Название дисциплины:</label></td>
					<td><input type="text" id="disciplineDelete" name="disciplineDelete" value=<?php if (!empty($_REQUEST)) echo $_REQUEST['disciplineDelete'];?>></td>
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