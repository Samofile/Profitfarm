<?php

require 'rb-mysql.php';

R::setup('mysql:host=localhost;dbname=g46869_users',
		'g46869_evg', 'lhdp1HhY_3pcZ3fA');

if(!R::testConnection())
{
	echo "error2222";
	exit;
}

function set_balance($balance, $name)
{
	$user = R::findOne('users', 'name = ?', array($name));
	if(isset($user))
	{
		$user->balance = $balance;
		R::store($user);
	}
}

function find_refferal_code($code, $name)
{
	$c_user = R::findOne('users', 'refferal_code = ?', array($code));
	if(isset($c_user))
	{
		if($code != "")
		{
			return "is exist";
		}
	}
	else
	{
		$user = R::findOne('users', 'name = ?', array($name));
		if(isset($user))
		{
			$user->referral_code = $code;
			R::store($user);
		}
	}
}

function set_chiken($name, $do_name, $time_go)
{
	$chikens = R::find('chikens','player_name = ?', array($name));
	foreach($chikens as $chiken)
	{
		if(isset($chiken))
		{
			if($chiken->$do_name == 1)
			{
				date_default_timezone_set('Russia/Moscow');
				$times = date('m/d/Y h:i:s a', time());
				$chiken->$time_go = $times;
				$chiken->$do_name = 0;
				R::store($chiken);
			}
		}
	}

}


function set_button($but, $name)
{
	$user = R::findOne('users', 'name = ?', array($name));
	if(isset($user))
	{
		$user->$but = true;
		R::store($user);
	}
}

function get_cache($id){
	$cache = R::findOne('common','id = ?', array($id));
	return $cache->cache_version;
}

function get_version_game($id){
	$lastt = R::findOne('common','id = ?', array($id));
	return $lastt->game_version;
}

function global_update($value, $id)
{
	if($value == 1){
		$lastt = R::findOne('common','id = ?', array($id));
		$s = ($lastt->game_version + 1);
		$lastt->game_version = $s;
		R::store($lastt);
	}
	else{
		$lastt = R::findOne('common','id = ?', array($id));
		$s = ($lastt->game_version - 1);
		
		if($s == 0)
		{
			$lastt->game_version = 1;
		}
		else
		{
			$lastt->game_version = $s;
		}
		R::store($lastt);
	}
}

function get_last_version($id){
	$lastt = R::findOne('common','id = ?', array($id));
	return $lastt->last_version;
}

function get_count_models($id){
	$lastt = R::findOne('common','id = ?', array($id));
	return $lastt->count_of_models;
}

function get_count_prefabs($id){
	$lastt = R::findOne('common','id = ?', array($id));
	return $lastt->count_of_prefabs;
}

function buy_chiken($name)
{
	$repeatf = R::findOne('users', 'name = ?', array($name));
	if(isset($repeatf))
	{
		$date_n = $repeatf->count_chickens;
		$date_n = ($date_n + 1);
		$repeatf->count_chickens = $date_n;
		R::store($repeatf);
		$chikens = R::dispense('chikens');
		$chikens->id_user = $repeatf->id;
		$chikens->player_name = $repeatf->name;
		date_default_timezone_set('Russia/Moscow');
		$times = date('m/d/Y h:i:s a', time());
		$chikens->run_chicken = $times;
		$chikens->eat = 1;
		$chikens->drink = 1;
		$chikens->clean = 1;
		$chikens->get_eggs = 1;
		$chikens->sale_eggs = 1;
		R::store($chikens);
	}
}

function get_buttons($name, $do_name){
	$chikens = R::find('chikens','player_name = ?', array($name));
	foreach($chikens as $chiken)
	{
		if(isset($chiken))
		{
			if($chiken->$do_name == 1)
			{
				return "1";
			}
		}
	}
}

function find_refer($code, $login)
{
	$user = R::findOne('users', 'referral_code = ?', array($code));
	if(isset($user)) 
	{
		$new = $user->count_refers;
		$new = ($new + 1);
		$user->count_refers = $new;
		R::store($user);
		$ref = R::dispense('refers');
		$ref->name = $login;
		$ref->his_referral = $user->name;
		R::store($ref);
		return "user is exist";
	}
}

function find_user_from_code($code)
{
	$user = R::findOne('users', 'referral_code = ?', array($code));
	if(isset($user)) 
	{
		return $user;
	}
}

function register_user($name, $password){
	$repeatf = R::findOne('users', 'name = ?', array($name));
	if(isset($repeatf)) return "is exist";
	$user = R::dispense('users');
	$user->name = $name;
	$user->password = $password;
	$user->balance = "300";
	$user->global_update = 1;
	date_default_timezone_set('Russia/Moscow');
	$date = date('m/d/Y h:i:s a', time());
	$user->runApp = $date;
	$user->count_chickens = 1;
	R::store($user);
	$chikens = R::dispense('chikens');
	$chikens->id_user = $user->id;
	$chikens->player_name = $user->name;
	$chikens->run_chicken = $date;
	$chikens->eat = 1;
	$chikens->drink = 1;
	$chikens->clean = 1;
	$chikens->get_eggs = 1;
	$chikens->sale_eggs = 1;
	R::store($chikens);
	return "REGISTRATION";
}

function start_app($name)
{
	$repeatf = R::findOne('users', 'name = ?', array($name));
	if(isset($repeatf))
	{
		date_default_timezone_set('Russia/Moscow');
		$date = date('m/d/Y h:i:s a', time());
		$repeatf->runApp = $date;
		R::store($repeatf);
	}
}

function get_user($name){
	$user = R::findOne('users', 'name = ?', array($name));
	if(!isset($user)) return "no exist";
	return $user;
}


?>