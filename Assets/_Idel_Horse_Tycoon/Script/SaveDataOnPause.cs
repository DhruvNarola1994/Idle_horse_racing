using System;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDataOnPause
{

    public static void SaveHoresList(List<HoresController> HorseList, string MapName)

    {

        for (int i = 0; i < HorseList.Count; i++)
        {
            if (!HorseList[i].TempHores)
            {

                PlayerPrefs.SetString(MapName + "Horse_" + i + "position", HorseList[i].transform.position.ToString());
                PlayerPrefs.SetString(MapName + "Horse_" + i + "Rotation", HorseList[i].transform.eulerAngles.ToString());
                PlayerPrefs.SetString(MapName + "Horse_" + i + "TargetPosition", HorseList[i].Currat_target_pos.ToString());
                PlayerPrefs.SetString(MapName + "Horse_" + i + "Tag", HorseList[i].gameObject.tag);
                PlayerPrefs.SetInt(MapName + "Horse_" + i + "TargetIndex", HorseList[i].poscounter);


                Debug.Log("Save Hores List!");
            }
        }

    }

    public static List<HorseArrayElement> GetHoresList(int HoresListLenth, string MapName)
    {

        var horseArrays = new List<HorseArrayElement>();

        for (int i = 0; i < HoresListLenth; i++)
        {

            HorseArrayElement hores = new HorseArrayElement();


            Debug.Log(StringToVector3(PlayerPrefs.GetString(MapName + "Horse_" + i + "position")));
            Debug.Log(StringToVector3(PlayerPrefs.GetString(MapName + "Horse_" + i + "Rotation")));
            Debug.Log(PlayerPrefs.GetInt(MapName + "Horse_" + i + "TargetIndex"));

            hores.pos = StringToVector3(PlayerPrefs.GetString(MapName + "Horse_" + i + "position"));
            hores.Targetpos = StringToVector3(PlayerPrefs.GetString(MapName + "Horse_" + i + "TargetPosition"));
            hores.rot = StringToVector3(PlayerPrefs.GetString(MapName + "Horse_" + i + "Rotation"));
            hores.T_Index = PlayerPrefs.GetInt(MapName + "Horse_" + i + "TargetIndex");
            hores.Tag = PlayerPrefs.GetString(MapName + "Horse_" + i + "Tag");

            horseArrays.Add(hores);
        }

        return horseArrays;
    }

    public static Vector3 StringToVector3(string sVector)
    {
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }
        string[] sArray = sVector.Split(',');
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }


    public static Quaternion StringToRotation(string sVector)
    {
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 3);
        }
        string[] sArray = sVector.Split(',');
        Quaternion result = new Quaternion(
          float.Parse(sArray[0]),
          float.Parse(sArray[1]),
          float.Parse(sArray[2]),
         float.Parse(sArray[3]));

        return result;
    }

}
[Serializable]
public class HorseArrayElement
{
    //public Transform Horse;

    public Vector3 pos;
    public Vector3 Targetpos;
    public Vector3 rot;
    public int T_Index;
    public string Tag;

}


