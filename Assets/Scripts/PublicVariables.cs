using System;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{

    public bool boughtBusTicket=false;
    public bool idGot=false;
    public static PublicVariables instance;
    public int creditCardNumber;
    public string robinEmail;
    public string robinFakeName;

    public string robinBusTicketName;
    public string busTicketLocation;

    public int busTicketBoughtNumber=0;
    public string printedText;
    public static GameObject canvas;
    public List<GameObject> photos = new List<GameObject>();

    public bool sentGoodbyeEmail = false;
    public bool sentResignationEmail = false;
    [SerializeField]
    EndingDisplayer endingDisplayer;

    [SerializeField]
    GameObject otherCanvas;

    public string cultLoginUsername, cultLoginPassword;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDateAndTime()
    {
        DateTime currentTime = DateTime.Now;

        return "11/16, " + ($"{currentTime:hh:mm tt}");
    }

    public void PrintedDocuments(string textToAdd)
    {
        printedText = textToAdd+printedText;
    }

    public void EmailSentCheck(string emailAddress,string emailID)
    {
        if(emailAddress == "osphranter@dawn.net" && emailID == "robinPicture")
        {
            Debug.Log("osphranter email sent");
            EmailManager.instance.StartCoroutine(EmailManager.instance.QueueEmail("OPositiveResponse"));
            idGot=true;
        }
        if(emailAddress == "mattrat@aol.com"&& emailID == "goodbyeEmail")
        {
            sentGoodbyeEmail = true;
        }
        if(emailAddress == "lucamcbride@aol.com"&& emailID == "goodbyeEmail")
        {
            sentGoodbyeEmail = true;
        }
        if(emailAddress == "piperc@evergreen.net"&& emailID == "resignationEmail")
        {
            sentResignationEmail = true;
        }
    }

    public void Ending()
    {
        endingDisplayer.ticket = boughtBusTicket;
        if (sentGoodbyeEmail && sentResignationEmail)
        {
            endingDisplayer.connections = true;
        }
        else
        {
            endingDisplayer.connections = false;
        }
        if(GameObject.FindAnyObjectByType<DoubleClickSecureMessenger>()== null && !EmailManager.instance.currentEmails.Contains("OInfoEmail") && !EmailManager.instance.currentEmails.Contains("OPositiveResponse"))
        {
            endingDisplayer.files= true;
        }
        else
        {
            endingDisplayer.files = true;
        }
        if (idGot == true)
        {
            endingDisplayer.id=true;
        }
        else
        {
            endingDisplayer.id=false;
        }
        otherCanvas.SetActive(true);
        endingDisplayer.createArticle();

    }


    
}
