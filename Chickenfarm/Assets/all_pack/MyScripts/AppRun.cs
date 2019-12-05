using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppRun : MonoBehaviour
{
    public GameObject myChicken;
    public int n = 0;
    public bool setChickens = true;

    void Awake() 
    {
        setChickens = true;
    }

    void Start()
    {

    }

    private IEnumerator MakeChickens(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 pos = myChicken.transform.position;
            Instantiate(myChicken, new Vector3(pos.x, pos.y, pos.z), transform.rotation);
            myChicken.transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log("My Chicken " + i + " x: " + pos.x + " y: " + pos.y + " z: " + pos.z);
            yield return new WaitForSeconds(2);
        }
    }

    void Update()
    {
        n = int.Parse(Menu.staticChickenCount);
        if (n > 0 && setChickens) {
            StartCoroutine(MakeChickens(n));
            setChickens = false;
        }
        //Debug.Log("setChickens-1: " + setChickens);
    }

    public void OnGUI() 
    {
        //GUI.
        //GUIDrawRect (Color.blue);
        //Debug.Log("Тут-2");
    }

}
