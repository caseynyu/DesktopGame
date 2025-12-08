using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class Message
{
    public string id;
    public string text;
    public string playerPrefToChange;
}

public class TextMessage : MonoBehaviour
{
    [SerializeField]
    float queueTimeMin,queueTimeMax;

    [SerializeField]
    TextAsset messagesTxt;
    public Dictionary<string,Message> messageDatabaseList=new Dictionary<string, Message>();
    [HideInInspector]
    public string textBoxText;

    public static TextMessage instance;

    void Awake()
    {
        instance = this;
        LoadMessages();
        textBoxText = messageDatabaseList["DmessagesBefore"].text;
        
    }
    void Start()
    {
        StartCoroutine(QueueMessage("Dintro1"));
        PlayerPrefs.SetInt("flagIntroStart",1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //AddTextMessage(messageDatabaseList[textMessageToAdd].text);
        }
    }

    void AddTextMessage(string newText)
    {
        textBoxText = textBoxText+("\n")+newText;
    }

    public void AddPlayerTextMessage(string playerInputTextBox)
    {
        textBoxText = textBoxText+("\n")+("<color=red>Robin: </color>")+playerInputTextBox;
        if(PlayerPrefs.GetInt("flagIntroStart") == 1)
        {
            StartCoroutine(QueueMessage("Dintro2"));
            PlayerPrefs.SetInt("flagIntroStart",0);
        }

        if(PlayerPrefs.GetInt("flagIntroDayQuestion") == 1)
        {
            if (playerInputTextBox.ToLower().Contains("kangaroo"))
            {
                StartCoroutine(QueueMessage("Dintro2Right"));
                PlayerPrefs.SetInt("flagIntroDayQuestion",0);
            }
            else
            {
                StartCoroutine(QueueMessage("Dintro2Wrong"));
                Debug.Log("wrong");
            }
        }
        
    }

    IEnumerator QueueMessage(string messageToQueue)
    {
        yield return new WaitForSeconds(Random.Range(queueTimeMin,queueTimeMax));
        AddTextMessage(messageDatabaseList[messageToQueue].text);
        if(messageDatabaseList[messageToQueue].playerPrefToChange != "default")
        {
            PlayerPrefs.SetInt(messageDatabaseList[messageToQueue].playerPrefToChange,1);
        }
        yield break;
    }

    private void LoadMessages()
    {
        StringReader sr=new StringReader(messagesTxt.text);
        sr.ReadLine();
        while (true)
        {
            string line=sr.ReadLine();
            if(line == null)
            {
                break;
            }
            string[] data= line.Split("\t");
            if(data[0] == "")
            {
                continue;
            }
            Message message = new Message
            {
                id = data[0],
                text = data[1] == ""?"default":data[1],
                playerPrefToChange = data[2] == ""?"default":data[2]
            };
            messageDatabaseList.Add(data[0],message);
        }
    }
}
