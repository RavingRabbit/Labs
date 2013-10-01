<?php
	require("functions.php");
	$separator = chr(92);
	$directory = $_GET["directory"];
	if ($directory == '')
		$directory = "D:\\";
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
			<h1>Проводник</h1>
			<div class="content">	
				<ul>
					<li>Папки:
						<ul>
							<?php 
								$directories = GetDirectories($directory);
								foreach ($directories as $key => $value) 
								{
									if ($value == '.')
										continue;
							?>
							<li><a href="<?php echo 'explorer.php?directory='.iconv('cp1251', 'utf-8', $directory).$separator.iconv('cp1251', 'utf-8', $value)?>"><?php if ($value == '..') echo 'Назад'; else  echo iconv('cp1251', 'utf-8', $value); ?></a></li>
							<?php } ?>						
						</ul>
					</li>
					<li>Файлы:
						<ul>
							<?php 
								$files = GetFiles($directory);
								foreach ($files as $key => $value) 
								{
							?>
							<li>
								<a href="<?php echo 'file.php?file='.iconv('cp1251', 'utf-8', $directory).$separator.iconv('cp1251', 'utf-8', $value).'&directory='.iconv('cp1251', 'utf-8', $directory) ?>"><?php echo iconv('cp1251', 'utf-8', $value) ?></a>
								 [<a href="<?php echo 'delete.php?file='.iconv('cp1251', 'utf-8', $directory).$separator.iconv('cp1251', 'utf-8', $value).'&directory='.iconv('cp1251', 'utf-8', $directory) ?>">удалить</a>]
							</li>
							<?php } ?>						
						</ul>
					</li>
				</ul>
			</div>
		</div>
	</body>
</html>