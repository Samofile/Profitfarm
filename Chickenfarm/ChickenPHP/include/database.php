<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
//
// Коннектимся к базе данных chickens.MySQL
//
$DBlink = new mysqli('localhost','g46869_evg','lhdp1HhY_3pcZ3fA','g46869_users');

if ($DBlink->connect_errno) {
    echo "Не удалось подключиться к MySQL: (" . $DBlink->connect_errno . ") " . $DBlink->connect_error;
}

?>