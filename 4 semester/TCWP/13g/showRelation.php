<?php
	@include_once("config.php");
	
	if($_POST["specId"]) {
		$specId = (int) $_POST["specId"];
		$disId = (int) $_POST["disId"];
		
		$sql = "INSERT INTO `relation`(`disciplinesId`, `specialityId`) VALUE ({$disId}, {$specId})";
		$res = mysql_query($sql);
		
		if(!$res) {
			echo "Возникла ошибка. обратитесь к администратору";
		}
		else {
			header("Location: showRelation.php");
		}
	}
	
	
	
	function GetRelations() {
		$sql = "SELECT s.id as specId, s.name as specName, d.id as discId, d.name as discName FROM `relation` r
				LEFT JOIN `disciplines` d ON r.disciplinesId = d.id
				LEFT JOIN `speciality` s ON r.specialityId = s.id
				ORDER BY r.specialityId
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
	<h3>Установленные связи</h3>
	<?php 
		$relations = GetRelations();
		for($i = 0; $i < sizeof($relations); $i++) {
			echo "<p>{$relations[$i]['specName']} -> {$relations[$i]['discName']}<br />";
		}
	?>
 <p><em><a href ="index.php">Вернуться на главную</a></em></p>
</body>
</html>