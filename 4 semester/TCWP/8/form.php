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
			<form action="interview.php" method="post">
				<input type="hidden" value="1" name="register">
				<fieldset>
					<legend>Личная информация</legend>
					<table>
							<tbody>
								<tr>
									<td><label for="firstname">Имя:</label></td>
									<td><input type="text" id="firstname" name="firstname" /></td>
								</tr>
								<tr>
									<td><label for="lastname">Фамилия:</label></td>
									<td><input type="text" id="lastname" name="lastname" /></td>
								</tr>
									<td><label for="middlename">Отчество:</label></td>
									<td><input type="text" id="middlename" name="middlename" /></td>
								</tr>
								<tr>
									<td><label for="birthday">Дата рождения:</label></td>
									<td><input type="text" id="birthday" name="birthday" /></td>
								</tr>
								<tr>
									<td>Пол:</td>
									<td>
										<label>
											<input type="radio" value="0" id="gender1" name="gender" checked="checked">
											Мужской
										</label>
										<label>
											<input type="radio" value="1" id="gender2" name="gender">	
											Женский
										</label>										
									</td>
								</tr>
								<tr>
									<td><label for="subscribe">Подписаться на рассылку:</label></td>
									<td><input type="checkbox" id="subscribe" name="subscribe"></td>
								</tr>
							</tbody>
					</table>
				</fieldset>
				<fieldset>
					<legend>Дополнительная информация</legend>
					<table>
							<tbody>
								<tr>
									<td><label for="color">Любимый цвет: </label></td>
									<td>
										<select name="color" id="color">
											<option>красный</option>
											<option>жёлтый</option>
											<option>синий</option>
										</select>
									</td>
								</tr>
								<tr>
									<td><label for="drinks">Любимые напитки: </label></td>
									<td>
										<select name="drinks[]" id="drinks" multiple="multiple">
											<option value="чай">Чай</option>
											<option value="кофе">Кофе</option>
											<option value="сок">Сок</option>
											<option value="алкоголь">Алкоголь</option>
										</select>
									</td>
								</tr>
							</tbody>
					</table>				
				</fieldset>
				<fieldset>
					<legend>Дополнительная информация</legend>
					<textarea rows="5" cols="50" name="additionalInf" id="additionalInf"></textarea>
				</fieldset>
				<input type="submit" name="submit" value="Отправить" />	
			</form>
		</div>
		</div>
	</body>
</html>