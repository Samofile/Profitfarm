using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppRun : MonoBehaviour
{
    [SerializeField] Text chickenCount;
    [SerializeField] Text eggCount;
    public GameObject myChicken;
    public GameObject myEgg;
    public int n = 0;
    public int k = 0;
    public bool setChickens = true;
    public bool setEggs = true;

    void Awake() 
    {
        setChickens = true;
        setEggs = true;
    }

    void Start()
    {

    }

    public Vector3 center;
    public Vector3 size;

    private IEnumerator MakeChickens(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject newChicken = Instantiate(myChicken, pos, Quaternion.identity);
            newChicken.transform.localScale = new Vector3(1f, 1f, 1f);
            newChicken.SetActive(true);
            chickenCount.text = i.ToString();
            yield return new WaitForSeconds(0);
            //Vector3 pos = myChicken.transform.position;
            //Instantiate(myChicken, new Vector3(pos.x, pos.y, pos.z), transform.rotation);
            //Debug.Log("My Chicken " + i + " x: " + pos.x + " y: " + pos.y + " z: " + pos.z);
            //chickenCount.setText(Html.fromHtml(" &#x20bd"));
        }
    }

    private IEnumerator MakeEggs(int k)
    {
        for (int i = 0; i < k; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject newEgg = Instantiate(myEgg, pos, Quaternion.identity);
            newEgg.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            newEgg.SetActive(true);
            eggCount.text = i.ToString();
            yield return new WaitForSeconds(0);
            //Vector3 pos = myChicken.transform.position;
            //Instantiate(myChicken, new Vector3(pos.x, pos.y, pos.z), transform.rotation);
            //newEgg.transform.localScale = new Vector3(1f, 1f, 1f);
            //Debug.Log("My Chicken " + i + " x: " + pos.x + " y: " + pos.y + " z: " + pos.z);
        }
    }

    void Update()
    {
        n = int.Parse(Menu.staticChickenCount);
        k = int.Parse(Menu.staticEggCount);
        if (n > 0 && setChickens) {
            StartCoroutine(MakeChickens(n));
            StartCoroutine(MakeEggs(k));
            setChickens = false;
            setEggs = false;
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