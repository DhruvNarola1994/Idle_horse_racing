using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{
    public static ApiManager inst;

    private void Awake()
    {
        inst = this;

    

    }


   public IEnumerator UnlockMap(int Mapno)
    {
        WWWForm form = new WWWForm();
        form.AddField("mapnumber", Mapno);

        using (UnityWebRequest www = UnityWebRequest.Post("http://134.209.149.86:3500/horse/mCounter", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("<color=yellow>Data upload complete!</color>");
            }
        }
    }
}
