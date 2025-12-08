using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;

public class MessagesAppScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> messageDispList = new List<GameObject>();

    public bool newNotifsOne,newNotifsTwo,newNotifsThree,newNotifsFour;
    [SerializeField]
    List<String> messagesText = new List<string>();
    void Start()
    {
        LoadPreviewMessages();
    }

    void LoadPreviewMessages()
    {
        for (int i = 0; i < messageDispList.Count; i++)
        {
            string[] data= messagesText[i].Split(";");
            TMP_Text tempText = messageDispList[i].GetComponentInChildren<TMP_Text>(); 
            tempText.text = data[1];
            messageDispList[i].GetComponent<ClickableLink>().storedWebsiteToSwitch = data[0];
        }
        
    }

    void Update()
    {
        
    }
}
