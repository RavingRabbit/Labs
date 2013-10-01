<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>ТОП абитуриентов по дисциплинам</title>		
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
	</head>
	<body>	
	<div class="content">
		<h1>ТОП абитуриентов по дисциплинам</h1>
		<?php 
			require_once("dbFunctions.php");	
			$subjects = GetSubjects();		
			foreach ($subjects as $subject) {			
				$link = mysqli_connect(DB_HOST, DB_LOGIN, DB_PASSWORD, DB_NAME);
				$subjectId = $subject["id"];
				$result = mysqli_query($link, "SELECT ApplicantId, Mark FROM applicantsubjects WHERE SubjectId = $subjectId ORDER BY Mark");
				$applicantsMarks = array();	
				if ($result)
					while ($row = mysqli_fetch_row($result))
						{
							$applicant = GetApplicant($row[0]);
							array_push($applicantsMarks, array("applicant" => $applicant, "mark" => $row[1]));	
						}			
		?>
			<div>
				<table>
					<tbody>
						<tr>
							<th colspan="2"> Дисциплина: <?php echo $subject["name"]; ?></th>
						</tr>
						<?php
							foreach ($applicantsMarks as $applicantMark) {
						?>
						<tr>
							<td><?php $applicant = $applicantMark["applicant"]; echo $applicant["fio"]; ?></td><td><?php echo $applicantMark["mark"]; ?></td>
						</tr>
						<?php } ?>
					</tbody>
				</table>			
			</div>
		<?php } ?>
		
	</div>
	</body>
</html>