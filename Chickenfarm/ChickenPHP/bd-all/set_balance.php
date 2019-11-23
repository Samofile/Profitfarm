<?php

require "bd.php";

$name = $_POST['Name'];
$balance = $_POST['Balance'];
set_balance($balance, $name);

?>