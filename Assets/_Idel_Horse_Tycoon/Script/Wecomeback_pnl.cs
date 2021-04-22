using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wecomeback_pnl : MonoBehaviour
{
    public Text Hire_Btn_txt;
    public Text Double_Coins_txt;
    public Text Coins_txt;
    public Slider slider;

    private int Hours;

    public int Coins;

    public GameObject PraasnalManager_pnl;

    // Start is called before the first frame update
    public void Start()
    {
        Coins = 0;

        Hours = TargetTime.GetDifferenceHours("OffLineGameEarnig");

        if (Hours > 8)
            Hours = 8;

        Debug.LogError("Hours =" + Hours);

        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {
            if (!GameManager.inst.AllMapList[i].mapData.ThisIslocked)
            {

                int h = GameManager.inst.AllMapList[i].mapData.TotalHores;
                int e = GameManager.inst.AllMapList[i].mapData.HoresEarnCoin;

                Coins += (h * e) * (Hours * 3);
            }
        }

       

        PraasnalManager_pnl.SetActive(!PersonalManager_pnl.PersonalManager);

        if (PersonalManager_pnl.PersonalManager)
            Coins *= 2;
        else
            Double_Coins_txt.text = "$ " + AbbrevationUtility.AbbreviateNumber(Coins * 2);


        Coins_txt.text = AbbrevationUtility.AbbreviateNumber(Coins);
        slider.value = (float)Hours;

       
       Hire_Btn_txt.text = GameManager.inst.iAPManagment.GetPrice(GameManager.inst.iAPManagment.packs[2]);
    }


    private void OnDisable()
    {
        GameManager.TotalCoins += Coins;
        GameManager.inst.Coins_PS.Play();
    }
    // Update is called once per frame
    public void Hire_PrasnalManager()
    {


       GameManager.inst.iAPManagment.BuyPack(2);

    }
}
