<?php
$server = 'localhost'; 
$username = 'root'; 
$password = '';
$dbname = 'SelCom';

$link = mysql_connect($server, $username, $password);
mysql_query("SET NAMES UTF8");

if($link)
{
	//echo "<p>Соединение с БД прошло успешно..";
}
if (!$link) 
{
    die('Невозможно соединиться с базой данных: ' . mysql_error());
}

$db_selected = mysql_select_db($dbname);

if (!$db_selected) 
{
    die ('Невозможно выбрать базу данных: ' . mysql_error());
}
?>