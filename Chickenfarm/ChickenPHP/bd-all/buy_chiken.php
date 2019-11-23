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
        else{
            $repeatf = get_user(trim($data['login']));
            if($repeatf != "no exist")
            { 
                if($repeatf->password == $data['password'])
                {
                    buy_chiken(trim($data['login']));
                    echo "Курица успешно куплена!";
                }
                else
                {
                    echo "Неверно введен логин или пароль! Пропробуйте еще раз";
                }
            }
            else
            {
                echo "Такого пользователя не существует! Пропробуйте снова";
            }
        }
    }
?>


<form action="/example-dom-vis.ru/bd-all/buy_chiken.php" method="POST">

    <p>
        <p><strong>Введите логин</strong>:</p>
        <input type="text" name="login">
    </p>

    <p>
        <p><strong>Введите пароль</strong>:</p>
        <input type="password" name="password">
    </p>

    <p>
        <button type="submit" name="do_signup">Купить еще одну курицу!</button>
    </p>

</form>