using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Vector3 Offset;
    public float temp;

    public bool MoveWithObject;
    public bool OnliyRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (MoveWithObject)
        {

            //transform.GetChild(3).transform.position = Offset + GameObject.FindGameObjectWithTag("Hores").transform.position;
            transform.position = GameManager.inst.CurrantMap.mapData.AllHoresList[0].transform.position - transform.forward * temp + Offset;
            //transform.GetChild(3).transform.LookAt(GameManager.inst.CurrantMap.mapData.AllHoresList[0].transform);

        }

        if (OnliyRotation)
        {


            transform.LookAt(GameManager.inst.CurrantMap.mapData.AllHoresList[0].transform);

        }

    }
}
