<?php 
	function ArrayToString($arr, $index = 0)
	{
		if (count($arr) - 1 != $index)
			$result = arrayToString($arr, $index + 1);
		return '[' . $index . ']' . $arr[$index] . '   ' . $result ;
	}
	
	function GeometricProgression($b0, $q, $n)
	{
		$geometric = array();
		$bn = $b0;
		for ($i = 0; $i < $n; $i++)
		{
			$geometric[$i] = $bn;
			$bn *= $q;
		}
		return $geometric;
	}
	
	function FibonacciSequence($n)
	{
		$fibonacci = array(1, 1);
		for ($i = 2; $i < $n; $i++)
			$fibonacci[$i] = $fibonacci[$i-1]+$fibonacci[$i-2];
		return $fibonacci;
	}	
?>