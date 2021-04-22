//using AudienceNetwork;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class FacebookAdsManager : MonoBehaviour
//{


//    public static FacebookAdsManager Inst;

//    // Test ID
//    public static string BannerId = "YOUR_PLACEMENT_ID";
//    public static string InterstitialId = "YOUR_PLACEMENT_ID";
//    public static string NativeId = "YOUR_PLACEMENT_ID";
//    public static string RewadedId = "YOUR_PLACEMENT_ID";
//    public static string NativebanerId = "YOUR_PLACEMENT_ID";



//    private AdView adView;
//    private InterstitialAd interstitialAd;

//    [HideInInspector]
//    public bool Fullscre_isLoaded;

//    private bool FullScre_didClose;

//    private RewardedVideoAd rewardedVideoAd;
//    [HideInInspector]
//    public bool VideoisLoaded;
//    private bool VideodidClose;

//    [HideInInspector]
//    public bool Banner_isLoaded;

//    private string Key;


//    private void Awake()
//    {
//        if (!Inst)
//            Inst = this;
//        else
//            Destroy(gameObject);

//        DontDestroyOnLoad(this);
//    }

//    // Use this for initialization
//    void Start()
//    {
//        // ShowBanner();
//       // LoadInterstitial();
//        LoadRewardedVideo();
//    }
//    public void LoadBanner()
//    {
//        if (adView)
//        {
//            adView.Dispose();
//        }

//        adView = new AdView(BannerId, AdSize.BANNER_HEIGHT_50);
//        adView.Register(gameObject);

//        adView.AdViewDidLoad = delegate ()
//        {
//            //CancelInvoke("ShowBanner");
//            Banner_isLoaded = true;
//            adView.Show(AdPosition.BOTTOM);
//        };
//        adView.AdViewDidFailWithError = delegate (string error)
//        {
//            if (PlayerPrefs.GetString("AdsPriority") != "google")
//            {
//                AdmobManger.inst.ShowBanner();
//            }
//        };
//        adView.AdViewWillLogImpression = delegate ()
//        {
            
//        };
//        adView.AdViewDidClick = delegate ()
//        {
            
//        };

//        adView.LoadAd();

//    }


//    public void LoadInterstitial()
//    {

//        interstitialAd = new InterstitialAd(InterstitialId);


//        interstitialAd.Register(gameObject);

//        // Set delegates to get notified on changes or when the user interacts with the ad.
//        interstitialAd.InterstitialAdDidLoad = delegate ()
//        {
//            Debug.Log("Interstitial ad loaded.");
//            Fullscre_isLoaded = true;
//            FullScre_didClose = false;
//            string isAdValid = interstitialAd.IsValid() ? "valid" : "invalid";

//            CancelInvoke("LoadInterstitial");

//        };
//        interstitialAd.InterstitialAdDidFailWithError = delegate (string error)
//        {
//            Debug.Log("Interstitial ad failed to load with error: " + error);

//            if (!Fullscre_isLoaded)
//            {
//                Invoke("LoadInterstitial", 40);
//            }
//        };
//        interstitialAd.InterstitialAdWillLogImpression = delegate ()
//        {
//            Debug.Log("Interstitial ad logged impression.");
//        };
//        interstitialAd.InterstitialAdDidClick = delegate ()
//        {
//            Debug.Log("Interstitial ad clicked.");
//        };
//        interstitialAd.InterstitialAdDidClose = delegate ()
//        {
//            Debug.Log("Interstitial ad did close.");
//            FullScre_didClose = true;
//            if (interstitialAd != null)
//            {
//                interstitialAd.Dispose();
//            }
//            LoadInterstitial();

//        };

//#if UNITY_ANDROID
//        /*
//         * Only relevant to Android.
//         * This callback will only be triggered if the Interstitial activity has
//         * been destroyed without being properly closed. This can happen if an
//         * app with launchMode:singleTask (such as a Unity game) goes to
//         * background and is then relaunched by tapping the icon.
//         */
//        interstitialAd.interstitialAdActivityDestroyed = delegate ()
//        {
//            if (!FullScre_didClose)
//            {
//                Debug.Log("Interstitial activity destroyed without being closed first.");
//                Debug.Log("Game should resume.");
//            }
//            LoadInterstitial();
//        };
//#endif

//        // Initiate the request to load the ad.
//        interstitialAd.LoadAd();
//    }

//    public void ShowInterstitial()
//    {
//        if (Fullscre_isLoaded)
//        {
//            interstitialAd.Show();
//            Fullscre_isLoaded = false;
//        }
//        else
//        {
//            LoadInterstitial();

//        }
//    }

//    public void LoadRewardedVideo()
//    {
//        rewardedVideoAd = new RewardedVideoAd(RewadedId);


//        //RewardData rewardData = new RewardData
//        //{
//        //    UserId = "USER_ID",
//        //    Currency = "REWARD_ID"
//        //};

//        rewardedVideoAd.Register(gameObject);

//        rewardedVideoAd.RewardedVideoAdDidLoad = delegate ()
//        {
//            Debug.Log("RewardedVideo ad loaded.");
//            VideoisLoaded = true;
//            VideodidClose = false;
//            string isAdValid = rewardedVideoAd.IsValid() ? "valid" : "invalid";
//            CancelInvoke("LoadRewardedVideo");
//        };
//        rewardedVideoAd.RewardedVideoAdDidFailWithError = delegate (string error)
//        {
//            Debug.Log("RewardedVideo ad failed to load with error: " + error);

//            if (!VideoisLoaded)
//            {
//                CancelInvoke("LoadRewardedVideo");
//                Invoke("LoadRewardedVideo", 40);
//            }

//        };
//        rewardedVideoAd.RewardedVideoAdWillLogImpression = delegate ()
//        {
//            Debug.Log("RewardedVideo ad logged impression.");


//        };
//        rewardedVideoAd.RewardedVideoAdDidClick = delegate ()
//        {
//            Debug.Log("RewardedVideo ad clicked.");
//        };

//        rewardedVideoAd.RewardedVideoAdDidSucceed = delegate ()
//        {
//            Debug.Log("Rewarded video ad validated by server");

//            // Reward();
//        }; rewardedVideoAd.RewardedVideoAdComplete = delegate ()
//        {
//            Debug.Log("RewardedVideo ad logged Complet.");
//            Reward();
//            LoadRewardedVideo();
//        };

//        rewardedVideoAd.RewardedVideoAdDidFail = delegate ()
//        {
//            //LoadRewardedVideo();
//            Debug.Log("Rewarded video ad not validated, or no response from server");
//        };


//        rewardedVideoAd.RewardedVideoAdDidClose = delegate ()
//        {
//            Debug.Log("Rewarded video ad did close.");
//            VideodidClose = true;
//            if (rewardedVideoAd != null)
//            {
//                rewardedVideoAd.Dispose();
//            }

//            LoadRewardedVideo();

//        };

//#if UNITY_ANDROID
//        /*
//         * Only relevant to Android.
//         * This callback will only be triggered if the Rewarded Video activity
//         * has been destroyed without being properly closed. This can happen if
//         * an app with launchMode:singleTask (such as a Unity game) goes to
//         * background and is then relaunched by tapping the icon.
//         */
//        rewardedVideoAd.RewardedVideoAdActivityDestroyed = delegate ()
//        {
//            if (!VideodidClose)
//            {
//                Debug.Log("Rewarded video activity destroyed without being closed first.");
//                Debug.Log("Game should resume. User should not get a reward.");
//            }
//        };
//#endif

//        // Initiate the request to load the ad.
//        rewardedVideoAd.LoadAd();
//    }

//    public void ShowRewardedVideo(string k)
//    {
//        if (VideoisLoaded)
//        {
//            Key = k;

//            rewardedVideoAd.Show();
//            VideoisLoaded = false;

//        }
//        else
//        {

//            LoadRewardedVideo();

//        }
//    }



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
//                GameManager.TotalCoins += UiManager.inst.WelComeBack_pnl.GetComponent<Wecomeback_pnl>().Coins;
//                UiManager.inst.WelComeBack_pnl.SetActive(false);
//                break;

//        }

//    }

//    //void OnDestroy()
//    //{
//    //    // Dispose of rewardedVideo ad when the scene is destroyed
//    //    if (rewardedVideoAd != null)
//    //    {
//    //        rewardedVideoAd.Dispose();
//    //    }
//    //    Debug.Log("RewardedVideoAdTest was destroyed!");


//    //    // Dispose of banner ad when the scene is destroyed
//    //    if (adView)
//    //    {
//    //        adView.Dispose();
//    //    }
//    //    Debug.Log("AdViewTest was destroyed!");

//    //    // Dispose of interstitial ad when the scene is destroyed
//    //    if (interstitialAd != null)
//    //    {
//    //        interstitialAd.Dispose();
//    //    }
//    //    Debug.Log("InterstitialAdTest was destroyed!");
//    //}


//}
