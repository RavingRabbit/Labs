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
				<input type="hidden" value="2" name="step">
								<fieldset>
								<?php 
									require_once("dbFunctions.php");
									$speciality = $_SESSION["speciality"]; 
								?>
								<p>Баллы по дисциплинам: </p>
									<table>
										<tbody>
											<?php 
												$subjects = GetSubjectsForSpecialty($speciality["id"]);
												foreach ($subjects as $subject) {															
											?>
											<tr>
												<td><?php echo $subject["name"]; ?></td>
												<td><input type="text" name="<?php echo $subject["id"]; ?>" /></td>
											</tr>
											<?php } ?>								
										</tbody>										
									</table>												
								
				</fieldset>
				<input type="submit" name="submit" value="Отправить" />	
			</form>
		</div>
		</div>
	</body>
</html>