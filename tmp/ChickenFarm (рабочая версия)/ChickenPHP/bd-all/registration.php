<?php
    require "bd.php";

    $data = $_POST;
    if(isset($data['do_signup']))
    {
        if(trim($data['login']) == '')
        {
            echo "Вы не ввели логин";
        }
        elseif(trim($data['password']) == '')
        {
            echo "Вы не ввели пароль";
        }
        elseif(trim($data['password']) != trim($data['password2']))
        {
            echo "Пароли не совпадают";
        }else{
            $repeatf = get_user(trim($data['login']));
            if($repeatf != "no exist")
            { 
                echo "Пользователь с таким именем уже зарегистрирован";
            }
            else
            {
                if(trim($data['refer']) != "")
                {
                    $i = find_refer($data['refer'], trim($data['login']));
                    if($i == "user is exist")
                    {
                        register_user($data['login'], $data['password'], $data['refer']);
                        echo "Пользователь успешно зарегистрирован!";
                    }else{
                        echo "Пользователя с таким реферальным кодом не найдено!";
                    }
                }else
                {
                    register_user($data['login'], $data['password']);
                     echo "Пользователь успешно зарегистрирован!";
                }
            }
        }
    }
?>

<form action="/example-dom-vis.ru/bd-all/registration.php" method="POST">

    <p>
        <p><strong>Придумайте логин</strong>:</p>
        <input type="text" name="login">
    </p>

    <p>
        <p><strong>Придумайте пароль</strong>:</p>
        <input type="password" name="password">
    </p>

    <p>
        <p><strong>Повторите пароль</strong>:</p>
        <input type="password" name="password2">
    </p>

    <p>
        <p><strong>Реферальный код (Необязательное поле)</strong>:</p>
        <input type="text" name="refer">
    </p>

    <p>
        <button type="submit" name="do_signup">Зарегистрироваться</button>
    </p>

</form>
