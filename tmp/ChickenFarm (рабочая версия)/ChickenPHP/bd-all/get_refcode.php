<?php

require "bd.php";

$name = $_POST['Name'];

echo get_user($name)->referral_code;

?>