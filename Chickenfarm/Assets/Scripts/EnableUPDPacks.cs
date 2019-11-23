using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableUPDPacks : MonoBehaviour
{
    string path;

    public GameObject all_panel, start_load, load_panel, no_connection, button_go;

    public Transform line;

    public Text loading;

    bool stop;

    void Awake() // Для будующих присвоений
    {
        
    }

    public void GoLoad()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.rovio.angrybirds");
    }

    void Start()
    {
        version_game = PlayerPrefs.GetInt("version_game");
        if(version_game == 0)
        {
            version_game = 1;
            PlayerPrefs.SetInt("version_game", version_game);
            PlayerPrefs.Save();
        }
        last_ver = PlayerPrefs.GetInt("last_version_game");
        if (last_ver == 0)
        {
            last_ver = 1;
        }
    }



    public void GoUpdate()
    {
        StartCoroutine(GET_VERSION_GAME());
        //StartCoroutine(GET_VERSION());
    }

    [Header("Версия игры")]
    public int version, lls = 0, version_game;

    private int last_ver;

    private bool no_internet;

    private int cache_index;


    public IEnumerator GET_VERSION_GAME()
    {
        WWWForm formd = new WWWForm(); 
        formd.AddField("id", 1);
        WWW wwwq = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_cache.php", formd);
        yield return wwwq;
        cache_index = int.Parse(wwwq.text);

        Debug.Log("Cache v: " + cache_index.ToString());

        WWWForm forms = new WWWForm(); 
        forms.AddField("id", 1);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/update_ranges.php", forms);
        yield return www;
        int vers = int.Parse(www.text);
        Debug.Log("VG:" + vers.ToString());
        if(version_game != vers)
        {
            button_go.SetActive(true);
            start_load.SetActive(false);
            load_panel.SetActive(false);
        }
        else
        {
            StartCoroutine(GET_VERSION());
        }
    }

    public IEnumerator GET_VERSION()
    {
        WWWForm form3 = new WWWForm(); // ПРЕФАБЫ
        form3.AddField("id", 1);
        WWW www3 = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_count_p.php", form3);
        yield return www3;
        count_p = int.Parse(www3.text);
        Debug.Log("PREFABS-LOAD IN THIS PACK: " + count_p);

        if (www3.error != null)
        {
            no_internet = true;
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("id", 1);
            WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/get_version.php", form);
            yield return www;

            if (www.error != null)
            {
                no_connection.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                no_connection.SetActive(false);
                StartCoroutine(GET_VERSION());
            }
            else
            {
                version = int.Parse(www.text);

                if (version > last_ver)
                {
                    load_panel.SetActive(true);
                    start_load.SetActive(false);
                }
                else
                {
                    yield return new WaitForSeconds(1.5f);
                    all_panel.SetActive(false);
                }

                for (int i = version; i > 0; i--)
                {
                    StartCoroutine(DownloadBundle(i));
                }
            }
        }
        if(no_internet)
        {
            for (int i = last_ver; i > 0; i--)
            {
                StartCoroutine(DownloadBundle(i));
            }
        }
    }
   
    int count_p;

    private IEnumerator ShowProgress(WWW www)
    {
        float one = 1f / version;

        while (www.progress < 1f)
        {
            line.localScale = new Vector3((one * lls), 1f, 1f);
            loading.text = "ЗАГРУЗКА " + (one * lls * 100).ToString() + "%";
        }
        lls++;
        line.localScale = new Vector3((one * lls), 1f, 1f);
        loading.text = "ЗАГРУЗКА " + (one * lls * 100).ToString() + "%";
        yield return new WaitForSeconds(0f);
        if((one * lls * 100) == 100)
        {
            yield return new WaitForSeconds(3f);
            load_panel.SetActive(false);
            start_load.SetActive(false);
            all_panel.SetActive(false);
        }
    }

    IEnumerator DownloadBundle(int sversion) 
    {
        if(version != sversion)
        {
            count_p = PlayerPrefs.GetInt("count_p_" + sversion.ToString());
            Debug.Log(sversion.ToString() + " :x: " + count_p.ToString());
        }

        path = "http://g46869.hostnl1.fornex.org/chicken_update_" + sversion.ToString() + ".unity3d";

        while (!Caching.ready)
            yield return null;
        
        var www = WWW.LoadFromCacheOrDownload(path, 0);

        StartCoroutine(ShowProgress(www));

        yield return www;

        if (!string.IsNullOrEmpty(www.error)) // ЕСЛИ ОШИБКА ИЛИ НЕТ СОЕДИНЕНИЯ
        {
            yield break;
        }

        var assetBundle = www.assetBundle;

        for (int i = 1; i <= count_p; i++)
        {
            Debug.Log(sversion.ToString() + " :KKK: " + i.ToString());
            string name_s = "MAP_BUNDLE_" + sversion.ToString() + "_" + i.ToString() + ".prefab";
            var prefabRequest_box2 = assetBundle.LoadAssetAsync(name_s, typeof(GameObject));
            yield return prefabRequest_box2;
            GameObject game_obj = prefabRequest_box2.asset as GameObject;
            Vector3 pos = game_obj.transform.position;
            Instantiate(game_obj, pos, Quaternion.identity);
        }
        PlayerPrefs.SetInt("count_p_"+sversion.ToString(), count_p);
        PlayerPrefs.SetInt("last_version_game", version);
        PlayerPrefs.Save();
    }
}
