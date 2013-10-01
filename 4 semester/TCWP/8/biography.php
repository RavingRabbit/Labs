<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Краткая автобиграфия</title>	
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
		<style type="text/css">
			body {
			color: #555555;
			font-family: Arial,Helvetica,sans-serif;
			font-size: 12px;
			}
		</style>		
	</head>
	<body>
	<div class="content">
		<h1>Краткая автобиграфия</h1>
		<p><?php echo $lastname; ?> <?php echo $firstname; ?> <?php echo $middlename; ?> родил<?php if ($gender == 0) echo 'ся'; else echo 'ась';?> <?php echo $birthday ?>. <?php if ($gender == 0) echo 'Его'; else echo 'Её';?> любимый цвет - <?php echo $color ?>, а 
		<?php 
			if (count($drinks) == 1)
				echo $drinks[0];
			else
			{
				echo $drinks[0];
				for ($i = 1; $i < count($drinks) - 1; $i++)
					echo ', ' . $drinks[$i];
				echo ' и ' . $drinks[count($drinks) - 1];
			}
		?> - <?php if (count($drinks) > 1) echo 'любимые напитки'; else echo 'любимый напиток'; ?>. <?php echo $additionalInf; ?></p>
	</div>
	</body>
</html>