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
    [SerializeField] InputField userPhone, userPassword;
    [SerializeField] Toggle checkBox;
    public static string staticPlayerPhone;

    void Start()
    {
        info.text = "Введите номер телефона и пин-код";
        userPhone.ActivateInputField();
    }

    public void Init(bool start = false)
    {
        info.text = "Авторизация...";
        staticPlayerPhone = userPhone.text;
        StartCoroutine(OnResponse(userPhone.text));
        return;
    }

    public IEnumerator OnResponse(string playerPhone)
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerPhone", playerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/password.php", form);
        yield return req;
        string passwordHash = req.text;
        //Debug.Log("Password hash: " + passwordHash);

        WWW req2 = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/secretkey.php", form);
        yield return req2;
        string secretKeyHash = req2.text;
        //Debug.Log("Secretkey hash: " + secretKeyHash);

        string a = userPassword.text + ":" + secretKeyHash;
        string passHash = GetMd5Hash(a);
        //Debug.Log("Hash-3: " + passHash);

        if (passHash == passwordHash) 
        {
            info.text = "Вход...";
            SceneManager.LoadScene(1);
        }
        else
        {
            info.text = "Неверный логин или пароль";
            userPhone.ActivateInputField();
        }
    }

    public string GetMd5Hash(string input)
    {
        //Debug.Log("Pin: " + input);
        byte[] hash = Encoding.ASCII.GetBytes(input);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] hashenc = md5.ComputeHash(hash);
        string result = "";
        foreach (var b in hashenc) {result += b.ToString("x2");}
        return result;
    }

    public void Register()
    {
        info.text = "Регистрация игрока...";
        Application.OpenURL("http://xn--80affnb7bdhj6b9f.xn--80apnfegdoqc.xn--p1ai/");
        return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            userPassword.ActivateInputField();
        }
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            Init();
        }
 
    }

}