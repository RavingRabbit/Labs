<?php
	$b0 = $_POST["initvalue"];
	$q = -1.5;
	$n = 50;
?>
<?php
	function PrintGeometricProgression($b0, $q, $n)
	{
		$bn = $b0;
		for ($i = 0; $i < $n; $i++)
		{
			echo $bn . ' ';
			$bn *= $q;
		}
	}
	
	function CalculateGeometricProgression($b0, $q, $n)
	{
		return $b0*(pow($q, $n) - 1)/($q-1);
	}
	
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Геометрическая прогресия</title>	
	</head>
	<body>
		<p>Геометрическая прогрессия: b<sub>0</sub> = <?php echo $b0; ?>, q = <?php echo $q; ?>.</p>
		<p>Первые <?php echo $n; ?> членов прогрессии: <?php PrintGeometricProgression($b0, $q, $n); ?>.</p>
		<p>Сумма первых <?php echo $n; ?> членов прогрессии: <?php echo CalculateGeometricProgression($b0, $q, $n); ?>.</p>
	</body>
</html>