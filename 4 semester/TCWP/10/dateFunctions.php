<?php
    date_default_timezone_set("Europe/Minsk");
	function DateNow()
	{
		return date("d-m-y");
	}
	
	function DateTimeNow()
	{
		return date("d-m-y H:i:s");
	}
	
	function BirthDate()
	{
		require_once("dates.php");
		return date("d-m-y", mktime(0, 0, 0, BITHDAY_MONTH, BITHDAY_DAY , BITHDAY_YEAR));
	}
	
	function DaysLeftBeforeBirthDate()
	{
		require_once("dates.php");
		$inNextYear =  (int)((mktime(0,0,0,BITHDAY_MONTH,BITHDAY_DAY,date('Y')+1) - mktime()) / 86400);
		$inThisYear = (int)((mktime(0,0,0,BITHDAY_MONTH,BITHDAY_DAY,date('Y')) - mktime()) / 86400);
		if ($inThisYear < 0)
			return $inNextYear;
		else
			return $inThisYear;
	}
	
	function PassedAfterBithDate()
	{
		$passed =  mktime() - mktime(0,0,0,BITHDAY_MONTH,BITHDAY_DAY,BITHDAY_YEAR);
		return Array((int)($passed / (365*24*60*60)),(int)($passed / (30*24*60*60)),(int)($passed / (7*24*60*60)),(int)($passed / (24*60*60)),(int)($passed / (60*60)),(int)($passed / (60)));
	}	
?>