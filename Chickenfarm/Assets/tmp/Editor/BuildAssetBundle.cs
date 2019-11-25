using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAssetBundle
{

    [MenuItem("Chicken Farm Manager/[Глобальное обновление]")]
    static void GloabalUpdate()
    {
        WWWForm form = new WWWForm();
        form.AddField("value", 1);
        form.AddField("id", 1);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/globalupdate.php", form);
        if(www.error != null)
        {
            Debug.Log("Подключение к интернету отсутвует");
        }
        else
        {
            Debug.Log("--------------CHICKEN FARM---------------");
            Debug.Log("[Игрокам присвоено глобальное обновление]");
        }
    }

    [MenuItem("Chicken Farm Manager/[Отменить обновление]")]
    static void StopGloabalUpdate()
    {
        WWWForm form = new WWWForm();
        form.AddField("value", 0);
        form.AddField("id", 1);
        WWW www = new WWW("http://g46869.hostnl1.fornex.org/example-dom-vis.ru/bd-all/globalupdate.php", form);
        if (www.error != null)
        {
            Debug.Log("Подключение к интернету отсутвует");
        }
        else
        {
            Debug.Log("--------------CHICKEN FARM---------------");
            Debug.Log("[Игрокам присвоено глобальное обновление]");
        }
    }

    [MenuItem("Chicken Farm Manager/[Очистить реестр (Unity)]")]
    static void ClearKsh()
    {
        PlayerPrefs.SetInt("version_game", 1);
        PlayerPrefs.SetInt("last_version_game", 1);
        PlayerPrefs.Save();
    }

    [MenuItem("Chicken Farm Manager/[Построить бандлы]")]
    static void BulidBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
