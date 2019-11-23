<?php

require 'bd.php';

$name = $_POST['Name'];
$pass = $_POST['Pass'];

echo register_user($name, $pass);

?>