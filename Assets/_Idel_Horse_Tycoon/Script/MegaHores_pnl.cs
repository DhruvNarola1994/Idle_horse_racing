using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaHores_pnl : MonoBehaviour
{

    public Image Hores_ic;
    public Text Value_txt;
    public Slider Value_slider;

    public Button Con_btn;

    private void OnEnable()
    {
        if (GameManager.GameTutorial == 4)
        {
            GameManager.GameTutorial++;
            UiManager.inst.Hand.SetActive(true);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        if (GameManager.GameTutorial == 5)
            UiManager.inst.Hand.SetActive(false);
    }
}
