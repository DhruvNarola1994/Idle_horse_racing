using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivemantBox : MonoBehaviour
{
    public MapManagment mapManagment;

    public Text MapName_txt, CurrantBonusSpeed_txt;
    public Image Map_ic;
    public Text CurrantSpeed_txt;
    public Slider CurrantSpeed_Slider;
    public Slider CurrantSpeed_Star_Slider;

    public Button Get_btn;
    public Sprite GetBtn_Active_Spr, GetBtn_Deactive_Spr;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrantBonusSpeed_txt.text = "Current Speed Bonus: +"+ mapManagment.mapData.CurrantSpeedBonus_Increse_Value + "%";

        MapName_txt.text = mapManagment.mapData.MapName;
        CurrantSpeed_txt.text = "Speed\n" + mapManagment.mapData.CurrantSpeedBonus + "%";

        CurrantSpeed_Slider.value = mapManagment.mapData.CurrantSpeedBonus_sliderValue;
        CurrantSpeed_Star_Slider.value = mapManagment.mapData.CurrantSpeedBonus_StarSliderValue;


        Get_btn.interactable = CurrantSpeed_Slider.value == CurrantSpeed_Slider.maxValue /*&& mapManagment.mapData.CurrantSpeedBonus_StarSliderValue < 5*/;

        _ = Get_btn.interactable == true ? Get_btn.GetComponent<Image>().sprite = GetBtn_Active_Spr : Get_btn.GetComponent<Image>().sprite = GetBtn_Deactive_Spr;

        Map_ic.sprite = UiManager.inst.AllLevel_btn_List[transform.GetSiblingIndex()].GetComponent<Image>().sprite;
    }


    public void Get_btn_press()
    {

        mapManagment.mapData.CurrantSpeedBonus += mapManagment.mapData.CurrantSpeedBonus_Increse_Value;
        mapManagment.mapData.CurrantSpeedBonus_sliderValue = 0;

        if (mapManagment.mapData.CurrantSpeedBonus_StarSliderValue == 5)
        {

            mapManagment.mapData.CurrantSpeedBonus_StarSliderValue = 0;
            mapManagment.mapData.CurrantSpeedBonus_Increse_Value += 5;

        }
        else { 
        
        mapManagment.mapData.CurrantSpeedBonus_StarSliderValue += 1;


        }



        if (GameManager.GameTutorial == 8)
            UiManager.inst.Hand.SetActive(false);
    }
}
