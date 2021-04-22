//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase;
//using Firebase.Messaging;
//using System.Text;

//public class FirebaseNotification : MonoBehaviour
//{

//    // Use this for initialization
//    void Start()
//    {
//        FirebaseMessaging.Subscribe("/topics/idlehorse");
//        FirebaseMessaging.TokenReceived += OnTokenReceived;
//        FirebaseMessaging.MessageReceived += OnMessageReceived;
//    }


//    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
//    {
//        Debug.Log("Received Registertion Token" + token.Token);

//    }

//    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
//    {
//        Debug.Log("Received new msg from" + e.Message.From);
//    }



//}

