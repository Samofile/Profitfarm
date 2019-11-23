<?php

require "bd.php";

$id = $_POST['id'];

echo get_version_game($id);

?>