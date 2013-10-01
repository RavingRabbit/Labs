<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Форма</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>
	
	<div class="content">
		<h1>Форма</h1>
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
			<form action="register.php" method="post">
				<input type="hidden" value="1" name="register">
				<fieldset>
					<legend>Контактные данные</legend>
					<table>
							<tbody>
								<tr>
									<td><label for="mail">Электронный адрес :</label></td>
									<td><input type="text" id="mail" name="mail" value="<?php if (isset($mail)) echo $mail; ?>" /></td>
								</tr>
								<tr>
									<td><label for="phone">Телефон в формате (ххх)ххх-хх-хх:</label></td>
									<td><input type="text" id="phone" name="phone"  value="<?php if (isset($phone)) echo $phone; ?>" /></td>
								</tr>
									<td><label for="password">Пароль:</label></td>
									<td><input type="password" id="password" name="password" /></td>
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