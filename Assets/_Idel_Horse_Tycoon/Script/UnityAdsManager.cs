//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Advertisements;
//using UnityEngine.UI;

//public class UnityAdsManager : MonoBehaviour
//{
//    public static UnityAdsManager inst;

//    public bool TestingMode;
//    private string unityId = "000000";

//    private string Key;

//    private void Awake()
//    {
//        if (!inst)
//            inst = this;
//        else
//            Destroy(gameObject);

//        DontDestroyOnLoad(this);
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        Advertisement.Initialize(unityId, TestingMode);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public bool LoadedRewardedVideo()
//    {

//        return Advertisement.IsReady("rewardedVideo");
//    }

//    public void ShowRewardedVideo(string k)
//    {
//        Key = k;

//        ShowOptions options = new ShowOptions();
//        options.resultCallback = HandleShowResult;

//        if (Advertisement.IsReady("rewardedVideo"))
//        {

//            Advertisement.Show("rewardedVideo", options);
//        }
//    }

//    void HandleShowResult(ShowResult result)
//    {
//        if (result == ShowResult.Finished)
//        {
//            Reward();
//        }
//        else if (result == ShowResult.Skipped)
//        {

//            Debug.LogWarning("Video was skipped - Do NOT reward the player");

//        }
//        else if (result == ShowResult.Failed)
//        {

//        }
//    }
//    //Reward______________________________________________________________________________________________________________________________________________

//    private void Reward()
//    {
//        switch (Key)
//        {

//            case "DoubleEarning_1Min":
//                GameManager.inst.DoubleEarning_1Min();
//                break;
//            case "2xLevelUp":
//                GameManager.TotalCoins += UiManager.inst.levelUp_Pnl.Bonus;
//                GameManager.GiftBoxCounter++;
//                UiManager.inst.levelUp_Pnl.gameObject.SetActive(false);
//                break;
//            case "Investment":
//                GameManager.TotalCoins += GameManager.inst.Investment;
//                GameManager.inst.Coins_PS.Play();
//                UiManager.inst.Investment_pnl.gameObject.SetActive(false);
//                break;
//            case "2xExperiene":
//                UiManager.inst.TwoXExperience.GetComponent<TwoX_Experience>().Button_press();
//                break;
//            case "BoostTime":
//                UiManager.inst.BootTime.GetComponent<BootTime_Managment>().Button_press();
//                break;
//            case "+2Hores":
//                UiManager.inst.Plus2Hores.GetComponent<Plus_2_Hores_Managment>().Button_press();
//                break;
//            case "2xWelcomeBack":
//                GameManager.TotalCoins +=  UiManager.inst.WelComeBack_pnl.GetComponent<Wecomeback_pnl>().Coins;
//                UiManager.inst.WelComeBack_pnl.SetActive(false);
//                break;


//        }
//    }
//}
