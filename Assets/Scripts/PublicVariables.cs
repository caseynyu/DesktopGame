using System;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{
    public static PublicVariables instance;
    public int creditCardNumber;
    public string robinEmail;
    public string robinFakeName;

    public string robinBusTicketName;
    public string busTicketLocation;

    public int busTicketBoughtNumber=0;
    public string printedText;
    public static GameObject canvas;

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
        
    }
}
