using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class SecureTextMessenger : MonoBehaviour
{
    [SerializeField]
    float queueTimeMin,queueTimeMax;

    [SerializeField]
    TextAsset messagesTxt;
    public Dictionary<string,Message> messageDatabaseList=new Dictionary<string, Message>();
    [HideInInspector]
    public string textBoxText;

    public static SecureTextMessenger instance;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        instance = this;
        LoadMessages();
        //textBoxText = messageDatabaseList["DmessagesBefore"].text;
        
    }
    void Start()
    {
        //StartCoroutine(QueueMessage("Dintro1"));
        //PlayerPrefs.SetInt("flagIntroStart",1);
    }

    public void StartSecureMessenger()
    {
        StartCoroutine(QueueMessage("DSecureIntro1"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //AddTextMessage(messageDatabaseList[textMessageToAdd].text);
        }
    }

    public void PlayerYes()
    {
        textBoxText = textBoxText+("\n")+("<color=green>Yes </color>");
        if(PlayerPrefs.GetInt("flag1Question") == 1)
        {
            PlayerPrefs.SetInt("flag1Question",0);
            StartCoroutine(QueueMultipleMessages("DSecureIntro1Yes","DSecureIntro2"));
        }
        else if(PlayerPrefs.GetInt("flag2Question") == 1)
        {
            PlayerPrefs.SetInt("flag2Question",0);
            StartCoroutine(QueueMultipleMessages("DSecureIntro2Y","DSecureIntro3"));
        }
        else if(PlayerPrefs.GetInt("flag3Question") == 1)
        {
            PlayerPrefs.SetInt("flag3Question",0);
            StartCoroutine(QueueMultipleMessages("DSecureIntro3Y","DSecureIntro3a"));
        }
    }
    public void PlayerNo()
    {
        textBoxText = textBoxText+("\n")+("<color=red>No </color>");
        if(PlayerPrefs.GetInt("flag1Question") == 1)
        {
            PlayerPrefs.SetInt("flag1Question",0);
            StartCoroutine(QueueMultipleMessages("DSecureIntro1No","DSecureIntro2"));
        }
        else if(PlayerPrefs.GetInt("flag2Question") == 1)
        {
            PlayerPrefs.SetInt("flag2Question",0);
            StartCoroutine(QueueMultipleMessages("DSecureIntro2N","DSecureIntro3"));
        }
        else if(PlayerPrefs.GetInt("flag3Question") == 1)
        {
            PlayerPrefs.SetInt("flag3Question",0);
            StartCoroutine(QueueMessage("DSecureIntro3N"));
        }
    }

    void AddTextMessage(string newText)
    {
        textBoxText = textBoxText+("\n")+newText;
    }

    IEnumerator QueueMessage(string messageToQueue)
    {
        yield return new WaitForSeconds(Random.Range(queueTimeMin,queueTimeMax));
        if(GameObject.FindFirstObjectByType<MessageIndicatorScript>(FindObjectsInactive.Exclude) == null)NotificationWindow.instance.MessageNotif();
        AddTextMessage(messageDatabaseList[messageToQueue].text);
        if(messageDatabaseList[messageToQueue].playerPrefToChange != "default")
        {
            PlayerPrefs.SetInt(messageDatabaseList[messageToQueue].playerPrefToChange,1);
        }
        yield break;
    }

    IEnumerator QueueMultipleMessages(string message1,string message2)
    {
        yield return StartCoroutine(QueueMessage(message1));
        yield return StartCoroutine(QueueMessage(message2));
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
