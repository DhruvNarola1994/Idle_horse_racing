using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagment : MonoBehaviour
{
    public static int CameraView { get { return PlayerPrefs.GetInt("CameraView", 0); } set { PlayerPrefs.SetInt("CameraView", value); } }


    // Start is called before the first frame update
    void OnEnable()
    {

        transform.GetChild(0).gameObject.SetActive(CameraView == 0);
        transform.GetChild(1).gameObject.SetActive(CameraView == 1);
        transform.GetChild(2).gameObject.SetActive(CameraView == 2);
        transform.GetChild(3).gameObject.SetActive(CameraView == 3);
        transform.GetChild(4).gameObject.SetActive(CameraView == 4);
    }


    public void ChangeCamera_btn()
    {

        if (CameraView == 0)
        {

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);


            CameraView = 1;


        }
        else if (CameraView == 1)
        {


            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);

            CameraView = 2;

        }
        else if (CameraView == 2)
        {


            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(false);

            CameraView = 3;

        }
        else if (CameraView == 3)
        {


            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            CameraView = 4;

        }
        else
        {


            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);


            CameraView = 0;

        }

    }
}
