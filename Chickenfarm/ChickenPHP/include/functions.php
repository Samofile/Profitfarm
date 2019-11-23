<?php

include 'database.php';

if(isset($argv[1]) && isset($argv[2])){
	$_GET["fun"] = $argv[1];
	$_GET["user"] = $argv[2];
}

if(!isset($_GET["fun"])) exit;

if($_GET["fun"] == "eat"){
	if(isset($_GET["user"])){
		$res = set_eat($_GET["user"], 1);
	}
}elseif($_GET["fun"] == "drink"){
	if(isset($_GET["user"])){
		$res = set_drink($_GET["user"], 1);
	}
}elseif($_GET["fun"] == "clean"){
	if(isset($_GET["user"])){
		$res = set_clean($_GET["user"], 1);
	}
}elseif($_GET["fun"] == "get_eggs"){
	if(isset($_GET["user"])){
		$res = set_get_eggs($_GET["user"], 1);
	}
}elseif($_GET["fun"] == "sell_eggs"){
	if(isset($_GET["user"])){
		$res = set_sell_eggs($_GET["user"], 1);
	}
}

function set_eat($user, $value){
	global $DBlink;
	$result = $DBlink->query("UPDATE `chikens` SET `eat` = 1");
	return $result;
}

function set_drink($user, $value){
	global $DBlink;
	$result = $DBlink->query("UPDATE `chikens` SET `drink` = 1");
	return $result;
}

function set_clean($user, $value){
	global $DBlink;
	$result = $DBlink->query("UPDATE `chikens` SET `clean` = 1");
	return $result;
}

function set_get_eggs($user, $value){
	global $DBlink;
	$result = $DBlink->query("UPDATE `chikens` SET `get_eggs` = 1");
	return $result;
}

function set_sell_eggs($user, $value){
	global $DBlink;
	$result = $DBlink->query("UPDATE `chikens` SET `sale_eggs` = 1");
//	$result = $DBlink->query("UPDATE `chikens` SET `sale_eggs` = '".$value."' WHERE `id_user` = ".$user);
	return $result;
}
?>