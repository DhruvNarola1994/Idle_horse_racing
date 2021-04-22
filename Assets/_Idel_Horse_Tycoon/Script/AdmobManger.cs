using GameAnalyticsSDK;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdmobManger : MonoBehaviour
{
    public static AdmobManger inst;

    private BannerView bannerView;
    private InterstitialAd interstitial;
    public RewardedAd rewardedAd;

    private string Key;

    // public static string BannerID = "ca-app-pub-7058033176101073/7465705797";
    //  public static string IntertitialID = "ca-app-pub-7857284937306424/3129135849";
    // public static string RewardVideoID = "ca-app-pub-7058033176101073/1285179246";


    //***************test id*************
    public static string BannerID = "ca-app-pub-3940256099942544/6300978111";
    public static string IntertitialID = "ca-app-pub-3940256099942544/1033173712";
    public static string RewardVideoID = "ca-app-pub-3940256099942544/5224354917";


    internal static bool isBannerShow = false;


    private void Awake()
    {
        if (!inst)
            inst = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
        RequestInterstitial();
        RequesRewardedVideo();
        ShowBanner();
    }

    public void ReloadInterstrial()
    {
        InvokeRepeating("RequestInterstitial", 3, 5);
    }


    public void ShowBanner()
    {
        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerView = new BannerView(BannerID, adaptiveSize, AdPosition.Bottom);
        this.bannerView.OnAdLoaded += this.BannerHandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.BannerHandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.BannerHandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.BannerHandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.BannerHandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
        isBannerShow = true;
    }

    public void BannerHandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("Banner HandleAdLoaded event received");
    }

    public void BannerHandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("Banner HandleFailedToReceiveAd event received with message: "
                            + args.Message);


        //FacebookAdsManager.Inst.LoadBanner();

    }

    public void BannerHandleOnAdOpened(object sender, EventArgs args)
    {

        MonoBehaviour.print("Banner HandleAdOpened event received");

    }

    public void BannerHandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("Banner HandleAdClosed event received");

    }

    public void BannerHandleOnAdLeavingApplication(object sender, EventArgs args)
    {

        MonoBehaviour.print("Banner HandleAdLeavingApplication event received");
    }


    public void DestroyBanner()
    {
        if (isBannerShow)
        {
            bannerView.Destroy();
            isBannerShow = false;
        }
    }
    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(IntertitialID);
        AdRequest request = new AdRequest.Builder().Build();


        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");

        CancelInvoke("RequestInterstitial");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);

        if (!IsLoaded())
        {
            Invoke("RequestInterstitial", 10);
        }
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");

        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void ShowIntetrtitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }

    public bool IsLoaded()
    {
        return interstitial.IsLoaded();
    }


    public void RequesRewardedVideo()
    {
        this.rewardedAd = new RewardedAd(RewardVideoID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        CancelInvoke("RequesRewardedVideo");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
        if (!rewardedAd.IsLoaded())
            Invoke("RequesRewardedVideo", 15);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
        //GameManager.inst.CurrantMap.Camera.transform.GetChild(CameraManagment.CameraView).gameObject.GetComponent<AudioListener>().enabled = false;

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);

        //GameManager.inst.CurrantMap.Camera.transform.GetChild(CameraManagment.CameraView).gameObject.GetComponent<AudioListener>().enabled = true;

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");

        //Camera.main.GetComponent<AudioListener>().enabled = true;
        //GameManager.inst.CurrantMap.Camera.transform.GetChild(CameraManagment.CameraView).gameObject.GetComponent<AudioListener>().enabled = true;
        AudioManager.IsMusicPlay = true;
        AudioManager.Inst.MPlay("bg");
        RequesRewardedVideo();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);


        Reward();
    }


    public void ShowRewarded(string k)
    {
        if (this.rewardedAd.IsLoaded())
        {

            //GameManager.inst.CurrantMap.Camera.transform.GetChild(CameraManagment.CameraView).gameObject.GetComponent<AudioListener>().enabled = false;

            //Camera.main.GetComponent<AudioListener>().enabled = false;
            AudioManager.IsMusicPlay = false;
            AudioManager.Inst.MPlay("bg");

            this.rewardedAd.Show();
            Key = k;
        }
        else
        {
            //FacebookAdsManager.Inst.ShowRewardedVideo(k);
        }
    }
    private void Reward()
    {
        GameAnalytics.NewAdEvent(GAAdAction.Show, GAAdType.RewardedVideo, "admob", RewardVideoID);
        switch (Key)
        {
            case "DoubleEarning_1Min":
                GameManager.inst.DoubleEarning_1Min();
                break;
            case "2xLevelUp":
                GameManager.TotalCoins += UiManager.inst.levelUp_Pnl.Bonus;
                GameManager.GiftBoxCounter++;
                UiManager.inst.levelUp_Pnl.gameObject.SetActive(false);
                break;
            case "Investment":
                GameManager.TotalCoins += GameManager.inst.Investment;
                GameManager.inst.Coins_PS.Play();
                UiManager.inst.Investment_pnl.gameObject.SetActive(false);
                break;
            case "2xExperiene":
                UiManager.inst.TwoXExperience.GetComponent<TwoX_Experience>().Button_press();
                break;
            case "BoostTime":
                UiManager.inst.BootTime.GetComponent<BootTime_Managment>().Button_press();
                break;
            case "+2Hores":
                UiManager.inst.Plus2Hores.GetComponent<Plus_2_Hores_Managment>().Button_press();
                break;
            case "2xWelcomeBack":
                GameManager.TotalCoins += UiManager.inst.WelComeBack_pnl.GetComponent<Wecomeback_pnl>().Coins;
                UiManager.inst.WelComeBack_pnl.SetActive(false);
                break;
        }
    }
}

