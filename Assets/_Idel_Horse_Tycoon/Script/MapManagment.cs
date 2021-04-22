using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManagment : MonoBehaviour
{
    public Transform SpawnPos;

    public Transform[] Targets;

    public MapData mapData;

    public GameObject Camera;






    // Start is called before the first frame update
    void Start()
    {


        if (!PlayerPrefs.HasKey(mapData.MapName + "TotalHores"))
            GanaretHores();
        else
        {


            List<HorseArrayElement> TotalHoresList = SaveDataOnPause.GetHoresList(mapData.TotalHores, mapData.MapName);

            for (int i = 0; i < TotalHoresList.Count; i++)
            {

                GanaretHores(TotalHoresList[i].pos, TotalHoresList[i].Targetpos, TotalHoresList[i].rot, TotalHoresList[i].T_Index, TotalHoresList[i].Tag);

            }

        }

    }
    private void Update()
    {
        if (GameManager.GameTutorial == 5 && !UiManager.inst.Collaction_pnl.activeSelf && !UiManager.inst.GiftBox_Pnl.activeSelf && !UiManager.inst.MegaHores_Pnl.activeSelf && mapData.CurrantSpeedBonus_sliderValue >= 100)
        {
            GameManager.GameTutorial++;
            UiManager.inst.Hand.SetActive(true);

        }



    }
    private void OnApplicationPause(bool pause)
    {

        SaveDataOnPause.SaveHoresList(mapData.AllHoresList, mapData.MapName);

    }

    private void OnApplicationFocus(bool focus)
    {
        SaveDataOnPause.SaveHoresList(mapData.AllHoresList, mapData.MapName);

    }
    private void OnApplicationQuit()
    {
        SaveDataOnPause.SaveHoresList(mapData.AllHoresList, mapData.MapName);

    }

    private void OnDisable()
    {
        SaveDataOnPause.SaveHoresList(mapData.AllHoresList, mapData.MapName);
    }

    public void GanaretHores(float Delay)
    {

        Invoke("GanaretHores", Delay);
    }
    public void GanaretTempHores(float Delay)
    {

        Invoke("GanaretTempHores", Delay);
    }
    public void GanaretTempHores()
    {
        GameObject Hores = Instantiate(PrefabsManager.inst.Hores, SpawnPos.position, SpawnPos.rotation);
        Hores.transform.SetParent(transform);
        Hores.GetComponent<HoresController>().TempHores = true;
        Hores.GetComponent<HoresController>().Targtes = Targets;
        Hores.GetComponent<HoresController>().SpawnPos = SpawnPos;
        Hores.GetComponent<HoresController>().mapManagment = this;
        Hores.SetActive(true);


        mapData.AllHoresList.Add(Hores.GetComponent<HoresController>());

        mapData.TotalHores = mapData.TotalHores;
    }

    public void GanaretHores()
    {
        GameObject Hores = Instantiate(PrefabsManager.inst.Hores, SpawnPos.position, SpawnPos.rotation);
        Hores.transform.SetParent(transform);
        Hores.GetComponent<HoresController>().TempHores = false;
        Hores.GetComponent<HoresController>().Targtes = Targets;
        Hores.GetComponent<HoresController>().SpawnPos = SpawnPos;
        Hores.GetComponent<HoresController>().mapManagment = this;
        Hores.SetActive(true);


        mapData.AllHoresList.Add(Hores.GetComponent<HoresController>());

        mapData.TotalHores = mapData.TotalHores;
    }
    public void GanaretMegaHores(int no)
    {
        GameObject Hores = Instantiate(mapData.MagaHoresList[no].Horse_pb, SpawnPos.position, SpawnPos.rotation);
        Hores.transform.SetParent(transform);
        Hores.GetComponent<HoresController>().TempHores = false;
        Hores.GetComponent<HoresController>().Targtes = Targets;
        Hores.GetComponent<HoresController>().SpawnPos = SpawnPos;
        Hores.GetComponent<HoresController>().mapManagment = this;
        Hores.SetActive(true);


        mapData.AllHoresList.Add(Hores.GetComponent<HoresController>());

        mapData.TotalHores++;

        mapData.TotalHores = mapData.TotalHores;

        mapData.MagaHoresList[no].IsClailed = true;
    }

    public void GanaretHores(Vector3 pos, Vector3 Targetpos, Vector3 rot, int currntTargetIndex, string tag)
    {
        GameObject Hores = null;




        if (tag == "Hores")
        {
            PrefabsManager.inst.Hores.SetActive(false);
            Hores = Instantiate(PrefabsManager.inst.Hores, pos, Quaternion.Euler(rot));
        }
        else if (tag == "Big_horse")
        {
            PrefabsManager.inst.Big_Hores.SetActive(false);
            Hores = Instantiate(PrefabsManager.inst.Big_Hores, pos, Quaternion.Euler(rot));
        }
        else if (tag == "Fast_horse")
        {
            PrefabsManager.inst.Fast_Hores.SetActive(false);
            Hores = Instantiate(PrefabsManager.inst.Fast_Hores, pos, Quaternion.Euler(rot));
        }
        else if (tag == "Black_horse")
        {
            PrefabsManager.inst.Black_Hores.SetActive(false);
            Hores = Instantiate(PrefabsManager.inst.Black_Hores, pos, Quaternion.Euler(rot));
        }



        Hores.transform.SetParent(transform);
        Hores.GetComponent<HoresController>().Targtes = Targets;
        Hores.GetComponent<HoresController>().SpawnPos = SpawnPos;
        Hores.GetComponent<HoresController>().Currat_target_pos = Targetpos;
        Hores.GetComponent<HoresController>().poscounter = currntTargetIndex;
        Hores.GetComponent<HoresController>().mapManagment = this;
        Hores.SetActive(true);



        mapData.AllHoresList.Add(Hores.GetComponent<HoresController>());
    }

    public void LevelUp()
    {


        if (mapData.MapRate >= 0 && mapData.MapRate < 1)
            mapData.MapRate += GameManager.inst.RatingValues_[0];
        else if (mapData.MapRate >= 1 && mapData.MapRate < 2)
            mapData.MapRate += GameManager.inst.RatingValues_[1];
        else if (mapData.MapRate >= 2 && mapData.MapRate < 3)
            mapData.MapRate += GameManager.inst.RatingValues_[2];
        else if (mapData.MapRate >= 3 && mapData.MapRate < 4)
            mapData.MapRate += GameManager.inst.RatingValues_[3];
        else if (mapData.MapRate >= 4 && mapData.MapRate < 5)
            mapData.MapRate += GameManager.inst.RatingValues_[4];



        if (!mapData.RatingIsFiveStar)
        {
        //Scale_1to1.1to1
        UiManager.inst.MapRating_txt.GetComponent<Animator>().Play("Scale_1to1_1to1");

            if (Mathf.Approximately(1, (float)mapData.MapRate))
            {
                UiManager.inst.MapRatingIncreseActive(mapData.MapRate);
                mapData.MapRate = 1;
            }
            else if (Mathf.Approximately(2, (float)mapData.MapRate))
            {
                UiManager.inst.MapRatingIncreseActive(mapData.MapRate);
                mapData.MapRate = 2;
            }
            else if (Mathf.Approximately(3, (float)mapData.MapRate))
            {
                UiManager.inst.MapRatingIncreseActive(mapData.MapRate);
                mapData.MapRate = 3;

            }
            else if (Mathf.Approximately(4, (float)mapData.MapRate))
            {
                UiManager.inst.MapRatingIncreseActive(mapData.MapRate);
                mapData.MapRate = 4;

            }
            else if (Mathf.Approximately(5, (float)mapData.MapRate))
            {
                UiManager.inst.MapRatingIncreseActive(mapData.MapRate);
                mapData.MapRate = 5;
                mapData.RatingIsFiveStar = true;
            }
        }

        mapData.CurrantSpeedBonus_sliderValue += 5;

        GameManager.TotalCoins -= mapData.LevelUpdateValue;

        if (mapData.After_Level_Increse_LevelUpdateIncreseValue <= mapData.CurrantLevel)
        {
            mapData.After_Level_Increse_LevelUpdateIncreseValue += mapData.LevelValueIncreseValue;

            if (mapData.LevelValueIncreseValue > 4)
                mapData.LevelValueIncreseValue -= 2;
            else if (mapData.LevelUpdateValue < 1000)
                mapData.LevelValueIncreseValue = UnityEngine.Random.Range(1, 2);
            else
                mapData.LevelValueIncreseValue = 1;

            mapData.LevelUpdateIncreseValue += mapData.LevelUpdateIncreseValue_updateValue;

        }

        //Debug.LogError( "Currant LVL = "+ GameManager.inst.CurrantMap.mapData.CurrantLevel+"            "+"LevelUpdateIncreseValue = " + mapData.LevelUpdateIncreseValue);

        mapData.LevelUpdateValue += mapData.LevelUpdateIncreseValue;
        mapData.CurrantLevel++;
        mapData.HoresEarnCoin += mapData.HoresEarningUpdateValue;

        if (mapData.CurrantLevel == GameManager.inst.MapTargetLevelList[mapData.TargetLevelIndex])
        {
            mapData.WasTargetLevel = GameManager.inst.MapTargetLevelList[mapData.TargetLevelIndex];
            mapData.TargetLevelIndex++;
            mapData.TotalHores++;

            GanaretHores();
        }
    }



}
/*[Serializable]
public class RaceModel
{
    public string MapName;
    public MapData[] mapData;
}
*/

[Serializable]
public class MapData
{

    public string MapName;
    public int UnlockAfterLevel;
    //public int UnlockPrice;
    public long UnlockPrice_;
    public int StartingHoresEarning;
    public int HoresEarningUpdateValue;
    public int StartingLevelUpdateValue;
    public int LevelUpdateIncreseValue_updateValue;
    public int Starting_After_Level_Increse_LevelUpdateIncreseValue;
    public int Starting_LevelValueIncreseValue;

    public bool ThisIslocked { get { return PlayerPrefs.GetInt(MapName + "ThisIslocked", 1) == 1 ? true : false; } set { PlayerPrefs.SetInt(MapName + "ThisIslocked", value == true ? 1 : 0); } }
    public int CurrantLevel { get { return PlayerPrefs.GetInt(MapName + "CurrantLevel", 1); } set { PlayerPrefs.SetInt(MapName + "CurrantLevel", value); } }
    //public float MapRate { get { return PlayerPrefs.GetFloat(MapName + "MapRate", 0); } set { PlayerPrefs.SetFloat(MapName + "MapRate", value); } }
    public bool RatingIsFiveStar { get { return PlayerPrefs.GetInt(MapName + "RatingIsFiveStar", 0) == 1 ? true : false; } set { PlayerPrefs.SetInt(MapName + "RatingIsFiveStar", value == true ? 1 : 0); } }
    public double MapRate { get { return double.Parse(PlayerPrefs.GetString(MapName + "MapRate", "0")); } set { PlayerPrefs.SetString(MapName + "MapRate", value.ToString()); } }

    public int WasTargetLevel { get { return PlayerPrefs.GetInt(MapName + "WasTargetLevel", 1); } set { PlayerPrefs.SetInt(MapName + "WasTargetLevel", value); } }
    public int TargetLevelIndex { get { return PlayerPrefs.GetInt(MapName + "TargetLevelIndex", 0); } set { PlayerPrefs.SetInt(MapName + "TargetLevelIndex", value); } }
    public int HoresEarnCoin { get { return PlayerPrefs.GetInt(MapName + "HoresEarnCoin", StartingHoresEarning); } set { PlayerPrefs.SetInt(MapName + "HoresEarnCoin", value); } }
    public int LevelUpdateValue { get { return PlayerPrefs.GetInt(MapName + "LevelUpdateValue", StartingLevelUpdateValue); } set { PlayerPrefs.SetInt(MapName + "LevelUpdateValue", value); } }
    public int TotalHores { get { return PlayerPrefs.GetInt(MapName + "TotalHores", 1); } set { PlayerPrefs.SetInt(MapName + "TotalHores", value); } }

    public int CurrantSpeedBonus { get { return PlayerPrefs.GetInt(MapName + "CurrantSpeedBonus", 5); } set { PlayerPrefs.SetInt(MapName + "CurrantSpeedBonus", value); } }
    public int CurrantSpeedBonus_Increse_Value { get { return PlayerPrefs.GetInt(MapName + "CurrantSpeedBonus_Increse_Value", 5); } set { PlayerPrefs.SetInt(MapName + "CurrantSpeedBonus_Increse_Value", value); } }
    public int CurrantSpeedBonus_sliderValue { get { return PlayerPrefs.GetInt(MapName + "CurrantSpeedBonus_slider", 0); } set { PlayerPrefs.SetInt(MapName + "CurrantSpeedBonus_slider", value); } }
    public int CurrantSpeedBonus_StarSliderValue { get { return PlayerPrefs.GetInt(MapName + "CurrantSpeedBonus_StarValue", 0); } set { PlayerPrefs.SetInt(MapName + "CurrantSpeedBonus_StarValue", value); } }

    public int After_Level_Increse_LevelUpdateIncreseValue { get { return PlayerPrefs.GetInt(MapName + "After_Level_Increse_LevelUpdateIncreseValue", Starting_After_Level_Increse_LevelUpdateIncreseValue); } set { PlayerPrefs.SetInt(MapName + "After_Level_Increse_LevelUpdateIncreseValue", value); } }
    public int LevelValueIncreseValue { get { return PlayerPrefs.GetInt(MapName + "LevelValueIncreseValue", Starting_LevelValueIncreseValue); } set { PlayerPrefs.SetInt(MapName + "LevelValueIncreseValue", value); } }
    public int LevelUpdateIncreseValue { get { return PlayerPrefs.GetInt(MapName + "LevelUpdateIncreseValue", LevelUpdateIncreseValue_updateValue); } set { PlayerPrefs.SetInt(MapName + "LevelUpdateIncreseValue", value); } }

    public List<MagaHores> MagaHoresList;
    public List<HoresController> AllHoresList;

    //public float[] RatingValues;

}
[Serializable]
public class MagaHores
{
    public string Name;
    public Sprite MegaHores_ic;
    public GameObject Horse_pb;

    public MapManagment mapManagment;

    public int CurrantValue { get { return PlayerPrefs.GetInt(mapManagment.name + Name + "CurrantValue", 0); } set { PlayerPrefs.SetInt(mapManagment.name + Name + "CurrantValue", value); } }
    public bool IsClailed { get { return PlayerPrefs.GetInt(mapManagment.name + Name + "IsClailed", 0) == 1 ? true : false; } set { PlayerPrefs.SetInt(mapManagment.name + Name + "IsClailed", value == true ? 1 : 0); } }

    public int UnloackValue;
    public int GiftCoins;
}


