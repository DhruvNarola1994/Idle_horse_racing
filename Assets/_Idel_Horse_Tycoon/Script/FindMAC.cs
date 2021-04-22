using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace FindMAC.Scripts
{
    public class FindMACClass
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private static string fullClassName = "ru.LittleStories.FindMAC.FindMACNative";
#endif
        public static string GetMACAddress()
        {
            //#if UNITY_ANDROID && !UNITY_EDITOR
            //            AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
            //            if (pluginClass != null)
            //            {
            //                //return  pluginClass.CallStatic<string>("getMacAddress");
            //                return  Regex.Replace(pluginClass.CallStatic<string>("getMacAddress"), @":","");
            //            }
            //#endif
            //            //return  "No find MACAddress";
            //            return Regex.Replace("No:find:MACAddress", @":",""); 


            return SystemInfo.deviceUniqueIdentifier;
        }
        
    }
}