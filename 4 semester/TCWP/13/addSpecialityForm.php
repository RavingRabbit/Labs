<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Добавление специальности</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>	
	<div class="content">
		<h1>Добавление специальности</h1>
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
			<form action="addSpeciality.php" method="post">
				<input type="hidden" value="1" name="addSpeciality">
				<fieldset>
					<table>
						<tbody>
							<tr>
								<td><label for="name">Название специальности:</label></td>
								<td><input type="text" id="name" name="name" value="<?php if (isset($name)) echo $name; ?>" /></td>
							</tr>
							<tr>
								<td><label for="subjects">Дисциплины для поступления: </label></td>
								<td>
									<select name="subjects[]" id="subjects" multiple="multiple">
									<?php 
										require("dbFunctions.php");
										$subjects = GetSubjects();
										foreach ($subjects as $subject) { 
									?>
											<option value="<?php echo $subject["id"]; ?>"><?php echo $subject["name"]; ?></option>
									<?php } ?>
									</select>
								</td>
							</tr>
							<tr>
								<td><label for="budget">Количество бюджетных мест:</label></td>
								<td><input type="text" id="budget" name="budget" value="<?php if (isset($budget)) echo $budget; ?>" /></td>
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