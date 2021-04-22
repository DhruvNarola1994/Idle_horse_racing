using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plus_2_Hores_Managment : MonoBehaviour
{

    public bool IsActive;

    public GameObject Timer;
    public Text Timer_txt;

    public Slider Slider;

    public ParticleSystem particleSystem;

    public static float TimerCounter;

    private void OnEnable()
    {
        TimerCounter = 10;
        Slider.value = 10;

        IsActive = false;


        particleSystem.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!UiManager.inst.Plus2Hores_pnl.activeSelf)
        {

            if (!IsActive)
            {
                TimerCounter -= Time.deltaTime;
                Slider.value = TimerCounter;

                if (TimerCounter < 5)
                {
                    particleSystem.gameObject.SetActive(true);

                }


                gameObject.SetActive(TimerCounter > 0);



            }
            else
            {

                TimerCounter -= Time.deltaTime;


                particleSystem.gameObject.SetActive(false);


                if (TimerCounter < 0)
                {

                    gameObject.SetActive(false);
                }

                string minutes = Mathf.Floor(TimerCounter / 60).ToString("00");
                string seconds = (TimerCounter % 60).ToString("00");


                Timer_txt.text = minutes + ":" + seconds;
            }

        }
        Timer.SetActive(IsActive);
        Slider.gameObject.SetActive(!IsActive);
        gameObject.GetComponent<Button>().interactable = !IsActive;
    }


    public void Button_press()
    {
        TimerCounter = 60;
        IsActive = true;
        UiManager.inst.Plus2Hores_pnl.SetActive(false);

        for (int i = 0; i < GameManager.inst.AllMapList.Length; i++)
        {
            if (!GameManager.inst.AllMapList[i].mapData.ThisIslocked)
            {
                GameManager.inst.AllMapList[i].GanaretTempHores(0);
                GameManager.inst.AllMapList[i].GanaretTempHores(2);
            }
        }  

       // GameManager.inst.CurrantMap.GanaretTempHores(0);
       // GameManager.inst.CurrantMap.GanaretTempHores(2);
    }
}
