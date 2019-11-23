<?php

require "bd.php";

$name = $_POST['Name'];
$code = $_POST['Code'];

echo find_refferal_code($code, $name);

?>