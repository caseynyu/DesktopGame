using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class EmailAppScript : MonoBehaviour
{
    public List<GameObject> displayEmailLines = new List<GameObject>();
    int currentPage=0;
    [SerializeField]
    TMP_Text pageDisplay;
    void Start()
    {
        
    }


    void Update()
    {
        LoadEmailsOntoInterface();
    }

    void LoadEmailsOntoInterface()
    {
        
        for (int i = 0; i < displayEmailLines.Count; i++)
        {
            //Debug.Log((EmailManager.instance.currentEmails.Count-(5*currentPage))-1);
            //Debug.Log(EmailManager.instance.currentEmails[i+(5*currentPage)]);
            if (i > (EmailManager.instance.currentEmails.Count-(5*currentPage))-1)
            {
                displayEmailLines[i].SetActive(false);
            }
            else
            {
                displayEmailLines[i].SetActive(true);
                Email newEmail = EmailManager.instance.emailDatabaseList[EmailManager.instance.currentEmails[i+(5*currentPage)]];
                displayEmailLines[i].GetComponent<EmailBar>().title.text = newEmail.subject;
                displayEmailLines[i].GetComponent<EmailBar>().byline.text = newEmail.sender;
                displayEmailLines[i].GetComponent<EmailBar>().time.text = newEmail.dateAndTime;
                displayEmailLines[i].GetComponent<EmailBar>().id = EmailManager.instance.emailDatabaseList[EmailManager.instance.currentEmails[i+(5*currentPage)]].id;
            }
            
        }
        
    }

    public void PageUp()
    {
        //Debug.Log("test");
        currentPage++;
        pageDisplay.text = "Page "+(currentPage+1);
        //Debug.Log("test");
    }
    public void PageDown()
    {
        if (currentPage != 0)
        {
            currentPage--;
            pageDisplay.text = "Page "+(currentPage+1);
        }
    }

    private void PopulateEmails()
    {

        /*int emailPageOffset = emailDispPageNumber*5;
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
        }*/
    }
}
