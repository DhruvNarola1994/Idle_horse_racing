using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void Desable_Obj() {

        gameObject.SetActive(false);

    } 
    
    public void Destroid_obj() {

        Destroy(gameObject);
    }
}
