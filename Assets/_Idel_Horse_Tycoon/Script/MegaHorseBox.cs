using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaHorseBox : MonoBehaviour
{
    public MapManagment mapManagment;



    public List<Hores> Hores;
    public Sprite GetBtn_Active_Spr, GetBtn_Deactive_Spr;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Hores.Count; i++)
        {

            Hores[i].MapName_txt.text = mapManagment.mapData.MagaHoresList[i].Name;
            Hores[i].Value_txt.text = mapManagment.mapData.MagaHoresList[i].CurrantValue + "/" + mapManagment.mapData.MagaHoresList[i].UnloackValue;
            Hores[i].Hores_ic.sprite = mapManagment.mapData.MagaHoresList[i].MegaHores_ic;

            Hores[i].Claim_btn.gameObject.SetActive(mapManagment.mapData.MagaHoresList[i].CurrantValue >= mapManagment.mapData.MagaHoresList[i].UnloackValue);
            Hores[i].Claim_btn.interactable=!mapManagment.mapData.MagaHoresList[i].IsClailed;
            Hores[i].Value_txt.gameObject.SetActive(!Hores[i].Claim_btn.gameObject.activeSelf);

            if (Hores[i].Claim_btn.interactable)
                Hores[i].Claim_btn.GetComponent<Image>().sprite = GetBtn_Active_Spr;
            else  
                Hores[i].Claim_btn.GetComponent<Image>().sprite = GetBtn_Deactive_Spr;
        }

    }

    public void Claim_btn_press(int no)
    {


        //GameObject.FindObjectOfType<Collaction_pnl>().GetComponent<Animator>().Play("Popup_Close");
        ////mapManagment.mapData.MagaHoresList[no].IsClailed = true; 
        //mapManagment.GanaretMegaHores(no); 

        UiManager.inst.MegaHoresUnlock_pnl.No = no;
        UiManager.inst.MegaHoresUnlock_pnl.Horse_ic.sprite = mapManagment.mapData.MagaHoresList[no].MegaHores_ic;
        UiManager.inst.MegaHoresUnlock_pnl.Pricevalue = mapManagment.mapData.MagaHoresList[no].GiftCoins;
        UiManager.inst.MegaHoresUnlock_pnl.mapManagment = mapManagment;
        UiManager.inst.MegaHoresUnlock_pnl.gameObject.SetActive(true);


        if (GameManager.GameTutorial == 9)
            UiManager.inst.Hand.SetActive(false);
    }
}
[Serializable]
public class Hores
{

    public Text MapName_txt;
    public Image Hores_ic;
    public Text Value_txt;
    public Button Claim_btn;
}
