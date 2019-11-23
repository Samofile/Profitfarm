<?php

require "bd.php";

$name = $_POST['Name'];

echo get_user($name)->balance;
start_app($name);
?>