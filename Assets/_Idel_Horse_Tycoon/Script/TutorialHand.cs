using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHand : MonoBehaviour
{

    private RectTransform canvasRectT;
    private Canvas canvas;

    public int temp;

    // Start is called before the first frame update
    void Start()
    {
        canvasRectT = GameObject.Find("Canvas").GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(GameManager.GameTutorial);

        if (GameManager.GameTutorial == 0)
        {

            //  transform.position = worldToUISpace(canvas, GameObject.FindWithTag("Hores").transform.position);
            transform.position = worldToUISpace(canvas, GameManager.inst.AllMapList[0].Targets[3].position);
            transform.GetChild(0).gameObject.SetActive(!UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.Setting_pnl.activeSelf);


        }
        else if (GameManager.GameTutorial == 1)
        {


            transform.position = UiManager.inst.UpdateLevel_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 200);
            transform.GetChild(0).gameObject.SetActive(!UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf && !UiManager.inst.Setting_pnl.activeSelf);


        }
        else if (GameManager.GameTutorial == 2)
        {
            transform.position = UiManager.inst.MainLevelUp_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -30);
            transform.GetChild(0).gameObject.SetActive(!UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf && !UiManager.inst.Setting_pnl.activeSelf);


        }
        else if (GameManager.GameTutorial == 3)
        {
            transform.position = UiManager.inst.GiftBox_Btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -30);
            transform.GetChild(0).gameObject.SetActive(!UiManager.inst.Setting_pnl.activeSelf);


        }
        else if (GameManager.GameTutorial == 4)
        {
            transform.position = UiManager.inst.GiftBox_Pnl.GetComponent<GiftBox_pnl>().Opan_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(UiManager.inst.GiftBox_Pnl.activeSelf);
        }
        else if (GameManager.GameTutorial == 5)
        {
            transform.position = UiManager.inst.GiftBox_Pnl.GetComponent<GiftBox_pnl>().megaHores_Pnl.GetComponent<MegaHores_pnl>().Con_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (GameManager.GameTutorial == 6)
        {
            transform.position = UiManager.inst.GiftBox_Btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(!UiManager.inst.Setting_pnl.activeSelf);

        }
        else if (GameManager.GameTutorial == 7)
        {
            transform.position = UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().Achivement_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf);

        }
        else if (GameManager.GameTutorial == 8)
        {
            transform.position = UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().AchivementParent.GetChild(0).GetComponent<AchivemantBox>().Get_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().Achivement_pnl.activeSelf && UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf);

        }
        else if (GameManager.GameTutorial == 9)
        {
            transform.position = UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().MegaHoresParent.GetChild(0).GetComponent<MegaHorseBox>().Hores[0].Claim_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().MegaHores_pnl.activeSelf && UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf);

        }
        else if (GameManager.GameTutorial == 10)
        {
            transform.position = UiManager.inst.MegaHoresUnlock_pnl.GetComponent<MegaHorseUnlock_pnl>().Get_btn.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).gameObject.SetActive(UiManager.inst.Collaction_pnl.GetComponent<Collaction_pnl>().MegaHores_pnl.activeSelf && UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf);

        }
        //else if (GameManager.GameTutorial == 11)
        //{
        //    transform.position = UiManager.inst.TwoX1Min_btn.transform.position;
        //    transform.rotation = Quaternion.Euler(0, 0, temp);
        //}
        else
        {

            transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
