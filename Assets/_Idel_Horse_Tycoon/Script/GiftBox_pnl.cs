using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBox_pnl : MonoBehaviour
{
    public Text Parts_txt;
    public Text msg_txt;
    public Text Price_txt;

    public Button Opan_btn;

    public MegaHores_pnl megaHores_Pnl;


    // Start is called before the first frame update
    public void OnEnable()
    {

        if (GameManager.GiftBoxCounter > 0)
        {
            Parts_txt.text = "Parts: +1";
            msg_txt.text = "CONTAIN 1 MEGA MACHINE PARTS. IF A PART OF THE RECEIVED MACHINE IS CAUGHT, IT WILL BE AUTOMATICALLY REDEEMED FOR COINS";
            Price_txt.gameObject.SetActive(false);

        }
        else
        {

            Parts_txt.text = "Parts: +4";
            msg_txt.text = "CONTAIN 4 MEGA MACHINE PARTS. IF A PART OF THE RECEIVED MACHINE IS CAUGHT, IT WILL BE AUTOMATICALLY REDEEMED FOR COINS";

         
           
           Price_txt.text = GameManager.inst.iAPManagment.GetPrice(GameManager.inst.iAPManagment.packs[3]);
            Price_txt.gameObject.SetActive(true);


        }

        if (GameManager.GameTutorial == 3)
        {
            GameManager.GameTutorial++;
            UiManager.inst.Hand.SetActive(true);

        }


    }
    public void Opan_btn_press()
    {

        if (GameManager.GiftBoxCounter > 0)
        {
            GameManager.GiftBoxCounter--;

            for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
            {
                for (int j = 0; j < GameManager.inst.AllMapList.Length; j++)
                {
                    if (!GameManager.inst.AllMapList[j].mapData.ThisIslocked && GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].CurrantValue < GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].UnloackValue)
                    {

                        GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].CurrantValue++;

                        Debug.Log("<color=yellow>" + GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].Name + "</color>");

                        megaHores_Pnl.Hores_ic.sprite = GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].MegaHores_ic;
                        megaHores_Pnl.Value_txt.text = GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].CurrantValue + "/" + GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].UnloackValue;
                        megaHores_Pnl.Value_slider.maxValue = GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].UnloackValue;
                        megaHores_Pnl.Value_slider.value = GameManager.inst.AllMapList[j].mapData.MagaHoresList[i].CurrantValue;

                        megaHores_Pnl.gameObject.SetActive(true);
                        gameObject.SetActive(false);

                        return;
                    }

                }
            }

        }
        else
        {

           GameManager.inst.iAPManagment.BuyPack(3);

            //IAP
        }

        if (GameManager.GameTutorial == 4)
            UiManager.inst.Hand.SetActive(false);

    }
}
