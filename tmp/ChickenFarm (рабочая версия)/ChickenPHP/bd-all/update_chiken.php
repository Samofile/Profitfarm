<?php

require "bd.php";

$name = $_POST['Name'];
$do_name = $_POST['Doname'];
$time_go = $_POST['Time'];

echo set_chiken($name, $do_name, $time_go); 
?>