<?php

require "bd.php";

$value = $_POST['value'];
$id = $_POST['id'];

global_update($value, $id);

?>