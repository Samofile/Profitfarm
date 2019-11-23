<?php

require "bd.php";

$name = $_POST['Name'];
$do_name = $_POST['Doname'];

echo get_buttons($name, $do_name);

?>