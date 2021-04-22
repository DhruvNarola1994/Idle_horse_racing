using Facebook.Unity;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager inst;

    [Header("------------ Top Bar ------------")]
    public Text Main_Coin_txt;
    public Text Map_Name_txt;
    public Text MainLevel_txt;
    public Text Map_Rate_txt;
    public Image Map_Rate_Slider;
    public Slider MainLevelUp_Slider;
    public Button MainLevelUp_btn;

    [Space]

    [Header("------------ Map selection ------------")]
    public Scrollbar MapScrollbar;

    [Header("------------ Tutorial Hand ------------")]
    public GameObject Hand;

    [Header("------------ Center ------------")]
    public Text GiftBox_txt;
    public Button GiftBox_Btn, TwoX1Min_btn;
    public Button PrasnalManager_Btn, Twox_IAP_btn;

    public GameObject BootTime, Plus2Hores, TwoXExperience;



    [Header("------------ Bottom Bar ------------")]
    public Text Total_Hores_txt;
    public Text Hores_Earn_Coin_txt;
    public Text Currrant_Lvl_txt;
    public Text Target_Lvl_txt;
    public Text Plus_Hores_txt;
    public Text MapRating_txt;
    public Slider Level_Up_slider;
    public Slider MapRating_slider;
    public Text Update_Level_Coin_txt;
    public Button[] AllLevel_btn_List;

    public Button UpdateLevel_btn;
    public Sprite UpdateLevel_btn_Active_Spr, UpdateLevel_btn_Deactive_Spr;



    [Header("------------ LevelUp Popup ------------")]
    public LevelUp_pnl levelUp_Pnl;

    [Header("------------ WelcomeBaack Popup ------------")]
    public GameObject WelComeBack_pnl;

    [Header("------------ Reward Popup ------------")]
    public Slider Two_x_Earning_slider;



    [Header("------------ Investment Popup ------------")]
    public GameObject Investment_pnl;
    public Text Investment_txt;


    [Header("------------ Not ENufe Coins Popup ------------")]
    public GameObject NotEnufeCoins_pnl;
    public Text NotEnufeCoins_Title_txt;
    public Text NotEnufeCoins_Msg_txt;
    public Text NotEnufeCoins_Coins_txt;



    public GameObject Reward_pnl;
    public GameObject Plus2Hores_pnl;
    public GameObject Twox_Experience_pnl;
    public GameObject BoostTime_pnl;
    public GameObject Setting_pnl;

    public GameObject MapRatingIncreseEffact_pnl;
    public Slider MapRatingIncreseEffact_MapRating_slider;
    public Text MapRatingIncreseEffact_MapRating_txt;
    public Text MapRatingIncreseEffact_MapName_txt;


    [Header("------------ RateUS Popup ------------")]
    public GameObject RateUs_pnl;

    [Header("------------ GetReward Popup ------------")]
    public GameObject GetReward_pnl;
    public Text RewardValue_txt;
    public Text RewardMsg_txt;


    public GameObject GiftBox_Pnl;
    public GameObject Collaction_pnl;
    public GameObject MegaHores_Pnl;

    public GameObject TwoX_Pnl;
    public GameObject PrasnalManager_pnl;

    public MegaHorseUnlock_pnl MegaHoresUnlock_pnl;


    public Text UpdateMessage_Text;
    public Text MaintenceMessage_Text;
    public GameObject Update_Panel;
    public GameObject Loding_Panel;
    public GameObject Adsmanager;
    public GameObject Maintenance_panel;
    public GameObject Privacy_pnl;

    public ParticleSystem TwoX1Min_PS;

    public CanvasScaler MainCam;

    private void Awake()
    {
        inst = this;

        //PlayerPrefs.DeleteAll();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (Screen.height>=2048)
        {
            MainCam.matchWidthOrHeight = 1f;
        }
        else
        {
            MainCam.matchWidthOrHeight = 0f;
        }

    }
    public void Start()
    {

        MapScrollbar.value = 0f;
        GameManager.inst.MainLevelPrograssUp(0);
        MainLevel_txt.text = "Level " + GameManager.LevelNo;

        UpdateValue_Map_btn();

        Hand.SetActive(GameManager.GameTutorial == 0);

        InvokeRepeating("Active_TwoX1Min", 0, 20);

        PrasnalManager_Btn.gameObject.SetActive(!PersonalManager_pnl.PersonalManager);
        Twox_IAP_btn.gameObject.SetActive(!TwoX_pnl.TwoXEarning);

        Privacy_pnl.SetActive(PlayerPrefs.GetString("PrivacyAccepted", "No") == "No");
        PlayerPrefs.SetString("PrivacyAccepted", "Yes");
    }
    private void Update()
    {

        GiftBox_txt.text = GameManager.GiftBoxCounter.ToString();


        UpdateBottom();
        UpdateTop();
    }
    private void Active_TwoX1Min()
    {

        TwoX1Min_PS.Play();
    }
    public void UpdateTop()
    {

        Main_Coin_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(GameManager.TotalCoins);

        MapRating_txt.text = GameManager.inst.CurrantMap.mapData.MapRate.ToString("0.000");
        MapRating_slider.value = (float)GameManager.inst.CurrantMap.mapData.MapRate;
    }

    public void UpdateBottom()
    {

        Map_Name_txt.text = GameManager.inst.CurrantMap.mapData.MapName.ToString();
        Total_Hores_txt.text = GameManager.inst.CurrantMap.mapData.TotalHores.ToString();

        if (GameManager.inst.DoubleEarningTime > 0)
            Hores_Earn_Coin_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(GameManager.inst.CurrantMap.mapData.HoresEarnCoin * 2);
        else
            Hores_Earn_Coin_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(GameManager.inst.CurrantMap.mapData.HoresEarnCoin);


        Currrant_Lvl_txt.text = "LVL " + GameManager.inst.CurrantMap.mapData.CurrantLevel.ToString();
        Target_Lvl_txt.text = "LVL " + GameManager.inst.MapTargetLevelList[GameManager.inst.CurrantMap.mapData.TargetLevelIndex].ToString();
        Update_Level_Coin_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(GameManager.inst.CurrantMap.mapData.LevelUpdateValue);

        UpdateLevel_btn.interactable = GameManager.TotalCoins >= GameManager.inst.CurrantMap.mapData.LevelUpdateValue;

        if (UpdateLevel_btn.interactable)
            UpdateLevel_btn.GetComponent<Image>().sprite = UpdateLevel_btn_Active_Spr;
        else
            UpdateLevel_btn.GetComponent<Image>().sprite = UpdateLevel_btn_Deactive_Spr;

        Level_Up_slider.minValue = GameManager.inst.CurrantMap.mapData.WasTargetLevel;
        Level_Up_slider.maxValue = GameManager.inst.MapTargetLevelList[GameManager.inst.CurrantMap.mapData.TargetLevelIndex];
        Level_Up_slider.value = GameManager.inst.CurrantMap.mapData.CurrantLevel;
    }

    public void LevelUp_btn_press()
    {
        if (GameManager.GameTutorial == 1)
            Hand.SetActive(false);

        UpdateLevel_btn.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

        if (GameManager.TotalCoins >= GameManager.inst.CurrantMap.mapData.LevelUpdateValue)
            GameManager.inst.CurrantMap.LevelUp();

    }

    public void MainLevelUp_btn_press()
    {

        if (GameManager.GameTutorial == 2)
            Hand.SetActive(false);

        GameManager.LevelNo++;
        GameManager.LevelPrograss = 0;

        GameManager.inst.MainLevelPrograssUp(0);

        MainLevel_txt.text = "Level " + GameManager.LevelNo;

        OpanLevelUp_Pnl();
        UpdateValue_Map_btn();
        Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelUp, new Firebase.Analytics.Parameter[] { new Firebase.Analytics.Parameter(Firebase.Analytics.FirebaseAnalytics.ParameterLevel, "Level " + GameManager.LevelNo), });
        FB.LogAppEvent("Level_" + GameManager.LevelNo);
        GameAnalytics.SetCustomDimension01("Level_" + GameManager.LevelNo);
    }

    public void OpanLevelUp_Pnl()
    {
        int Bonus = GameManager.inst.Bonus();

        if (GameManager.inst.AllMapList.Length > GameManager.TargetLevelNo)
        {
            if (GameManager.LevelNo > GameManager.inst.AllMapList[GameManager.TargetLevelNo].mapData.UnlockAfterLevel)
                GameManager.TargetLevelNo++;

            if (GameManager.inst.AllMapList.Length > GameManager.TargetLevelNo)
            {

                if (GameManager.LevelNo == GameManager.inst.AllMapList[GameManager.TargetLevelNo].mapData.UnlockAfterLevel)
                {

                    levelUp_Pnl.Lock_ic.gameObject.SetActive(false);
                    levelUp_Pnl.NewTrack_txt.text = "NEW TRACK UNLOCK";
                    levelUp_Pnl.NewTrack_txt.color = Color.green;
                }
                else
                {

                    levelUp_Pnl.Lock_ic.gameObject.SetActive(true);
                    levelUp_Pnl.NewTrack_txt.text = "NEW TRACK";
                    levelUp_Pnl.NewTrack_txt.color = Color.yellow;

                }
            }

        }

        if (GameManager.inst.AllMapList.Length > GameManager.TargetLevelNo)
            levelUp_Pnl.LevelUpPnl_Level_txt.text = "LVL " + GameManager.LevelNo + "/" + GameManager.inst.AllMapList[GameManager.TargetLevelNo].mapData.UnlockAfterLevel;


        //Map_ic.sprite


        levelUp_Pnl.Bonus = Bonus;

        levelUp_Pnl.Bonus_txt.text = "$" + AbbrevationUtility.AbbreviateNumber(Bonus);


        levelUp_Pnl.LevelUpPnl_LevelUp_slider.minValue = 0;

        if (GameManager.inst.AllMapList.Length > GameManager.TargetLevelNo)
        {
            levelUp_Pnl.LevelUpPnl_LevelUp_slider.minValue = GameManager.inst.AllMapList[GameManager.TargetLevelNo - 1].mapData.UnlockAfterLevel;
            levelUp_Pnl.LevelUpPnl_LevelUp_slider.maxValue = GameManager.inst.AllMapList[GameManager.TargetLevelNo].mapData.UnlockAfterLevel;

            levelUp_Pnl.Map_ic.sprite = AllLevel_btn_List[GameManager.TargetLevelNo].GetComponent<Image>().sprite;
        }

        levelUp_Pnl.LevelUpPnl_LevelUp_slider.value = GameManager.LevelNo;

        levelUp_Pnl.gameObject.SetActive(true);
    }

    public void UpdateValue_Map_btn()
    {
        GameManager.inst.AllMapList[0].mapData.ThisIslocked = false;

        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {

            AllLevel_btn_List[i].GetComponent<Button>().interactable = GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel <= GameManager.LevelNo;

            AllLevel_btn_List[i].transform.GetChild(1).gameObject.SetActive(GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel > GameManager.LevelNo);
            AllLevel_btn_List[i].transform.GetChild(2).gameObject.SetActive(GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel > GameManager.LevelNo);

            AllLevel_btn_List[i].transform.GetChild(2).GetComponent<Text>().text = "LVL " + GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel;


            AllLevel_btn_List[i].transform.GetChild(3).GetComponent<Text>().text = AbbrevationUtility.AbbreviateNumber(GameManager.inst.AllMapList[i].mapData.UnlockPrice_);

            AllLevel_btn_List[i].transform.GetChild(3).gameObject.SetActive(GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel <= GameManager.LevelNo && GameManager.inst.AllMapList[i].mapData.ThisIslocked);
            AllLevel_btn_List[i].transform.GetChild(4).gameObject.SetActive(GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel <= GameManager.LevelNo && GameManager.inst.AllMapList[i].mapData.ThisIslocked);


        }

    }

    public void MapUnlock_btn_press(int no)
    {


        if (GameManager.inst.AllMapList[no].mapData.UnlockPrice_ <= GameManager.TotalCoins)
        {
            // map unlock manthan map_unlock

            GameManager.TotalCoins -= GameManager.inst.AllMapList[no].mapData.UnlockPrice_;
            GameManager.inst.AllMapList[no].mapData.ThisIslocked = false;

            StartCoroutine(ApiManager.inst.UnlockMap(no + 1));

            UpdateValue_Map_btn();

            SelectedMap(no);
            Firebase.Analytics.FirebaseAnalytics.LogEvent("map_unlock", new Firebase.Analytics.Parameter[] { new Firebase.Analytics.Parameter("map_" + no, "Map " + no), });
            FB.LogAppEvent("map_" + no);
            GameAnalytics.SetCustomDimension02("map_" + no);
        }
        else
        {
            NotEnufeCoinsActive(GameManager.inst.AllMapList[no].mapData.MapName, GameManager.inst.AllMapList[no].mapData.UnlockPrice_, "TO PURCHASE THE TRACK YOU NEED:");

        }



    }


    public void LogMap_1Event()
    {
        FB.LogAppEvent("map_1");
    }


    public void SelectedMap(int no)
    {
        if (!GameManager.inst.AllMapList[no].mapData.ThisIslocked)
        {
            for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
            {
                if (no == i && GameManager.inst.AllMapList[i].mapData.UnlockAfterLevel <= GameManager.LevelNo)
                {
                    GameManager.inst.CurrantMap = GameManager.inst.AllMapList[i];

                    GameManager.inst.AllMapList[i].gameObject.SetActive(true);

                    AllLevel_btn_List[i].transform.GetChild(0).gameObject.SetActive(true);

                    //Camera.main.transform.parent.transform.position = new Vector3(GameManager.inst.AllMapList[i].transform.position.x, Camera.main.transform.parent.transform.position.y, Camera.main.transform.parent.transform.position.z);
                    //  Camera.main.transform.parent.transform.position = new Vector3(no*100, Camera.main.transform.parent.transform.position.y, Camera.main.transform.parent.transform.position.z);

                    GameManager.inst.AllMapList[i].Camera.SetActive(true);

                }
                else
                {

                    // GameManager.inst.AllMapList[i].gameObject.SetActive(false);

                    AllLevel_btn_List[i].transform.GetChild(0).gameObject.SetActive(false);
                    GameManager.inst.AllMapList[i].Camera.SetActive(false);




                }

            }
        }

    }

    public void ShowRewardedVideo(string key)
    {


        //UnityAdsManager.inst.ShowRewardedVideo(key);

        AdmobManger.inst.ShowRewarded(key);

        //FacebookAdsManager.Inst.ShowRewardedVideo(key);

    }

    public void ShowInterstitial()
    {


        // AdmobManger.inst.ShowIntetrtitial();


    }

    public void RateUS_btn_press()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        }
        else
        {
            Application.OpenURL("itms-apps://itunes.apple.com/app/id1528933963");
        }

    }
    public void Privacy_btn_press()
    {

        Application.OpenURL("https://sites.google.com/view/idle-life-tycoon/privacy-policy");

    }
    public void TOs_btn_press()
    {

        Application.OpenURL("https://sites.google.com/view/idle-life-tycoon/terms-condition");

    }

    public void MapRatingIncreseActive(double rating)
    {
        MapRatingIncreseEffact_pnl.SetActive(true);
        MapRatingIncreseEffact_MapRating_slider.value = (float)rating;
        MapRatingIncreseEffact_MapRating_txt.text = rating.ToString("0.000");
        MapRatingIncreseEffact_MapName_txt.text = GameManager.inst.CurrantMap.mapData.MapName;

    }
    public void NotEnufeCoinsActive(string title, long Coins, string msg)
    {
        NotEnufeCoins_pnl.SetActive(true);
        NotEnufeCoins_Title_txt.text = title;
        NotEnufeCoins_Msg_txt.text = msg;
        NotEnufeCoins_Coins_txt.text = "$" + AbbrevationUtility.AbbreviateNumber(Coins);
    }

    public void UpdateGame()
    {


        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL(PlayerPrefs.GetString("Android_UpdateLink"));
        }
        else
        {
            Application.OpenURL(PlayerPrefs.GetString("Ios_UpdateLink"));
        }

    }

    public void GetReward(string Value, string Msg)
    {

        RewardValue_txt.text = Value + " Coins";
        RewardMsg_txt.text = Msg;
        GetReward_pnl.SetActive(true);
    }

    public void CameraAngleChange()
    {

        GameManager.inst.CurrantMap.Camera.GetComponent<CameraManagment>().ChangeCamera_btn();

    }

}
