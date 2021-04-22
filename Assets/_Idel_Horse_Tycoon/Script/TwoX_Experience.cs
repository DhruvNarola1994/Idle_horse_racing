using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoX_Experience : MonoBehaviour
{

    public static bool IsActive = false;

    public GameObject Timer;
    public Text Timer_txt;

    public Slider Slider;

    public ParticleSystem particleSystem;


    public float TimerCounter;

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
        if (!UiManager.inst.Twox_Experience_pnl.activeSelf)
        {

            if (!IsActive)
            {
                TimerCounter -= Time.deltaTime;
                Slider.value = TimerCounter;

                gameObject.SetActive(TimerCounter > 0);


                if (TimerCounter < 5)
                {
                    particleSystem.gameObject.SetActive(true);

                }


            }
            else
            {

                TimerCounter -= Time.deltaTime;

                particleSystem.gameObject.SetActive(false);


                if (TimerCounter < 0)
                {
                    IsActive = false;
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
        UiManager.inst.Twox_Experience_pnl.SetActive(false);

    }
}
