using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Text;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class Login : MonoBehaviour
{
    [SerializeField] Text info;
    [SerializeField] InputField if_name, pass;
    [SerializeField] GameObject START_PANEL;
    [SerializeField] Toggle check_box;
    [SerializeField] Animator buts, drk;
    [SerializeField] Text name_txt;

    string name;
    string password;
    private bool init;
    bool is_logined;

    // Start is called before the first frame update
    void Start()
    {
        info.text = "Добро пожаловать";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndEdit()
    {
        Debug.Log(2);

    }

    public void Init(bool start = false)
    {
        StartCoroutine(LoginUser(start));
        info.text = "Авторизация...";
        string pasHash = GetMd5Hash("9196:5dd7d878554fd");
        return;
    }

    public string GetMd5Hash(string input)
    {
        byte[] hash = Encoding.ASCII.GetBytes(input);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] hashenc = md5.ComputeHash(hash);
        string result = "";
        foreach (var b in hashenc) {result += b.ToString("x2");}
        Debug.Log("Hash: " + result);
        return result;
    }

/*
    public IEnumerator LoginUser(bool start = false)
    {
        Debug.Log("login: " + start);
        //Debug.Log("Hash: " + GetMd5Hash("Hash"));
                                                                                                            if (!start)
                                                                                                            {
                                                                                                                name = if_name.text;
                                                                                                                password = pass.text;

                                                                                                                //name = "zzz";
                                                                                                                //password = "zzz";
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                init = true;
                                                                                                                name = PlayerPrefs.GetString("name");
                                                                                                                password = PlayerPrefs.GetString("pass");
                                                                                                                Debug.Log("NM: " + name);
                                                                                                                Debug.Log("PAS:" + password);
                                                                                                            }

        Debug.Log("login: " + name);
        Debug.Log("password: " + password);

        if (name != "" && password != "")
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", name);
            WWW www = new WWW("http://инвестор.профитфарм.рф/login.php", form);
            Debug.Log("Login-php вернул: " + www.text);
            yield return www;

            if (www.error != null)
            {
                Debug.Log(www.error);
                info.enabled = true;
                info.color = Color.red;
                info.text = "Не удалось подключиться к интернету!";
                yield return new WaitForSeconds(3f);
                info.enabled = false;
                Debug.Log(www.text + "LOG");
                yield break;
            }
            else
            {
                string pps = www.text;
                Debug.Log("Password:" + www.text);
                Debug.Log(password);
                //Debug.Log(pps);
                if (www.text == "")
                {
                    info.enabled = true;
                    info.color = Color.red;
                    info.text = "1-Неправильно введен пароль или логин!";
                    yield return new WaitForSeconds(3f);
                    info.enabled = false;
                    //init = false;
                }
                else if (password == pps)
                {
                    info.enabled = true;
                    info.color = Color.white;
                    info.text = "Вход...";
                    is_logined = true;
                    //name_txt.text = "Игрок: " + name + count_chikens;
                    if (check_box.isOn)
                    {
                        PlayerPrefs.SetString("name", name);
                        PlayerPrefs.SetString("pass", password);
                        PlayerPrefs.Save();
                    }
                    //dr_go = true;
                    init = false;
                }
                else
                {
                    info.enabled = true;
                    info.color = Color.red;
                    info.text = "2-Неправильно введен пароль или логин!";
                    yield return new WaitForSeconds(3f);
                    info.enabled = false;
                    //init = false;
                }
            }
        }
        else
        {
            info.enabled = true;
            info.color = Color.red;
            info.text = "3-Неправильно введен пароль или логин!";
            yield return new WaitForSeconds(3f);
            info.enabled = false;
        }

        if (is_logined)
        {
            //StartCoroutine(GET_BALANCE());
            //StartCoroutine(GET_BUTTINS());
            //StartCoroutine(UpdateChikensCount());
            //StartCoroutine(UpdateDataBase());
            //StartCoroutine(GET_REFERRAL_CODE());
            //aenableUPDPacks.GoUpdate();
        }
        yield break;
    }
*/



    public IEnumerator LoginUser(bool start = false)
    {
        Debug.Log("login: " + start);
        // Получает хэш пин-кода из БД по полю name
        // Сравнивает хэш пин-кода и вычисленный хэш из пароля+secretkey
        // если ок - грузит следующую сцену

    }


    public void Register() // Регистрация нового пользователя
    {
        Application.OpenURL("http://регистрация.профитфарм.рф/");
        info.text = "Регистрация пользователя...";
        return;
    }




}

