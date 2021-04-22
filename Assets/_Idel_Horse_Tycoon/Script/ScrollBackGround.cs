using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackGround : MonoBehaviour
{
    public float Speed;
    public Vector2 Offset;


   

    // Update is called once per frame
    void FixedUpdate()
    {
       
            gameObject.GetComponent<Image>().material.mainTextureOffset += Offset;

    }
}
