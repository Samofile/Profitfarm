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
    [SerializeField] InputField userName, userPassword;
    [SerializeField] Toggle check_box;

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

    //static string passwordHash;

    public void Init(bool start = false)
    {
        info.text = "Авторизация...";
        StartCoroutine(OnResponse(userName.text));
        return;
    }

    //private IEnumerator OnResponse(string playerName)
    public IEnumerator OnResponse(string playerName)
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerName", playerName);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/password.php", form);
        yield return req;
        string passwordHash = req.text;
        Debug.Log("Password hash: " + passwordHash);

        WWW req2 = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/secretkey.php", form);
        yield return req2;
        string secretKeyHash = req2.text;
        Debug.Log("Secretkey hash: " + secretKeyHash);

        string a = userPassword.text + ":" + secretKeyHash;
        string passHash = GetMd5Hash(a);
        Debug.Log("Hash-3: " + passHash);

        if (passHash == passwordHash) 
        {
            info.text = "Вход...";
        }
        else
        {
            info.text = "Неверный логин или пароль";
        }
    }

    public string GetMd5Hash(string input)
    {
        Debug.Log("Pin: " + input);
        byte[] hash = Encoding.ASCII.GetBytes(input);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] hashenc = md5.ComputeHash(hash);
        string result = "";
        foreach (var b in hashenc) {result += b.ToString("x2");}
        return result;
    }

    public void Register() // Регистрация нового пользователя
    {
        info.text = "Регистрация пользователя...";
        Application.OpenURL("http://регистрация.профитфарм.рф/");
        return;
    }

}