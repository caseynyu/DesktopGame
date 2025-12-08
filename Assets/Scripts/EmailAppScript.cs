using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;

[System.Serializable]
public class Email
{
    public string id;
    public string sender;
    public string subject;
    public string dateAndTime;
    public string bodyText;
}
public class EmailAppScript : MonoBehaviour
{
    [SerializeField] TextAsset emailText;
    //List<Email> emailDatabaseList = new List<Email>();
    [SerializeField]
    List<string> currentEmails = new List<string>();
    [SerializeField]
    List<GameObject> emailDispList = new List<GameObject>();
    public Dictionary<string,Email> emailDatabaseList=new Dictionary<string, Email>();
    int emailDispPageNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadEmails();
        PopulateEmails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PopulateEmails()
    {

        int emailPageOffset = emailDispPageNumber*5;
        for (int i = emailPageOffset; i < emailDispList.Count; i++)
        {
            if(i > currentEmails.Count-1)
            {
                emailDispList[i].SetActive(false);
                continue;
            }
            else
            {
                emailDispList[i].SetActive(true);
            }
            TMP_Text textToWrite = emailDispList[i].GetComponentInChildren<TMP_Text>();
            textToWrite.text = (emailDatabaseList[currentEmails[i]].sender+"\t"+emailDatabaseList[currentEmails[i]].subject+"\t"+emailDatabaseList[currentEmails[i]].dateAndTime);
            emailDispList[i].GetComponent<ClickableLink>().storedWebsiteToSwitch = emailDatabaseList[currentEmails[i]].id;
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
}
