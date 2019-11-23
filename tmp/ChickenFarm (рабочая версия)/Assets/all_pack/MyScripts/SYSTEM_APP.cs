using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Text;

public class SYSTEM_APP : MonoBehaviour
{

    public enum MethodsOfParseBalance // Методы обработки баланса 
    {
        From_GetWithComma, // Метод замены запятой на точку, или наоборот
        From_StandartParse // Стандартный шарповкий метод перевода string в float 
    }

    /*[DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();*/

    public void EXIT_APP()
    {
        //ShowWindow(GetActiveWindow(), 2);
        //NormalizationForm.WindowState = FormWindowState.Minimized;
        Application.Quit();
    }
    [SerializeField] GameObject DARK_PANEL;

    [SerializeField] GameObject MAIN_PANEL;

    [SerializeField] Animator anims;

    //[SerializeField] SmoothFollow MouseLook;

    private bool go = false;

    private float balance;

    public MethodsOfParseBalance _mth = MethodsOfParseBalance.From_GetWithComma; // Попробуй разными

    [SerializeField] float speed;

    public IEnumerator start()
    {
        go = true;
        yield return new WaitForSeconds(1.2f);
        DARK_PANEL.SetActive(false);
        MAIN_PANEL.SetActive(true);

        yield return new WaitForSeconds(1.2f);
        anims.enabled = false;

    }

    public void OUT_MONEY() // Вывод средств, пока заглушка
    {
        Application.OpenURL("https://www.google.ru/");
    }

    [SerializeField] CharacterAI a_char; // Скрипт персонажа
    [SerializeField] robotAnimScript a_robot; // Скрипт робота

    public GameObject kal, egg; // Ведро

    public void SetDO_INDEX(int index) // Функция на которую вещаем кнопку
    {
        a_char.do_index = index;
        a_char.go = true;
        switch (index)
        {
            case 1:  // Поить
                {
                    StartCoroutine(SET_BUTTON("drink", "time_drink"));
                    BlockButton(true, "drink", 1);
                    balance -= 0.2f;
                    balance = (float)Math.Round(balance, 2);// отнимаем баланс
                    _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
                    a_char.go = true;
                    a_char.animator.SetBool("walk", true);
                    StartCoroutine(SET_BALANCE());
                    break;
                }
            case 2:  // Кормить
                {
                    StartCoroutine(SET_BUTTON("eat", "time_eat"));
                    BlockButton(true, "eat", 0);
                    balance -= 0.2f;
                    balance = (float)Math.Round(balance, 2);// отнимаем баланс
                    _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
                    a_char.go = true;
                    a_char.animator.SetBool("walk", true);
                    StartCoroutine(SET_BALANCE()); // говорим персонажу двигаться за обектом
                    break;
                }
            case 3:  // Убраться
                {
                    StartCoroutine(SET_BUTTON("clean", "time_clean"));
                    BlockButton(true, "clean", 2);
                    balance -= 0.2f;
                    balance = (float)Math.Round(balance, 2);// отнимаем баланс
                    _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
                    a_char.go = true;
                    a_char.animator.SetBool("walk", true);
                    StartCoroutine(SET_BALANCE()); // говорим персонажу двигаться за обектом
                    break;
                }
            case 4:  // Собрать яйца
                {
                    StartCoroutine(SET_BUTTON("get_eggs", "time_geteggs"));
                    BlockButton(true, "get_eggs", 4);
                    balance -= 0.2f;
                    balance = (float)Math.Round(balance, 2);// отнимаем баланс
                    _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
                    a_char.go = true;
                    a_char.animator.SetBool("walk", true);
                    StartCoroutine(SET_BALANCE()); // говорим персонажу двигаться за обектом
                    break;
                }
            case 5:  // Продать
                {
                    StartCoroutine(SET_BUTTON("sale_eggs", "time_selleggs"));
                    BlockButton(true, "sale_eggs", 3);
                    balance += 1.5f;
                    balance = (float)Math.Round(balance, 2);// отнимаем баланс
                    _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
                    a_char.go = true;
                    a_char.animator.SetBool("walk", true);
                    StartCoroutine(SET_BALANCE()); // говорим персонажу двигаться за обектом
                    break;
                }


        }

    }

    [SerializeField] Text _balance_text; // Текст баланса

    string p_name;

    string password;

    public void Init(bool start = false)
    {
        StartCoroutine(LoginUser(start));
        error.enabled = true;
        error.color = Color.white;
        error.text = "Загрузка...";
        return;
    }

    [SerializeField] InputField if_name, pass;

    [SerializeField] Text error;

    [SerializeField] GameObject START_PANEL;

    [SerializeField] Toggle check_box;

    [SerializeField] Animator buts, drk;

    [SerializeField] Text name_txt;

    public void BuyChiken()
    {
        Application.OpenURL("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/buy_chiken.php");
        return;
    }

    public IEnumerator REGISTER_CHIKS() // ОДНОКРАТНОЕ СОЗДАНИЕ ТАБЛИЦЫ КУРИЦ (НЕ ИСПОЛЬЗОВАТЬ БОЛЕЕ!!!) 
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/ch_reg.php", form);
        yield return www;
    }

    public void Registering()
    {
        Application.OpenURL("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/registration.php");
        return;
    }

    [SerializeField] Button[] buttons;
    [SerializeField] Image[] imgs;
    [SerializeField] Color col;
    [SerializeField] GameObject conn;

    public void AgainConnect()
    {
        // AGAIN!
    }

    public void NOT_A_CONNECTION()
    {
        conn.SetActive(true);
    }



    public void ReloadLevel()
    {
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("pass");
        SceneManager.LoadScene(0);
    }

    public IEnumerator SET_BUTTON(string jjname, string table)
    {
        /*WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        form.AddField("nameBut", jjname);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/set_button.php", form);
        yield return www;
        Debug.Log("is_loaded: " + www.text);
        if (www.error != null)
        {
            Debug.Log(www.error);
            NOT_A_CONNECTION();
        }
        */

        WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        form.AddField("Doname", jjname);
        form.AddField("Time", table);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/update_chiken.php", form);
        yield return www;
        Debug.Log(www.text);
    }

    private bool is_locked;

    public Color new_all;

    public void BlockButton(bool flock, string name, int index_button)
    {
        if (flock)
        {
            buttons[index_button].enabled = false;
            imgs[index_button].color = col;
        }
        else
        {
            buttons[index_button].enabled = true;
            imgs[index_button].color = new_all;
        }
    }

    public string[] do_name;




    public IEnumerator GET_BUTTINS()
    {
        for (int i = 0; i < 5; i++) // Макс кол-во куриц - 5, потом больше сделаем
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", p_name);
            form.AddField("Doname", do_name[i]);
            WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_buttons.php", form);
            yield return www;
            if (www.text == "1")
            {
                BlockButton(false, do_name[i], i);
                if (i == 2)
                {
                    kal.SetActive(true);
                }
                if (i == 4)
                {
                    egg.SetActive(true);
                }
            }
            else
            {
                BlockButton(true, do_name[i], i);
            }
            
        }
    }

    public GameObject[] Chikens;

    private int count_chikens;

    public IEnumerator GET_CHIKENS()
    {
        yield return new WaitForSeconds(1f);
        WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_chiken_count.php", form);
        yield return www;
        count_chikens = int.Parse(www.text);
        for (int x = 0; x < count_chikens; x++)
        {
              Chikens[x].SetActive(true);
              a_char.points[0] = Chikens[x].transform;
              a_char.points[1] = Chikens[x].transform;
        }
    }

    [SerializeField] GameObject ALL_INIT;

    public void DeleteSTART_INIT()
    {
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("pass");
    }

    public string vvv;

    public char[] ttt;

    string GetBalToString(string txt)
    {
        char[] nm = new char[txt.Length];
        char[] mass = txt.ToCharArray();
        char last = mass[(txt.Length - 1)];

        bool exist = false;

        for (int d = 0; d < (mass.Length - 1); d++)
        {
            if (mass[d] == ',' || mass[d] == '.')
            {
                exist = true;
            }
        }

        if (exist)
        {
            int last_ind = 0;
            for (int d = (txt.Length - 1); d > 0; d--)
            {
                if (mass[d] != ',' && mass[d] != '.')
                {
                    last_ind++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < txt.Length; i++)
            {
                if (mass[i] != ',' && mass[i] != '.')
                {
                    nm[i] = mass[i];
                }
                else
                {
                    nm[i] = '.';
                    for (int f = (mass.Length - last_ind); f > i; f--)
                        nm[f] = mass[f];
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(nm);
            string v = sb.ToString();
            ttt = nm;
            return v;
        }
        else
        {
            ttt = nm;
            return txt;
        }
    }

    float GetBalToFloat(string txt) // Метод замены запятой на точку, для последующего перевода в float (в бд запись идет именно с запятой)
    {
        char[] nm = new char[txt.Length];
        char[] mass = txt.ToCharArray();
        char last = mass[(txt.Length - 1)];

        bool exist = false;

        for (int d = 0; d < (mass.Length - 1); d++)
        {
            if (mass[d] == ',' || mass[d] == '.')
            {
                exist = true;
                Debug.Log("TRUE");
            }
        }

        if (exist)
        {
            int last_ind = 0;
            for (int d = (txt.Length - 1); d > 0; d--)
            {
                if (mass[d] != ',' && mass[d] != '.')
                {
                    last_ind++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < txt.Length; i++)
            {
                if (mass[i] != ',' && mass[i] != '.')
                {
                    nm[i] = mass[i];
                }
                else
                {
                    nm[i] = ',';
                    for (int f = (mass.Length - last_ind); f > i; f--)
                        nm[f] = mass[f];
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(nm);
            string v = sb.ToString();
            ttt = nm;
            return float.Parse(v);
        }
        else
        {
            ttt = nm;
            return float.Parse(txt);
        }
    }

    public IEnumerator UpdateDataBase()// Проверка значений базы данных на наличие 1 
    {
        while (true)
        {
            yield return new WaitForSeconds(0.85f); // Обновление каждые 0.85 сек
            StartCoroutine(GET_BUTTINS());
        }
    }

    public IEnumerator UpdateChikensCount()// Проверка значений базы данных на наличие 1 
    {
        while (true)
        {
            StartCoroutine(GET_CHIKENS());
            yield return new WaitForSeconds(2f); // Обновление каждые 2 сек
        }
    }

    private string ref_code;

    public Text ref_text;

    private string new_ref_code;

    public GameObject u_out;

    public GameObject is_exist; 

    public void Go_Ref()
    {
        StartCoroutine(SAVE_REFERRAL_CODE());
    }

    public Text inputText;

    public IEnumerator SAVE_REFERRAL_CODE()
    {
        new_ref_code = inputText.text;

        if (ref_code != new_ref_code && new_ref_code != "")
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", p_name);
            form.AddField("Code", new_ref_code);
            WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/set_refcode.php", form);
            yield return www;
            if(www.text == "is exist")
            {
                is_exist.SetActive(true);
                yield return new WaitForSeconds(2f);
                is_exist.SetActive(false);
                yield break;
            }
            else
            {
                u_out.SetActive(false);
            }
        }
        else
        {
            Debug.Log("<<<<");
            u_out.SetActive(false);
        }
    }

    public IEnumerator GET_REFERRAL_CODE()
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_refcode.php", form);
        yield return www;
        ref_code = www.text;
        if(ref_code == "")
        {
            ref_text.text = "Не установлен";
        }
        else
        {
            ref_text.text = ref_code;
            new_ref_code = ref_code;
        }
        yield break;
    }

    public IEnumerator GET_BALANCE()
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_balance.php", form);
        yield return www;
        if (_mth == MethodsOfParseBalance.From_GetWithComma)
        {
            balance = GetBalToFloat(www.text);
        }else if(_mth == MethodsOfParseBalance.From_StandartParse)
        {
            balance = float.Parse(www.text);
        }
        _balance_text.text = "Баланс: " + balance.ToString(); // Присвоению тексту значения из переменной balance
        if (_balance_text.text == "")
        {
            StartCoroutine(GET_BALANCE());
        }
        yield break;
    }

    public IEnumerator SET_BALANCE()
    {
        string output = GetBalToString(balance.ToString());

        WWWForm form = new WWWForm();
        form.AddField("Name", p_name);
        form.AddField("Balance", output);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/set_balance.php", form);
        yield return www;
        yield break;
    }

    public IEnumerator LoginUser(bool start = false)
    {
        if (!start)
        {
            p_name = if_name.text;
            password = pass.text;
        }
        else
        {
            init = true;
            p_name = PlayerPrefs.GetString("name");
            password = PlayerPrefs.GetString("pass");
            Debug.Log("NM: " + p_name);
            Debug.Log("PAS:" + password);
        }
        if (p_name != "" && password != "")
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", p_name);
            WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/login.php", form);
            yield return www;

            if (www.error != null)
            {
                Debug.Log(www.error);
                error.enabled = true;
                error.color = Color.red;
                error.text = "Не удалось подключиться к интернету!";
                yield return new WaitForSeconds(3f);
                error.enabled = false;
                Debug.Log(www.text + "LOG");
                yield break;
            }
            else
            {
                string pps = www.text;
                Debug.Log("Password:" + www.text);
                if (www.text == "")
                {
                    error.enabled = true;
                    error.color = Color.red;
                    error.text = "Неправильно введен пароль или логин!";
                    yield return new WaitForSeconds(3f);
                    error.enabled = false;
                    //init = false;
                }
                else if (password == pps)
                {
                    error.enabled = true;
                    error.color = Color.white;
                    error.text = "Вход...";
                    is_logined = true;
                    name_txt.text = "Игрок: " + p_name;
                    if (check_box.isOn)
                    {
                        PlayerPrefs.SetString("name", p_name);
                        PlayerPrefs.SetString("pass", password);
                        PlayerPrefs.Save();
                    }
                    dr_go = true;
                    init = false;
                }
                else
                {
                    error.enabled = true;
                    error.color = Color.red;
                    error.text = "Неправильно введен пароль или логин!";
                    yield return new WaitForSeconds(3f);
                    error.enabled = false;
                    //init = false;
                }
            }
        }
        else
        {
            error.enabled = true;
            error.color = Color.red;
            error.text = "Неправильно введен пароль или логин!";
            yield return new WaitForSeconds(3f);
            error.enabled = false;
        }
        if (is_logined)
        {
            StartCoroutine(GET_BALANCE());
            StartCoroutine(GET_BUTTINS());
            StartCoroutine(UpdateChikensCount());
            StartCoroutine(UpdateDataBase());
            StartCoroutine(GET_REFERRAL_CODE());
            aenableUPDPacks.GoUpdate();
        }
        yield break;
    }

    private float t;

    public EnableUPDPacks aenableUPDPacks;

    private bool init;

    public float pseudo_balance;

    void Update()
    {
       
        if (init)
        {
            t += Time.deltaTime;
            if (t >= 6f)
            {
                ReloadLevel();

            }
            Debug.Log("cc" + t.ToString());
        }

        // AndroidNotification.IS_DEVELOPING = dev.isOn; // Чуток изменил плагин, проверку на разработчика туда вставил и пульнул уведомления по циклу

        if (dr_go == true)
        {
            if (Chikens[0].activeSelf == true)
            {
                Go();
                START_PANEL.SetActive(false);
                dr_go = false;
            }
        }
    }

    private bool dr_go;

    /*public IEnumerator RegisterUser()
    {
        p_name = if_name.text;
        password = pass.text;
        if (p_name != "" && password != "")
        {
            WWWForm form = new WWWForm();
            form.AddField("Name", p_name);
            form.AddField("Pass", password);
            WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/index.php", form);
            yield return www;
            if (www.error != null)
            {
                Debug.Log(www.error);
                error.enabled = true;
                error.color = Color.red;
                error.text = "Не удалось подключиться к интернету!";
                yield return new WaitForSeconds(3f);
                error.enabled = false;
                yield break;
            }
            else
            {
                if(www.text == "is exist")
                {
                    error.enabled = true;
                    error.color = Color.red;
                    error.text = "Пользователь с таким именем уже существует!";
                    yield return new WaitForSeconds(3f);
                    error.enabled = false;
                }
                if(www.text == "REGISTRATION")
                {
                    error.enabled = true;
                    error.color = Color.white;
                    error.text = "Пользователь успешно зарегистрирован!";
                    yield return new WaitForSeconds(3f);
                    error.enabled = false;
                }
            }
        }
        else
        {
            error.enabled = true;
            error.color = Color.red;
            error.text = "Неправильно введен пароль или логин!";
            yield return new WaitForSeconds(3f);
            error.enabled = false;
        }
    }*/

    bool is_logined;

    public void Go()
    {
        StartCoroutine(start());
        SEND_NOTIFICATION(); // Запускаем уведомление по счетчику
        buts.enabled = true;
        drk.enabled = true;
    }

    [SerializeField] RectTransform welcome;

    void Awake()
    {
        Chikens = GameObject.FindGameObjectsWithTag("chicken");
        for(int i = 0; i < Chikens.Length; i++)
        {
            //Chikens[i].GetComponent<chick>().anim.enabled = false;
            Chikens[i].SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            BlockButton(true, do_name[i], i);
        }

        //imgs[6].color = Color.blue;
        if (PlayerPrefs.HasKey("name"))
        {
            Init(true);
            Debug.Log("GO_START");
            ALL_INIT.SetActive(false);
            welcome.localPosition = new Vector3(0, 25f, 0);
            welcome.GetComponent<Text>().fontSize = 30;
        }
    }

    [SerializeField] float a;

    private int hours, minutes; // Системное время

    int state_time; // индекс позволяющий определить то время которое ближе

    [SerializeField] Toggle dev; // Кнопка в меню вывода денег (режим разработчика)

    public void SEND_NOTIFICATION()
    {
        Debug.Log("SEND_NOTIFICATION");
        //AndroidNotification.SendNotification(100, 15, "Вы давно не заходили", "Соберите яйца чтобы их продать", "Курица снесла яйца!", Color.white, false, AndroidNotification.NotificationExecuteMode.Inexact, true, 1, false, 0, 0);
    }

    /* public IEnumerator CORE(int time)
     {
         yield return new WaitForSeconds(time);
         SEND_NOTIFICATION();
     }*/


}

