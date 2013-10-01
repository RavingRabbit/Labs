<?php
	$a = $_POST["a"];
	$b = $_POST["b"];
	$c = $_POST["c"];
?>
<?php
	function SolveQuadraticEquation($a, $b, $c)
	{
		$d = $b*$b - 4*$a*$c;
		if ($d < 0)
		{	
			echo 'корней нет, дискриминант меньше нуля';
		}
		elseif ($d == 0)
		{
			$x = -$b / (2*a);
			echo 'x<sub>1</sub> = x<sub>2</sub> = ' . $x;
		}
		else 
		{			
			$x1 = (-$b + sqrt($d)) / (2*$a);
			$x2 = (-$b - sqrt($d)) / (2*$a);
			echo 'x<sub>1</sub> = ' . $x1;
			echo ', x<sub>2</sub> = ' . $x2;
		}
	}	
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Квадратное уравнение</title>	
	</head>
	<body>
		<p>Квадратное уравнение: a = <?php echo $a; ?>, b = <?php echo $b; ?>, c = <?php echo $c; ?>.</p>
		<p>Решение уравнения: <?php SolveQuadraticEquation($a, $b, $c); ?>.</p>
	</body>
</html>