using System.Collections;
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

    void Start()
    {
        a = Login.staticPlayerPhone;
        Debug.Log("Статик playerPhone: " + a);
        //GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>().text = a.ToString();
        //playerName = GameObject.FindGameObjectWithTag("PlayerName");
        //playerName.GetComponent<Text>().text = a.ToString();
        playerName.text = a.ToString();
        //actionButtons = GameObject.Find("ActionButtons");
        actionPanel.active = false;
    }

    private IEnumerator GetBalance(float value)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerPhone", Login.staticPlayerPhone);
        WWW req = new WWW("http://xn--80ajvps.xn--80apnfegdoqc.xn--p1ai/balance.php", form);
        yield return new WaitForSeconds(value);
        Debug.Log("Balance: " + req.text);
        balanceText.text = req.text;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetBalance(5f));
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    
    public void Withdrow()
    {
        Application.OpenURL("http://xn--b1aghuhmfi.xn--80apnfegdoqc.xn--p1ai/");
    }
}
