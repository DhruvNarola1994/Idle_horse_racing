using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoX_pnl : MonoBehaviour
{
    public Text button_txt;
  

    public static bool TwoXEarning { get { return PlayerPrefs.GetInt("TwoXEarning", 0) == 1 ? true : false; } set { PlayerPrefs.SetInt("TwoXEarning", value == true ? 1 : 0); } }


    // Start is called before the first frame update
    void Start()
    {

       button_txt.text = "Hire " + GameManager.inst.iAPManagment.GetPrice(GameManager.inst.iAPManagment.packs[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hire_btn_press() {

       GameManager.inst.iAPManagment.BuyPack(1);


    }
}
