using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public static long TotalCoins { get { return long.Parse(PlayerPrefs.GetString("TotalCoins", "8")); } set { PlayerPrefs.SetString("TotalCoins", value.ToString()); } }
    public static int GiftBoxCounter { get { return PlayerPrefs.GetInt("GiftBoxCounter", 0); } set { PlayerPrefs.SetInt("GiftBoxCounter", value); } }
    public static int LevelNo { get { return PlayerPrefs.GetInt("LevelNo", 1); } set { PlayerPrefs.SetInt("LevelNo", value); } }
    public static int TargetLevelNo { get { return PlayerPrefs.GetInt("TargetLevelNo", 1); } set { PlayerPrefs.SetInt("TargetLevelNo", value); } }
    public static float LevelPrograss { get { return PlayerPrefs.GetFloat("LevelPrograss", 0); } set { PlayerPrefs.SetFloat("LevelPrograss", value); } }
    public static int LevelPrograssValue { get { return PlayerPrefs.GetInt("LevelPrograssValue", 5); } set { PlayerPrefs.SetInt("LevelPrograssValue", value); } }
    public static int GameTutorial { get { return PlayerPrefs.GetInt("GameTutorial", 0); } set { PlayerPrefs.SetInt("GameTutorial", value); } }

    public MapManagment[] AllMapList;

    public MapManagment CurrantMap;

    public int[] MapTargetLevelList;
    public float[] RatingValues;
    public double[] RatingValues_;


    public ParticleSystem Coins_PS;
    public ParticleSystem DoubleCoinsEarning_PS;

    public float DoubleEarningTime;


   
    public GameObject EarningCoins_prefab;

    public IAPManagment iAPManagment;

    [HideInInspector]
    public int Investment;

    private void Awake()
    {
        inst = this;
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {

        CurrantMap = AllMapList[0];

        CurrantMap.gameObject.SetActive(true);
        CurrantMap.mapData.ThisIslocked = false;

        Camera.main.transform.parent.transform.position = new Vector3(CurrantMap.transform.position.x, Camera.main.transform.parent.transform.position.y, Camera.main.transform.parent.transform.position.z);



        for (int i = 0; i < AllMapList.Length; i++)
        {
            if (!AllMapList[i].mapData.ThisIslocked)
            {

                AllMapList[i].gameObject.SetActive(true);

            }
        }

        UiManager.inst.WelComeBack_pnl.SetActive(TargetTime.GetDifferenceHours("OffLineGameEarnig") > 0);

        InvokeRepeating("ActiveOffer", 20, 20);
        Invoke("GanaretBonusCoin", 50 - ((20 / 100) * CurrantMap.mapData.CurrantSpeedBonus));
    }


    private void OnApplicationQuit()
    {
        TargetTime.SetTime("OffLineGameEarnig");
    }
    //private void OnApplicationFocus(bool focus)
    //{
    //    TargetTime.SetTime("OffLineGameEarnig");

    //}
    //private void OnApplicationPause(bool pause)
    //{
    //    TargetTime.SetTime("OffLineGameEarnig");

    //}

    // Update is called once per frame
    void Update()
    {


        if (DoubleEarningTime > 0)
        {
            DoubleCoinsEarning_PS.gameObject.SetActive(true);
            DoubleEarningTime -= Time.deltaTime;
            UiManager.inst.Two_x_Earning_slider.value = DoubleEarningTime;
        }
        else
        {

            DoubleCoinsEarning_PS.gameObject.SetActive(false);

        }
    }
    public void ActiveOffer()
    {
        //if (!IronSourceManager.inst.LoadedVideo())
        //    return;

        int temp = Random.Range(0, 4);


        switch (temp)
        {
            case 1:
                UiManager.inst.BootTime.SetActive(true);
                break;
            case 2:
                UiManager.inst.Plus2Hores.SetActive(true);
                break;
            case 3:
                UiManager.inst.TwoXExperience.SetActive(true);
                break;

        }

    }

    public int Bonus()
    {
        int Bonus = 0; 

        if (LevelNo < 5)
            Bonus = Random.Range(20 * LevelNo, 100 * LevelNo) * LevelNo;
        else if (LevelNo >= 5 && LevelNo < 10)
            Bonus = 1000 * LevelNo;
        else if (LevelNo >=10 && LevelNo < 20)
            Bonus = 2000 * LevelNo;
        else if (LevelNo >= 20 && LevelNo <= 40)
            Bonus = 10000 * LevelNo;
        else
            Bonus = 20000 * LevelNo;


        return Bonus;
    }

    public void MainLevelPrograssUp(float prograss)
    {


        LevelPrograss += prograss;

        if (LevelPrograss >= 100)
        {
            UiManager.inst.MainLevelUp_btn.gameObject.SetActive(true);
            UiManager.inst.MainLevelUp_Slider.gameObject.SetActive(false);


            if (GameTutorial == 1)
            {
                GameTutorial++;
                UiManager.inst.Hand.SetActive(true);

            }

        }
        else
        {

            UiManager.inst.MainLevelUp_btn.gameObject.SetActive(false);
            UiManager.inst.MainLevelUp_Slider.gameObject.SetActive(true);


            UiManager.inst.MainLevelUp_Slider.value = LevelPrograss;
        }

    }
    public void DoubleEarning_1Min()
    {

        UiManager.inst.Reward_pnl.SetActive(false);
        DoubleEarningTime += 60;

    }

    public void GanaretBonusCoin()
    {

        CancelInvoke("GanaretBonusCoin");
        Invoke("GanaretBonusCoin", 50 - ((20 / 100) * CurrantMap.mapData.CurrantSpeedBonus));


       

        if (Random.Range(0, 10) < 7)
        {

            GameObject Bc = Instantiate(PrefabsManager.inst.Bonus_Coin,UiManager.inst.transform);
            Bc.GetComponent<Animator>().SetInteger("NoOfAnim", Random.Range(1,6));
       }
       else
       {
            Investment = Bonus();
            UiManager.inst.Investment_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(Investment);

            GameObject Bc = Instantiate(PrefabsManager.inst.Bonus_Coin, UiManager.inst.transform);
            Bc.GetComponent<Animator>().SetInteger("NoOfAnim", Random.Range(1, 6));
            Bc.GetComponent<Bonus_Coin>().GetBonusAfterVideo = true;
        }


    }

    public void EarningCoinsShow(Vector3 pos, int Coins)
    {
        

        if (CameraManagment.CameraView == 0 || CameraManagment.CameraView == 1)
        {

            GameObject EarningCoins = Instantiate(EarningCoins_prefab, GameObject.Find("Canvas").transform);

            // Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, pos);
            //  EarningCoins.transform.GetComponent<RectTransform>().anchoredPosition = screenPoint - GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta / 2f;
            EarningCoins.transform.position = worldToUISpace(GameObject.Find("Canvas").GetComponent<Canvas>(), pos);
            EarningCoins.transform.GetChild(0).GetComponent<Text>().text = AbbrevationUtility.AbbreviateNumber(Coins);
        }

    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}


