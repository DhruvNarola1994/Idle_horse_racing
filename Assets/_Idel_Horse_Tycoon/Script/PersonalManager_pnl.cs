using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalManager_pnl : MonoBehaviour
{
    public Text Hire_txt;

  

    public static bool PersonalManager { get { return PlayerPrefs.GetInt("PersonalManager", 0) == 1 ? true : false; } set { PlayerPrefs.SetInt("PersonalManager", value == true ? 1 : 0); } }


    // Start is called before the first frame update
    void Start()
    {
      
        Hire_txt.text = "Hire " + GameManager.inst.iAPManagment.GetPrice(GameManager.inst.iAPManagment.packs[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Hire_btn_press()
    {

        GameManager.inst.iAPManagment.BuyPack(2);


    }
}
