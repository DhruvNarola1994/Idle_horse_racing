using GameAnalyticsSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetDataFromeJson : MonoBehaviour
{


    public static bool DataAlredyGet;
    public GameObject Adsmanager;


    public static string resultAPI;


    private void Start()
    {
        Debug.Log("DataAlredyGet = " + DataAlredyGet);

        if (!DataAlredyGet)
        {
            StartCoroutine(Get());
        }
        GameAnalytics.Initialize();
    }


    IEnumerator Get()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://aftekmoneycash.co.in/v1/admin/public/HORSE_GAME");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            GetData();
        }
        else
        {
            if (www.isDone)
            {
                resultAPI = www.downloadHandler.text;

                Debug.Log("<color=orange>Game Data = " + www.downloadHandler.text + "</color>");


                ApiCallSaveInDB();


            }

        }
    }



    private void ApiCallSaveInDB()
    {
        try
        {
            RootObjectAPIJsonResponse jsonObject = JsonUtility.FromJson<RootObjectAPIJsonResponse>(resultAPI);

            Debug.Log("jsonObject.status=" + jsonObject.status);

            if (jsonObject.status)
            {
                var data = jsonObject.data;
                for (int i = 0; i < data.Length; i++)
                {
                    SetDataWithoutKey(data[i].KEYWORD, data[i].VALUE);
                }
            }

        }
        catch
        {

        }
        DataAlredyGet = true;

        GetData();
    }



    internal static void SetDataWithoutKey(string key, string value)
    {

        PlayerPrefs.SetString(key.ToString(), value);
        PlayerPrefs.Save();
    }

    private void GetData()
    {
#if UNITY_ANDROID

        //FacebookAdsManager.BannerId = PlayerPrefs.GetString("Android_Facebook_banner_id");
        //FacebookAdsManager.InterstitialId = PlayerPrefs.GetString("Android_Facebook_interstitial_id");
        //FacebookAdsManager.NativeId = PlayerPrefs.GetString("Android_Facebook_Native_id");
        //FacebookAdsManager.NativebanerId = PlayerPrefs.GetString("Android_Facebook_NativeBaner_id");
        //FacebookAdsManager.RewadedId = PlayerPrefs.GetString("Android_Facebook_Rewarded_id");
        //// FacebookAdsManager.RewadedId_cpm = PlayerPrefs.GetString("Facebook_Rewarded_cpm_id");

        AdmobManger.BannerID = PlayerPrefs.GetString("Android_Admob_Banner_Id");
        AdmobManger.IntertitialID = PlayerPrefs.GetString("Android_Admob_Interstitial_Id");
        AdmobManger.RewardVideoID = PlayerPrefs.GetString("Android_Admob_RewardedVideo_Id");

        ////UnityAdsManager.gameID = PlayerPrefs.GetString("Unity_id");


        float newversion = (float)Convert.ToDouble(PlayerPrefs.GetString("Android_GameVersion"));
        float currantvertion = (float)Convert.ToDouble(Application.version);

        if (currantvertion < newversion)
        {

            string Liststr = PlayerPrefs.GetString("Android_Update_Message");

            string[] List = Liststr.Split(',');

            UiManager.inst.UpdateMessage_Text.text = "";

            for (int i = 0; i < List.Length; i++)
            {

                UiManager.inst.UpdateMessage_Text.text += "=> " + List[i] + ".\n";

            }

            UiManager.inst.Update_Panel.SetActive(true);
        }


#elif UNITY_IPHONE

        //FacebookAdsManager.BannerId = PlayerPrefs.GetString("Ios_Facebook_Banner_Id");
        //FacebookAdsManager.InterstitialId = PlayerPrefs.GetString("Ios_Facebook_Interstitial_Id");
        //FacebookAdsManager.NativeId = PlayerPrefs.GetString("Facebook_Native_id");
        //FacebookAdsManager.NativebanerId = PlayerPrefs.GetString("Facebook_NativeBaner_id");
        //FacebookAdsManager.RewadedId = PlayerPrefs.GetString("Ios_Facebook_RewardedVideo_Id");

        AdmobManger.IntertitialID = PlayerPrefs.GetString("Ios_Admob_Interstitial_Id");
        AdmobManger.RewardVideoID = PlayerPrefs.GetString("Ios_Admob_RewardedVideo_Id");



        float newversion = (float)Convert.ToDouble(PlayerPrefs.GetString("Ios_GameVersion"));
        float currantvertion = (float)Convert.ToDouble(Application.version);

        if (currantvertion < newversion)
        {

            string Liststr = PlayerPrefs.GetString("Ios_Update_Message");

            string[] List = Liststr.Split(',');

            UiManager.inst.UpdateMessage_Text.text = "";

            for (int i = 0; i < List.Length; i++)
            {

                UiManager.inst.UpdateMessage_Text.text += "=> " + List[i] + ".\n";

            }

            UiManager.inst.Update_Panel.SetActive(true);
        }

#endif



        //chack version and mandancemode



        //float Maintence_version = (float)Convert.ToDouble(PlayerPrefs.GetString("M_ver"));

        //if (PlayerPrefs.GetString("M_mode") == "ON" && Maintence_version == currantvertion)
        //{
        //    UiManager.inst.Maintenance_panel.SetActive(true);
        //    UiManager.inst.MaintenceMessage_Text.text = PlayerPrefs.GetString("M_msg");
        //}







        Adsmanager.SetActive(true);

    }

}
public struct RootObjectAPIJsonResponse
{
    [System.Serializable]
    public struct KeyValueDisc
    {
        public string KEYWORD;
        public string VALUE;
    }
    public bool status;
    public string message;
    public KeyValueDisc[] data;
}
