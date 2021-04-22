using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Coin : MonoBehaviour
{
    public bool GetBonusAfterVideo;


    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (GetBonusAfterVideo)
        {
            UiManager.inst.Investment_pnl.SetActive(true);
            Destroy(gameObject);


        }
        else
        {


            int Bonus = GameManager.inst.Bonus();

            UiManager.inst.GetReward(Bonus.ToString(), "");

            GameManager.TotalCoins += Bonus;

            //GameManager.inst.EarningCoinsShow(transform.position + Vector3.up * 2, Bonus);


           //Destroy(Instantiate(PrefabsManager.inst.CoinsBlast, transform.position, Quaternion.identity),2);


            Destroy(gameObject);
        }
    }
}
