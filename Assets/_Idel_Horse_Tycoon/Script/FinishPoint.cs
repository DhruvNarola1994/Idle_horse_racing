using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public MapManagment mapManagment;

    public GameObject Ps_right, Ps_Left;


    private void Update()
    {
        Ps_right.SetActive(TwoX_Experience.IsActive);
        Ps_Left.SetActive(TwoX_Experience.IsActive);
    }

    public void HoresEarning(bool Double)
    {
        if (mapManagment == GameManager.inst.CurrantMap)
        {

            float progras = 100 / GameManager.LevelPrograssValue;


            if (TwoX_Experience.IsActive)
                GameManager.inst.MainLevelPrograssUp(progras * 2);
            else
                GameManager.inst.MainLevelPrograssUp(progras);

        }



        if (GameManager.inst.DoubleEarningTime > 0 || Double || TwoX_pnl.TwoXEarning)
        {

            GameManager.TotalCoins += (mapManagment.mapData.HoresEarnCoin * 2);

            
            GameManager.inst.EarningCoinsShow(transform.position + Vector3.up * 5, mapManagment.mapData.HoresEarnCoin * 2);

        }
        else
        {
            GameManager.TotalCoins += mapManagment.mapData.HoresEarnCoin;
            GameManager.inst.EarningCoinsShow(transform.position + Vector3.up * 5, mapManagment.mapData.HoresEarnCoin);
        }


    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Hores" || other.gameObject.tag == "Fast_horse" || other.gameObject.tag == "Black_horse")
        {

            if (GameManager.GameTutorial == 0)
            {
                GameManager.GameTutorial++;
                UiManager.inst.Hand.SetActive(true);

            }


            HoresEarning(false);

        }
        else if (other.gameObject.tag == "Big_horse")
        {

            HoresEarning(true);

        }
    }
}
