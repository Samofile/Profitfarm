using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppRun : MonoBehaviour
{
    [SerializeField] Text chickenCount;
    [SerializeField] Text eggCount;
    [SerializeField] ParticleSystem waterParticles;
    public Vector3 center;
    public Vector3 size;
    public GameObject myChicken;
    public GameObject myEgg;
    public GameObject[] chickens;
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

    void Update()
    {
        if (n != int.Parse(Menu.staticChickenCount)) {setChickens = true;} // if chicken count changed
        n = int.Parse(Menu.staticChickenCount);
        if (n > 0 && setChickens) {
            chickens = GameObject.FindGameObjectsWithTag("chicken");
            StartCoroutine(MakeChickens(n));
            setChickens = false;
        }

        if (k != int.Parse(Menu.staticEggCount)) {setEggs = true;}
        k = int.Parse(Menu.staticEggCount);
        if (k > 0 && setEggs) {
            StartCoroutine(MakeEggs(k));
            setEggs = false;
        }
        //Debug.Log("setChickens-1: " + setChickens);
        if (Menu.doDrink){
            waterParticles.Play();
        }
    }

    private IEnumerator MakeChickens(int n)
    {
        if (chickens != null) { for(int i = 0; i < chickens.Length; i++) { Destroy(chickens[i],0); }}
        for (int i = 0; i < n; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            GameObject newChicken = Instantiate(myChicken, pos, Quaternion.identity);
            //GameObject newChicken = Instantiate(myChicken, pos, transform.rotation);
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

}