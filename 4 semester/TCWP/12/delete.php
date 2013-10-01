<?php
	require("functions.php");
	$file = $_GET["file"];
	if ($file == '')
		return;
	$separator = chr(92);
	$file = str_replace($separator.$separator, $separator, $file);
	$file = iconv('utf-8', 'cp1251', $file);
	unlink($file);
	$directory = $_GET["directory"];
	$directory = str_replace($separator.$separator, $separator, $directory);
	$directory = iconv('utf-8', 'cp1251', $directory);
?>

<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Проводник</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>	
		<div class="content">
			<h1><?php echo iconv('cp1251', 'utf-8', $file) ?></h1>
			<div class="content">	
				<p><a href="<?php echo 'explorer.php?directory=' . iconv('cp1251', 'utf-8', $directory) ?>"><?php echo iconv('cp1251', 'utf-8', $directory) ?></a></p>
				<p><strong>Файл <?php echo iconv('cp1251', 'utf-8', $file) ?> удалён.</strong></p>
			</div>
		</div>
	</body>
</html>