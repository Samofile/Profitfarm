<?php

require 'rb-mysql.php';

R::selectDatabase('DB1');

if(!R::testConnection())
{
	echo "error_ch";
	exit;
}


function register_chiks(){
    for ($i = 0; $i < 2000; $i++) {
    $user = R::dispense('chikens');
	$user->dinamic_name = "";
	$user->startApp = "";
    $user->runApp = "";
    $user->eat = false;
    $user->drink = false;
    $user->cleaning = false;
    $user->sale_eggs = false;
    $user->get_eggs = false;
    R::store($user);
    }
}


function get_chiken($name, $runApp){
    echo "IS FINDED!";
	$user = R::findOne('chikens','dinamic_name = ?', array($name));
    if(isset($user))
    {
        
        $user->runApp = $runApp;
        R::store($user);
    }
}


?>