using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System.IO;

[System.Serializable]
public class Email
{
    public string id;
    public string sender;
    public string subject;
    public string dateAndTime;
    public string bodyText;
}

public class EmailManager : MonoBehaviour
{
    [SerializeField]
    float queueTimeMin,queueTimeMax;
    [SerializeField]
    TextAsset emailText;
    public List<string> currentEmails = new List<string>();
    public Dictionary<string,Email> emailDatabaseList=new Dictionary<string, Email>();
    //int emailDispPageNumber = 0;
    public static EmailManager instance;

    public string currentDisplayEmail;

    void Awake()
    {
        instance = this;
        LoadEmails();
        
    }
    void Start()
    {
        currentEmails.Add("testemail1");
        currentEmails.Add("testmail2");
        //PopulateEmails();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    private void LoadEmails()
    {
        StringReader sr=new StringReader(emailText.text);
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
            Email newEmail = new Email
            {
                id = data[0],
                sender = data[1] == ""?"default":data[1],
                subject = data[2] == ""?"default":data[2],
                dateAndTime = data[3] == ""?"default":data[3],
                bodyText = data[4] == ""?"default":data[4]
            ,
            };
            emailDatabaseList.Add(data[0],newEmail);
        }
    }


    public IEnumerator QueueEmail(string emailToQueue)
    {
        Debug.Log("email sent");
        yield return new WaitForSeconds(Random.Range(queueTimeMin,queueTimeMax));
        if(GameObject.FindFirstObjectByType<MessageIndicatorScript>(FindObjectsInactive.Exclude) == null)NotificationWindow.instance.EmailNotif();
        currentEmails.Insert(0,emailToQueue);
        Debug.Log("email sent");
        yield break;


    }
}
