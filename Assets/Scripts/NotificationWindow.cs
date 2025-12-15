using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;



[System.Serializable]
public class Notification
{
    public string id;
    public string type;
    public string textToDisplay;
}

public class NotificationWindow : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip notificationSound;
    [SerializeField]
    TextAsset txt;
    [SerializeField]
    float notifTimerMax;
    float notifTimerCount;
    bool visible = false;
    [SerializeField]
    GameObject body;
    [SerializeField]
    TMP_Text textBox;
    public Dictionary<string,Notification> allNotifs=new Dictionary<string, Notification>();
    private string currentIdDisplaying = "";

    public static NotificationWindow instance;

    void Awake()
    {
        instance = this;
        body.SetActive(false);
        audioSource=GetComponent<AudioSource>();
        //LoadNotifications();
    }

    /*void Update()
    {
        if (visible)
        {
            notifTimerCount+=Time.deltaTime;
            body.SetActive(true);
        }
        else
        {
            body.SetActive(false);
        }
        if (notifTimerCount>=notifTimerMax)
        {
            notifTimerCount = 0;
            textBox.text = "";
            currentIdDisplaying = "";
            visible = false;

        }
    }*/

    void SendNotification(string notifToDisplay)
    {
        textBox.text = allNotifs[notifToDisplay].textToDisplay;
        visible = true;
        currentIdDisplaying = notifToDisplay;
        
    }

    public void MessageNotif()
    {
        StartCoroutine(Notification("New message recieved"));
        audioSource.PlayOneShot(notificationSound);
    }

    public void EmailNotif()
    {
        StartCoroutine(Notification("New email recieved"));
        audioSource.PlayOneShot(notificationSound);
    }

    public void DownloadNotif()
    {
        StartCoroutine(Notification("New file downloaded"));
        audioSource.PlayOneShot(notificationSound);
    }
    public void PrintingNotif()
    {
        StartCoroutine(Notification("File printing"));
        audioSource.PlayOneShot(notificationSound);
    }
    public void SentEmailNotif()
    {
        StartCoroutine(Notification("Sent email"));
        audioSource.PlayOneShot(notificationSound);
    }

    public void Hide()
    {
        body.SetActive(false);
    }

    IEnumerator Notification(string textToDisplay)
    {
        textBox.text = textToDisplay;
        body.SetActive(true);
        yield return new WaitForSeconds(notifTimerMax);
        body.SetActive(false);
        textBox.text = "";
        yield break;
        

    }

    /*void OnClick()
    {
        if(allNotifs[currentIdDisplaying].type == "email")
        {
            
        }
        if(allNotifs[currentIdDisplaying].type == "message")
        {
            
        }
    }*/

    private void LoadNotifications()
    {
        StringReader sr=new StringReader(txt.text);
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
            Notification newLine = new Notification
            {
                id = data[0],
                type = data[1] == ""?"default":data[1],
                textToDisplay = data[2] == ""?"default":data[2]
            ,
            };
            allNotifs.Add(data[0],newLine);
        }
    }
}
