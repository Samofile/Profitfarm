<?php

require "bd.php";

$named = $_POST['Name'];
$butd = $_POST['nameBut'];
set_button($butd, $named);

?>