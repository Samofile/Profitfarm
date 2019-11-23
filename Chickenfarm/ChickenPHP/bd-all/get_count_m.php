<?php

require "bd.php";

$id = $_POST['id'];

echo get_count_models($id);

?>