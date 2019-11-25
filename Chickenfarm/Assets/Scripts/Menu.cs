using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject water, eat, clean, take, sell;
    public GameObject playerName;
    string a = "Untitle";

    // Start is called before the first frame update
    void Start()
    {
        a = Login.staticPlayerPhone;
        Debug.Log("Статик playerPhone: " + a);
        GameObject.FindGameObjectWithTag("PlayaeName").GetComponent<Text>().text = a.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
