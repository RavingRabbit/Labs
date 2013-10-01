<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Добавление дисциплины</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>
	
	<div class="content">
		<h1>Добавление дисциплины</h1>
		<div style="max-width:500px;">
			<?php
				if (isset($checkingResults)) {
			?>
				<div>
					<ul>
						<?php 						
							foreach ($checkingResults as $chechResult)
								echo '<li>' . $chechResult . '</li>';
						?>
					</ul>
				</div>
			<?php } ?>
			<form action="addSubject.php" method="post">
				<input type="hidden" value="1" name="addSubject">
				<fieldset>
					<table>
							<tbody>
								<tr>
									<td><label for="name">Название дисциплины:</label></td>
									<td><input type="text" id="name" name="name" value="<?php if (isset($name)) echo $name; ?>" /></td>
								</tr>
							</tbody>
					</table>
				</fieldset>
				<input type="submit" name="submit" value="Отправить" />	
			</form>
		</div>
		</div>
	</body>
</html>