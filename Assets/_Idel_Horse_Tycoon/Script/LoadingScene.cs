using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{

    public Slider ProgressBar;
    public Text ProgressText;
    public Text Ver_txt;

    // Start is called before the first frame update
    void Start()
    {
        //  StartCoroutine(LoadAsynchronously(1));
        ProgressBar.value=0;


        Load_Fake_Loading();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Ver_txt.text = "Ver. " + Application.version;

    }

    public void Load_Fake_Loading() {

        ProgressBar.value += Random.Range(10, 20);

        if (/*ProgressBar.value >= 100 && */GetDataFromeJson.DataAlredyGet) {

            SceneManager.LoadScene(1);

        }


        Invoke("Load_Fake_Loading", Random.Range(1,3));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            ProgressBar.value = progress*100;
            ProgressText.text = progress * 100f + "%";
            yield return null; 
        }
    }
}
