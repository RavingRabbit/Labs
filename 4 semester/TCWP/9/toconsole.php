<?php	
	require("sequences.php");
	$sequences = array( 'geometric' => GeometricProgression(1, 2, 10), 'fibonacci' => FibonacciSequence(10));
	echo 'geometric: ';
	echo ArrayToString($sequences['geometric']);
	echo "\n\r";
	echo 'fibonacci: ';
	echo ArrayToString($sequences['fibonacci']);
?>