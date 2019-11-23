<?php

require "bd.php";

$id = $_POST['id'];

echo get_last_version($id);

?>