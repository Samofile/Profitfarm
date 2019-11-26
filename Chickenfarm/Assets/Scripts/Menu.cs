using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject water, eat, clean, take, sell;
    //public GameObject playerName;
    string a = "Untitle";
    [SerializeField] Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        a = Login.staticPlayerPhone;
        Debug.Log("Статик playerPhone: " + a);
        //GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>().text = a.ToString();
        //playerName = GameObject.FindGameObjectWithTag("PlayerName");
        //playerName.GetComponent<Text>().text = a.ToString();
        playerName.text = a.ToString();

        

        //actionButtons = GameObject.Find("ActionButtons");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    
}
