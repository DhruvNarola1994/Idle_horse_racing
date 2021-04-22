using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour ,IPointerClickHandler
{
    public MapManagment mapManagment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void Update()
    //{
    //        // Check if the left mouse button was clicked
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            // Check if the mouse was clicked over a UI element
    //            if (!EventSystem.current.IsPointerOverGameObject())
    //            {
    //                Vibration.Vibrate(50);

    //                AudioManager.Inst.SPlay("Horse_Neighing");

    //                for (int i = 0; i < mapManagment.mapData.AllHoresList.Count; i++)
    //                {
    //                    mapManagment.mapData.AllHoresList[i].GetComponent<HoresController>().FastRun(7);
    //                }
    //            }
    //        }
    //}

    //private void OnMouseDown()
    //{

    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {
    //        Vibration.Vibrate(50);

    //        AudioManager.Inst.SPlay("Horse_Neighing");

    //        for (int i = 0; i < mapManagment.mapData.AllHoresList.Count; i++)
    //        {
    //            mapManagment.mapData.AllHoresList[i].GetComponent<HoresController>().FastRun(7);
    //        }
    //    }
    //}

    public void OnPointerClick(PointerEventData eventData)
    {

       
            Vibration.Vibrate(50);

            AudioManager.Inst.SPlay("Horse_Neighing");

            for (int i = 0; i < mapManagment.mapData.AllHoresList.Count; i++)
            {
                mapManagment.mapData.AllHoresList[i].GetComponent<HoresController>().FastRun(7);
            }
    }
}
