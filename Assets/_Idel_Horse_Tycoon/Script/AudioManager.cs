using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Inst;


    public static bool SoundOn
    {
        get
        {
            return (PlayerPrefs.GetInt("Sound", 1) == 1);
        }
        set
        {
            PlayerPrefs.SetInt("Sound", value == true ? 1 : 0);
        }
    }

    public static bool MusicOn
    {
        get
        {
            return (PlayerPrefs.GetFloat("Music", 1) == 1);
        }
        set
        {
            PlayerPrefs.SetFloat("Music", value == true ? 1 : 0);
        }
    }

    public SounsManager[] sounsManagers;


    private void Awake()
    {
        if (!Inst)
            Inst = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);

        for (int i = 0; i < sounsManagers.Length; i++)
        {
            AudioSource a = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            sounsManagers[i].AudioSource = a;
            sounsManagers[i].AudioSource.clip = sounsManagers[i].audioClip;
            sounsManagers[i].AudioSource.loop = sounsManagers[i].IsLoop;
            sounsManagers[i].AudioSource.playOnAwake = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        MPlay("bg");
    }

    internal static bool IsMusicPlay = true;


    public void MPlay(string soundname)
    {

        if (MusicOn && IsMusicPlay)
        {

            foreach (SounsManager sm in sounsManagers)
            {
                if (sm.name == soundname)
                {
                    sm.AudioSource.Play();

                }
            }
        }
        else {


            Stop(soundname);
        }

    }
    public void SPlay(string soundname)
    {

        if (SoundOn)
        {

            foreach (SounsManager sm in sounsManagers)
        {
            if (sm.name == soundname)
            {

                sm.AudioSource.Play();

            }
        }
        }

    }
    public void Stop(string soundname)
    {


        foreach (SounsManager sm in sounsManagers)
        {
            if (sm.name == soundname)
            {

                sm.AudioSource.Stop();

            }
        }

    }
}

[System.Serializable]
public class SounsManager
{
    public string name;
    public AudioClip audioClip;
    [HideInInspector]
    public AudioSource AudioSource;
    public bool IsLoop;
}
