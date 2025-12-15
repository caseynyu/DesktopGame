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
    [HideInInspector]
    public string bossBoxText;

    public static TextMessage instance;

    void Awake()
    {
        instance = this;
        LoadMessages();
        AllBeforeMessages();
        
    }

    void AllBeforeMessages()
    {
        textBoxText = messageDatabaseList["firstConvo1"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo2"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo3"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo4"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo5"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo6"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo7"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo8"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo9"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo10"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["firstConvo11"].text;
        textBoxText = textBoxText+"\n";
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo1"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo2"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo3"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo4"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo5"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo6"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo7"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo8"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo9"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo10"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo11"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo12"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo13"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["secondConvo14"].text;
        textBoxText = textBoxText+"\n";
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo1"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo2"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo3"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo4"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo5"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo6"].text;
        textBoxText = textBoxText+("\n")+messageDatabaseList["thirdConvo7"].text;
        textBoxText = textBoxText+"\n";

        bossBoxText = messageDatabaseList["boss1line1"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss1line2"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss1line3"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss1line4"].text;
        bossBoxText = bossBoxText+"\n";
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss2line1"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss2line2"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss2line3"].text;
        bossBoxText = bossBoxText+"\n";
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss3line1"].text;
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss3line2"].text;
        bossBoxText = bossBoxText+"\n";
        bossBoxText = bossBoxText+("\n")+messageDatabaseList["boss4line1"].text;
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

    public void AddBossPlayerTextMessage(string playerInputTextBox)
    {
        bossBoxText = bossBoxText+("\n")+("<color=red>Robin: </color>")+playerInputTextBox;
        bossBoxText = bossBoxText+("\n")+("<color=blue>System: </color>")+"User is currently unavailable.";
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
