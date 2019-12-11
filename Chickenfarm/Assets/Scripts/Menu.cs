﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject water, eat, clean, take, sell;
    string a = "Untitle";
    [SerializeField] Text playerName;
    [SerializeField] GameObject actionPanel;
    [SerializeField] Text balanceText;
    [SerializeField] Text chickenCount;
    [SerializeField] Text eggCount;

    public GameObject[] clearObj;
    public GameObject[] eggsObj;
    public static string staticChickenCount;
    public static string staticEggCount;
    public static bool doDrink = false;

    void Start()
    {
        a = Login.staticPlayerPhone;
        playerName.text = a.ToString();
        actionPanel.active = false;

        StartCoroutine(GetBalance(2f));
        StartCoroutine(GetChickenCount(2f));
        StartCoroutine(GetEggCount(1f));
    }

    void Update()
    {
 
    }

    private IEnumerator GetBalance(float value)
    {
        while (true)
        {
        yield return new WaitForSeconds(2f);
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/balance.php", form);
        yield return new WaitForSeconds(value);
        balanceText.text = req.text;
        //Debug.Log("Balance: " + req.text);
        }
    }

    private IEnumerator GetChickenCount(float value)
    {
        while (true)
        {
        yield return new WaitForSeconds(3f);
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/chickenscount.php", form);
        yield return new WaitForSeconds(value);
        chickenCount.text = req.text;
        staticChickenCount = req.text;
        //Debug.Log("staticChickenCount-1: " + staticChickenCount);
        //Debug.Log("Chicken Count: " + req.text);
        }
    }

    private IEnumerator GetEggCount(float value)
    {
        while (true)
        {
        yield return new WaitForSeconds(3f);
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/eggscount.php", form);
        yield return new WaitForSeconds(value);
        eggCount.text = req.text;
        staticEggCount = req.text;
        //Debug.Log("staticEggCount: " + staticEggCount);
        }
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    
    public void Withdrow()
    {
        Application.OpenURL("http://xn--b1aghuhmfi.xn--80apnfegdoqc.xn--p1ai/");
    }

    public void SellScene()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/eggssell.php", form);
        Application.LoadLevel(2);
    }

    public void ClearAll()
    {
        clearObj = GameObject.FindGameObjectsWithTag("Stuff");
        Debug.Log("Stuff weight: " + clearObj.Length);
        for(int i = 0; i < clearObj.Length; i++)
        {
            //Chikens[i].GetComponent<chick>().anim.enabled = false;
            //Chikens[i].SetActive(true);
            Destroy(clearObj[i],0); // Удаление объекта с задержкой
        }
    }

    public void TakeEggs()
    {
        eggsObj = GameObject.FindGameObjectsWithTag("Egg");
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/eggstake.php", form);
        Debug.Log("Egg count: " + eggsObj.Length);
        /*for(int i = 0; i < eggsObj.Length; i++)
        {
            Destroy(eggsObj[i],0); // Удаление объекта с задержкой
            //Chikens[i].GetComponent<chick>().anim.enabled = false;
            //Chikens[i].SetActive(true);
        }*/
        staticEggCount = "0";
    }

    public void DoDrink()
    {
        //eggsObj = GameObject.FindGameObjectsWithTag("Egg");
        //WWWForm form = new WWWForm();
        //form.AddField("playerPhone", Login.staticPlayerPhone);
        //WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/eggstake.php", form);
        //Debug.Log("Egg count: " + eggsObj.Length);
        /*for(int i = 0; i < eggsObj.Length; i++)
        {
            Destroy(eggsObj[i],0); // Удаление объекта с задержкой
            //Chikens[i].GetComponent<chick>().anim.enabled = false;
            //Chikens[i].SetActive(true);
        }*/
        //staticEggCount = "0";
        doDrink = !doDrink;
        Debug.Log("Drink action");
    }
}