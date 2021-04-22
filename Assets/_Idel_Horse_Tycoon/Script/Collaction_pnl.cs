using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collaction_pnl : MonoBehaviour
{
    public GameObject GiftBox_pnl;

    public Transform AchivementParent;
    public Transform MegaHoresParent;

    public Button Achivement_btn;

    public GameObject Achivement_pnl;
    public GameObject MegaHores_pnl;



    // Start is called before the first frame update
    private void OnEnable()
    {
        GiftBox_pnl.SetActive(GameManager.GiftBoxCounter > 0);


        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {
            AchivementParent.GetChild(i).GetComponent<AchivemantBox>().mapManagment = GameManager.inst.AllMapList[i];
        }

        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {
            MegaHoresParent.GetChild(i).GetComponent<MegaHorseBox>().mapManagment = GameManager.inst.AllMapList[i];
        }


        if (GameManager.GameTutorial == 6)
            UiManager.inst.Hand.SetActive(false);

        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {
            if (GameManager.inst.AllMapList[i].mapData.CurrantSpeedBonus_sliderValue >= 100 && !Achivement_pnl.activeSelf)
            {
                Achivement_btn.transform.GetChild(0).gameObject.SetActive(true);
                return;
            }
            else
            {

                Achivement_btn.transform.GetChild(0).gameObject.SetActive(false);

            }
        }

    }
    private void Update()
    {


        if (!GiftBox_pnl.activeSelf && !UiManager.inst.MegaHores_Pnl.activeSelf && GameManager.inst.AllMapList[0].mapData.CurrantSpeedBonus_sliderValue >= 100)
        {

            if (GameManager.GameTutorial == 6)
            {
                GameManager.GameTutorial++;
                UiManager.inst.Hand.SetActive(true);

            }


        }

        if (!GiftBox_pnl.activeSelf && !GiftBox_pnl.GetComponent<GiftBox_pnl>().megaHores_Pnl.gameObject.activeSelf && Achivement_pnl.activeSelf && GameManager.inst.AllMapList[0].mapData.CurrantSpeedBonus_sliderValue >= 100)
        {

            if (GameManager.GameTutorial == 7)
            {
                GameManager.GameTutorial++;
                UiManager.inst.Hand.SetActive(true);

            }


        }

        if (MegaHores_pnl.activeSelf && !GiftBox_pnl.activeSelf && !Achivement_pnl.activeSelf && !GiftBox_pnl.GetComponent<GiftBox_pnl>().megaHores_Pnl.gameObject.activeSelf && GameManager.inst.AllMapList[0].mapData.MagaHoresList[0].CurrantValue >= GameManager.inst.AllMapList[0].mapData.MagaHoresList[0].UnloackValue)
        {

            if (GameManager.GameTutorial == 8)
            {
                GameManager.GameTutorial++;
                UiManager.inst.Hand.SetActive(true);

            }


        }
    }

    public void Achivment_btn_press()
    {


        if (GameManager.GameTutorial == 7 || GameManager.GameTutorial == 9)
            UiManager.inst.Hand.SetActive(false);

        Achivement_btn.transform.GetChild(0).gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        if (GameManager.GameTutorial == 9)
            UiManager.inst.Hand.SetActive(false);
    }

    public void Gift_btn_press()
    {

        GiftBox_pnl.SetActive(true);
    }


}
