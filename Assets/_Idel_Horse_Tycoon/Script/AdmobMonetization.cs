//using GoogleMobileAds.Api;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AdmobMonetization : MonoBehaviour
//{
//    public static AdmobMonetization inst;

//    private BannerView bannerView;
//    private InterstitialAd interstitial;
//    private RewardBasedVideoAd rewardBasedVideo;

//    public static string BannerId;
//    public static string InterstitialId;
//    public static string RewardVideoId;

//    private string Key;


//    private void Awake()
//    {
//        if (inst == null)
//        {
//            inst = this;
//        }
//        else if (inst != this)
//        {
//            Destroy(gameObject);
//        }

//        DontDestroyOnLoad(gameObject);
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
////#if UNITY_ANDROID
////        BannerId = "ca-app-pub-3940256099942544/6300978111";
////        InterstitialId = "ca-app-pub-3940256099942544/1033173712";
////        RewardVideoId = "ca-app-pub-3940256099942544/5224354917";
////#elif UNITY_IPHONE
////            BannerId= "ca-app-pub-3940256099942544/2934735716";
////        InterstitialId ="ca-app-pub-3940256099942544/4411468910";
////        RewardVideoId ="ca-app-pub-3940256099942544/1712485313";

////#else
////           BannerId = "unexpected_platform";
////           InterstitialId = "unexpected_platform";
////           RewardVideoId = "unexpected_platform";
////#endif



//        // Initialize the Google Mobile Ads SDK.
//        MobileAds.Initialize(initStatus => { });


//        // Get singleton reward based video ad reference.
//        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

//        // Called when an ad request has successfully loaded.
//        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
//        // Called when an ad request failed to load.
//        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
//        // Called when an ad is shown.
//        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
//        // Called when the ad starts to play.
//        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
//        // Called when the user should be rewarded for watching a video.
//        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
//        // Called when the ad is closed.
//        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
//        // Called when the ad click caused the user to leave the application.
//        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

//        this.RequestRewardBasedVideo();

//      //  this.RequestBanner();
//        RequestInterstitial();
//        RequestRewardBasedVideo();
//    }
//    private void RequestBanner()
//    {


//        // Create a 320x50 banner at the top of the screen.
//        this.bannerView = new BannerView(BannerId, AdSize.Banner, AdPosition.Bottom);


//        // Called when an ad request has successfully loaded.
//        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
//        // Called when an ad request failed to load.
//        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
//        // Called when an ad is clicked.
//        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
//        // Called when the user returned from the app after an ad click.
//        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
//        // Called when the ad click caused the user to leave the application.
//        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();

//        // Load the banner with the request.
//        this.bannerView.LoadAd(request);


//    }

//    public void HandleOnAdLoaded(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdLoaded event received");
//    }

//    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
//                            + args.Message);

//        RequestInterstitial();

//    }

//    public void HandleOnAdOpened(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdOpened event received");
//    }

//    public void HandleOnAdClosed(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdClosed event received");
//        RequestInterstitial();

//    }

//    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdLeavingApplication event received");
//    }

//    //Interstitial________________________________________________________________________________________________________________________________________________________________________
//    private void RequestInterstitial()
//    {

//        // Initialize an InterstitialAd.
//        this.interstitial = new InterstitialAd(InterstitialId);


//        // Called when an ad request has successfully loaded.
//        this.interstitial.OnAdLoaded += HandleOnAdLoadedInterstitial;
//        // Called when an ad request failed to load.
//        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoadInterstitial;
//        // Called when an ad is shown.
//        this.interstitial.OnAdOpening += HandleOnAdOpenedInterstitial;
//        // Called when the ad is closed.
//        this.interstitial.OnAdClosed += HandleOnAdClosedInterstitial;
//        // Called when the ad click caused the user to leave the application.
//        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplicationInterstitial;


//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the interstitial with the request.
//        this.interstitial.LoadAd(request);
//    }

//    public void HandleOnAdLoadedInterstitial(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdLoaded event received");
//    }

//    public void HandleOnAdFailedToLoadInterstitial(object sender, AdFailedToLoadEventArgs args)
//    {
//        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
//                            + args.Message);
//    }

//    public void HandleOnAdOpenedInterstitial(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdOpened event received");
//    }

//    public void HandleOnAdClosedInterstitial(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdClosed event received");
//    }

//    public void HandleOnAdLeavingApplicationInterstitial(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleAdLeavingApplication event received");
//    }

//    public void ShowInterstitial()
//    {
//        if (this.interstitial.IsLoaded())
//        {
//            this.interstitial.Show();
//        }
//    }

//    //Rewarded Video______________________________________________________________________________________________________________________________________________________________________

//    private void RequestRewardBasedVideo()
//    {

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the rewarded video ad with the request.
//        this.rewardBasedVideo.LoadAd(request, RewardVideoId);
//    }

//    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
//    }

//    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
//    {
//        MonoBehaviour.print(
//            "HandleRewardBasedVideoFailedToLoad event received with message: "
//                             + args.Message);
//        RequestRewardBasedVideo();

//    }

//    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
//    }

//    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
//    }

//    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
//        RequestRewardBasedVideo();

//    }

//    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
//    {
//        string type = args.Type;
//        double amount = args.Amount;
//        MonoBehaviour.print(
//            "HandleRewardBasedVideoRewarded event received for "
//                        + amount.ToString() + " " + type);
//        Reward();

//    }

//    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
//    {
//        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
//    }

//    public void ShowRewardedVideo(string k)
//    {
//        if (rewardBasedVideo.IsLoaded())
//        {
//            Key = k;

//            rewardBasedVideo.Show();
//        }
//    }

//    //Reward
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
//}
