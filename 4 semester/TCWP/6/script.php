<?php
	$firstname = $_POST["firstname"];
	$lastname = $_POST["lastname"];
	$middlename = $_POST["middlename"];	
	$birthday = $_POST["birthday"];	
	$gender = $_POST["gender"];	
	$subscribe = $_POST["subscribe"] == 'on' ? 'да' : 'нет';
	$color = $_POST["color"];	
	if (isset($_POST['drinks']))
		foreach ($_POST['drinks'] as $drink)
			$drinks .= $drink . ' '; 
	$formFeedback = $_POST["formFeedback"];	
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Форма</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>
	<div class="content">
		<p>Данные, переданные в форму:</p>
		<ul>
			<li>Имя: <strong><?php echo $firstname ?></strong></li>
			<li>Фамилия: <strong><?php echo $lastname ?></strong></li>
			<li>Отчество: <strong><?php echo $middlename ?></strong></li>
			<li>Дата рождения: <strong><?php echo $birthday ?></strong></li>
			<li>Пол: <strong><?php echo $gender ?></strong></li>
			<li>Подписаться на рассылку: <strong><?php echo $subscribe ?></strong></li>
			<li>Любимый цвет: <strong><?php echo $color ?></strong></li>
			<li>Любимые напитки: <strong><?php echo $drinks ?></strong></li>
			<li>Обратная связь: <strong><?php echo $formFeedback ?></strong></li>
		</ul>
		</div>
	</body>
</html>