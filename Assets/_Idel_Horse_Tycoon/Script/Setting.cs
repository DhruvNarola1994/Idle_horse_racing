using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    public Toggle sount_toggle;
    public Toggle Music_toggle;
    public Toggle Vibration_toggle;


    // Start is called before the first frame update
    void Start()
    {
        sount_toggle.isOn = AudioManager.SoundOn;
        Music_toggle.isOn = AudioManager.MusicOn;
    }


    public void Sound_Toggle_press()
    {

        AudioManager.SoundOn = sount_toggle.isOn;

    }

    public void Music_Toggle_press()
    {

        AudioManager.MusicOn = Music_toggle.isOn;

        AudioManager.Inst.MPlay("bg");

    }

    public void Vibration_Toggle_press()
    {

        Vibration.VibrationOn = Vibration_toggle.isOn;

        Vibration.Vibrate(50);
    }
    public void FacebookLogin_btn() { 
    
    
    
    }

}
