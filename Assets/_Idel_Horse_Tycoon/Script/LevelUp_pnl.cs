using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp_pnl : MonoBehaviour
{

    public Text LevelUpPnl_Level_txt;
    public Text Bonus_txt,NewTrack_txt;
    public Image Map_ic,Lock_ic;
    public Slider LevelUpPnl_LevelUp_slider;

    public int Bonus;

    private void OnEnable()
    {
        if(GameManager.LevelPrograssValue<97)
        GameManager.LevelPrograssValue += 3;
    }

 

    private void OnDisable()
    {
        GameManager.TotalCoins += Bonus;
        GameManager.GiftBoxCounter++;
        GameManager.inst.Coins_PS.Play();

        if (GameManager.LevelNo == 10)
            UiManager.inst.RateUs_pnl.SetActive(true);


        if (GameManager.GameTutorial == 2)
        {
            GameManager.GameTutorial++;
            UiManager.inst.Hand.SetActive(true);

        }

    }
}
