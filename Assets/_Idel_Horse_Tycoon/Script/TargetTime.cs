using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TargetTime : MonoBehaviour
{
    public static int GetDifferenceSecond(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {


            string TargetTime = PlayerPrefs.GetString(key);
            DateTime CurrantTime = System.DateTime.Now;

            CultureInfo culture = new CultureInfo("en-US");
            DateTime targetDate = Convert.ToDateTime(TargetTime, culture);

            TimeSpan difference = targetDate.Subtract(CurrantTime);

            return difference.Seconds;
        }
        else
        {

            Debug.LogError(key + " This Key have not Data.");
            return 0;
        }

    }
    public static int GetDifferenceMinutes(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {


            string TargetTime = PlayerPrefs.GetString(key);
            DateTime CurrantTime = System.DateTime.Now;

            CultureInfo culture = new CultureInfo("en-US");
            DateTime targetDate = Convert.ToDateTime(TargetTime, culture);

            TimeSpan difference = targetDate.Subtract(CurrantTime);

            return difference.Minutes;
        }
        else
        {

            Debug.LogError(key + " This Key have not Data.");
            return 0;
        }

    }
    public static int GetDifferenceHours(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {


            string TargetTime = PlayerPrefs.GetString(key);
            //DateTime CurrantTime = System.DateTime.Now;

            //CultureInfo culture = new CultureInfo("en-US");
            //DateTime targetDate = Convert.ToDateTime(TargetTime, culture);

            //TimeSpan difference = targetDate.Subtract(CurrantTime);




            DateTime currentTime = DateTime.Now;

            //Debug.LogError(currentTime);

            TimeSpan ts = currentTime - Convert.ToDateTime(TargetTime);
            //if (ts.TotalHours > 24)
            //{
            //    Debug.Log("Welcome back, here's a prize for you!");
            //}


            //int h;
            //if (difference.Days < 0)
            //{

            //    h = difference.Days * 24 + difference.Hours;

            //}
            //else
            //{

            //    h = difference.Hours;

            //}

            //Debug.LogError("TotalHorse = "+ts.TotalHours);

            return (int)ts.TotalHours;
        }
        else
        {

            Debug.LogError(key + " This Key have not Data.");
            return 0;
        }



       

    }

    public static void SetTime(string key)
    {
        DateTime newDate = DateTime.Now;

        string targetStringDate = Convert.ToString(newDate);

        PlayerPrefs.SetString(key, targetStringDate);

        Debug.Log("<color=yellow>" + key + " set</color>");
    }
    public static void SetTime(string key, int TargetHores, int TargetMinut, int TargetSecond)
    {
        DateTime newDate = DateTime.Now;

        newDate = newDate.AddHours(TargetHores);
        newDate = newDate.AddMinutes(TargetMinut);
        newDate = newDate.AddSeconds(TargetSecond);

        string targetStringDate = Convert.ToString(newDate);

        PlayerPrefs.SetString(key, targetStringDate);
    }
}
