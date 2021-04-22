using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaHorseUnlock_pnl : MonoBehaviour
{
    public int No;
    public int Pricevalue;

    public Image Horse_ic;
    public Text Pricevalue_txt;
    public Button Get_btn;

    public MapManagment mapManagment;


    // Start is called before the first frame update
    void OnEnable()
    {
        Pricevalue_txt.text = AbbrevationUtility.AbbreviateNumber(Pricevalue);

        if (GameManager.GameTutorial == 9)
        {
            GameManager.GameTutorial++;
            UiManager.inst.Hand.SetActive(true);

        }
    }

    // Update is called once per frame
    public void Get_btn_press() {

        GameObject.FindObjectOfType<Collaction_pnl>().GetComponent<Animator>().Play("Popup_Close");
        mapManagment.GanaretMegaHores(No);
        GameManager.TotalCoins += Pricevalue;
        GameManager.inst.Coins_PS.Play();

        if (GameManager.GameTutorial == 10)
            UiManager.inst.Hand.SetActive(false);

       
    }

    private void OnDisable()
    {
        //if (GameManager.GameTutorial == 10)
        //{
        //    GameManager.GameTutorial++;
        //    UiManager.inst.Hand.SetActive(true);

        //}
    }
}
