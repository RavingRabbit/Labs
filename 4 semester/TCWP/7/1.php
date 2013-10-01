<?php
	$a0 = $_POST["initvalue"];
	$d = 15;
	$n = 50;
?>
<?php
	function PrintArithmeticProgression($a0, $d, $n)
	{
		$an = $a0;
		for ($i = 0; $i < $n; $i++)
		{
			echo $an . ' ';
			$an += $d;
		}
	}
	
	function CalculateArithmeticProgression($a0, $d, $n)
	{
		return ($n/2) * (2*a0+($n-1)*$d);
	}
	
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Арифетическая прогресия</title>	
	</head>
	<body>
		<p>Арифметическая прогрессия: a<sub>0</sub> = <?php echo $a0; ?>, d = <?php echo $d; ?>.</p>
		<p>Первые <?php echo $n; ?> членов прогрессии: <?php PrintArithmeticProgression($a0, $d, $n); ?>.</p>
		<p>Сумма первых <?php echo $n; ?> членов прогрессии: <?php echo CalculateArithmeticProgression($a0, $d, $n); ?>.</p>
	</body>
</html>