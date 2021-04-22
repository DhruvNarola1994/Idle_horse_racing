//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IronSourceManager : MonoBehaviour
//{
//    public static IronSourceManager inst;

//    public string APP_KEY = "ce1cb235";
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
//        //For Rewarded Video
//        IronSource.Agent.init(APP_KEY, IronSourceAdUnits.REWARDED_VIDEO);
//        //For Interstitial
//        IronSource.Agent.init(APP_KEY, IronSourceAdUnits.INTERSTITIAL);
//        //For Offerwall
//        IronSource.Agent.init(APP_KEY, IronSourceAdUnits.OFFERWALL);
//        //For Banners
//        IronSource.Agent.init(APP_KEY, IronSourceAdUnits.BANNER);


//        //Banner
//        IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
//        IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;
//        IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent;
//        IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent;
//        IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
//        IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;

//        LoadBanner();


//        //RewardedVideo
//        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
//        IronSourceEvents.onRewardedVideoAdClickedEvent += RewardedVideoAdClickedEvent;
//        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
//        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
//        IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
//        IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
//        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
//        IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;


//        //Interstitial
//        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
//        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;
//        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent;
//        IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent;
//        IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
//        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
//        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;

//        IronSource.Agent.loadInterstitial();
//    }



//    void OnApplicationPause(bool isPaused)
//    {
//        IronSource.Agent.onApplicationPause(isPaused);
//    }
//    //Banner

//    public void LoadBanner()
//    {

//        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM, APP_KEY);

//    }
//    public void ShowBanner()
//    {

//        IronSource.Agent.displayBanner();

//    }
//    public void HideBanner()
//    {

//        IronSource.Agent.hideBanner();

//    }
//    public void DestroidBanner()
//    {

//        IronSource.Agent.destroyBanner();

//    }
//    //Invoked once the banner has loaded
//    void BannerAdLoadedEvent()
//    {
//        ShowBanner();
//    }
//    //Invoked when the banner loading process has failed.
//    //@param description - string - contains information about the failure.
//    void BannerAdLoadFailedEvent(IronSourceError error)
//    {
//    }
//    // Invoked when end user clicks on the banner ad
//    void BannerAdClickedEvent()
//    {
//    }
//    //Notifies the presentation of a full screen content following user click
//    void BannerAdScreenPresentedEvent()
//    {
//    }
//    //Notifies the presented screen has been dismissed
//    void BannerAdScreenDismissedEvent()
//    {
//    }
//    //Invoked when the user leaves the app
//    void BannerAdLeftApplicationEvent()
//    {
//    }


//    //RewardVideo_________________________________________________________________________________________________________________________________________________________________________
//    public void RewardVideoShow(string k)
//    {

//        if (IronSource.Agent.isRewardedVideoAvailable())
//        {

//            Key = k;

//            IronSource.Agent.showRewardedVideo();
//        }


//    }

//    public bool LoadedVideo()
//    {

//        return IronSource.Agent.isRewardedVideoAvailable();


//    }
//    private void RewardedVideoAdClickedEvent(IronSourcePlacement obj)
//    {
//        throw new NotImplementedException();
//    }
//    //Invoked when the RewardedVideo ad view has opened.
//    //Your Activity will lose focus. Please avoid performing heavy 
//    //tasks till the video ad will be closed.
//    void RewardedVideoAdOpenedEvent()
//    {
//    }
//    //Invoked when the RewardedVideo ad view is about to be closed.
//    //Your activity will now regain its focus.
//    void RewardedVideoAdClosedEvent()
//    {
//    }
//    //Invoked when there is a change in the ad availability status.
//    //@param - available - value will change to true when rewarded videos are available. 
//    //You can then show the video by calling showRewardedVideo().
//    //Value will change to false when no videos are available.
//    void RewardedVideoAvailabilityChangedEvent(bool available)
//    {
//        //Change the in-app 'Traffic Driver' state according to availability.
//        bool rewardedVideoAvailability = available;
//    }

//    //Invoked when the user completed the video and should be rewarded. 
//    //If using server-to-server callbacks you may ignore this events and wait for 
//    // the callback from the  ironSource server.
//    //@param - placement - placement object which contains the reward data
//    void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
//    {
//        Reward();

//    }
//    //Invoked when the Rewarded Video failed to show
//    //@param description - string - contains information about the failure.
//    void RewardedVideoAdShowFailedEvent(IronSourceError error)
//    {
//    }

//    // ----------------------------------------------------------------------------------------
//    // Note: the events below are not available for all supported rewarded video ad networks. 
//    // Check which events are available per ad network you choose to include in your build. 
//    // We recommend only using events which register to ALL ad networks you include in your build. 
//    // ----------------------------------------------------------------------------------------

//    //Invoked when the video ad starts playing. 
//    void RewardedVideoAdStartedEvent()
//    {
//    }
//    //Invoked when the video ad finishes playing. 
//    void RewardedVideoAdEndedEvent()
//    {
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
//    //Intertitial________________________________________________________________________________________________________________________________________________________________________



//    //Invoked when the initialization process has failed.
//    //@param description - string - contains information about the failure.
//    void InterstitialAdLoadFailedEvent(IronSourceError error)
//    {
//    }
//    //Invoked right before the Interstitial screen is about to open.
//    void InterstitialAdShowSucceededEvent()
//    {
//    }
//    //Invoked when the ad fails to show.
//    //@param description - string - contains information about the failure.
//    void InterstitialAdShowFailedEvent(IronSourceError error)
//    {
//        IronSource.Agent.loadInterstitial();
//    }
//    // Invoked when end user clicked on the interstitial ad
//    void InterstitialAdClickedEvent()
//    {
//    }
//    //Invoked when the interstitial ad closed and the user goes back to the application screen.
//    void InterstitialAdClosedEvent()
//    {
//        IronSource.Agent.loadInterstitial();
//    }
//    //Invoked when the Interstitial is Ready to shown after load function is called
//    void InterstitialAdReadyEvent()
//    {
//    }
//    //Invoked when the Interstitial Ad Unit has opened
//    void InterstitialAdOpenedEvent()
//    {
//    }

//    public void ShowInterstitial()
//    {

//        if (IronSource.Agent.isInterstitialReady())
//        {

//            IronSource.Agent.showInterstitial();

//        }
//        else
//        {

//            IronSource.Agent.loadInterstitial();

//        }

//    }
//}
