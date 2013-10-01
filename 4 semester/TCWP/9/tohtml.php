<?php	
	require("sequences.php");
	$b0 = 1;
	$q = 2;
	$n = 10;
	$sequences = array( 'geometric' => GeometricProgression($b0, $q, $n), 'fibonacci' => FibonacciSequence($n));
	
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Последовательности</title>	
		<link rel="stylesheet" href="style.css" type="text/css" media="screen" />	
		<style type="text/css">
			body {
			color: #555555;
			font-family: Arial,Helvetica,sans-serif;
			font-size: 16px;
			}
		</style>		
	</head>
	<body>
	<div class="content">
		<h1>Последовательности</h1>
		<h2>Геометрическая прогрессия:</h1>
		<p>
			b<sub>0</sub> = <?php echo $b0; ?>, q = <?php echo $q; ?>, n = <?php echo $n; ?>.
			</br>
			<?php echo ArrayToString($sequences['geometric']); ?>			
		</p>
		<h2>Последовательность Фибоначчи:</h1>
		<p>
			n = <?php echo $n; ?>.
			</br>
			<?php echo ArrayToString($sequences['fibonacci']); ?>			
		</p>
	</div>
	</body>
</html>