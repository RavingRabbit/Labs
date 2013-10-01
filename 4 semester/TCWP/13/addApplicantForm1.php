<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Добавление абитуриента</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>
	
	<div class="content">
		<h1>Добавление абитуриента</h1>
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
			<form action="addApplicant.php" method="post">
				<input type="hidden" value="1" name="addApplicant">
				<input type="hidden" value="1" name="step">
								<fieldset>
					<table>
							<tbody>
								<tr>
									<td><label for="fio">ФИО абитуриента:</label></td>
									<td><input type="text" id="fio" name="fio" value="<?php if (isset($fio)) echo $fio; ?>" /></td>
								</tr>								
								<tr>										
									<td><label for="speciality">Специальность: </label></td>
									<td>
										<select name="speciality" id="speciality">
										<?php 
											require("dbFunctions.php");
											$specialties = GetSpecialties();
											foreach ($specialties as $specialty) { 
										?>
											<option value="<?php echo $specialty["id"]; ?>"><?php echo $specialty["name"]; ?></option>
										<?php } ?>
										</select>
									</td>
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