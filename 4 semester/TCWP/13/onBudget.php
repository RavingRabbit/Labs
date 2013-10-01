<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Поступившие на бюджет</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>	
	<div class="content">
		<h1>Поступившие на бюджет</h1>
		<?php 
			require_once("dbFunctions.php");	
			$specialties = GetSpecialties();
			require_once("dbFunctions.php");
			foreach ($specialties as $specialty) {		
												
		?>
			<div>
				<table>
					<tbody>
						<tr>
							<th>Дисциплина: <?php echo $specialty["name"]; ?></th>
							<th>Бюджетных мест: <?php echo $specialty["budgetPlacesNumber"]; ?></th>
						</tr>
						<?php
							$applicants = GetBestApplicants($specialty["id"]);
							for ($i = 0; $i < $specialty["budgetPlacesNumber"] && $i < count($applicants); $i++) {
							$applicant = $applicants[$i];
						?>
						<tr>
							<td><?php echo $applicant["fio"]; ?></td><td><?php echo $applicant["mark"]; ?></td>
						</tr>
						<?php } ?>
					</tbody>
				</table>			
			</div>
		<?php } ?>
		
	</div>
	</body>
</html>