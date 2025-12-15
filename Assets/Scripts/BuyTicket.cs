using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BuyTicket : MonoBehaviour
{

    [SerializeField] 
    TMP_InputField emailText,personNameText,creditCardNumberText;
    [SerializeField]
    GameObject popUpWindowPrefab;
    GameObject canvas;
    public string location;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickYes()
    {
        foreach( var c in creditCardNumberText.text.Trim())
        {
        //Debug.Log( "[" + c + "]");
        }
        int cardNumberInt;
        int.TryParse(creditCardNumberText.text.Trim(), out cardNumberInt);
        //Debug.Log(creditCardNumberText.text);
        //Debug.Log(cardNumberInt);
        if(cardNumberInt != PublicVariables.instance.creditCardNumber)
        {
            
            GameObject newPopUp = Instantiate(popUpWindowPrefab,canvas.transform);
            newPopUp.GetComponent<PopUpWindow>().SetupPopUp("Credit card number is invalid.");
            return;
        }
        string emailInputNormalized = Regex.Replace(emailText.text, @"\s", "").ToLower();
        string emailValueNormalized = Regex.Replace(PublicVariables.instance.robinEmail, @"\s", "").ToLower();

        if(emailInputNormalized != emailValueNormalized)
        {
            GameObject newPopUp = Instantiate(popUpWindowPrefab,canvas.transform);
            newPopUp.GetComponent<PopUpWindow>().SetupPopUp("Email address is invalid.");
            return;         
        }
        PublicVariables.instance.busTicketBoughtNumber++;
        PublicVariables.instance.robinBusTicketName = personNameText.text;
        GameObject newPopUpSuccess = Instantiate(popUpWindowPrefab,canvas.transform);
        newPopUpSuccess.GetComponent<PopUpWindow>().SetupPopUp("Successfully bought bus ticket.");

        Email newEmail = new Email
        {
            id = "busTicketBoughtEmail"+PublicVariables.instance.busTicketBoughtNumber.ToString(),
            sender = "BusNet",
            subject = "Bus Ticket Bought",
            dateAndTime = PublicVariables.instance.GetDateAndTime(),
            bodyText = "Hello "+ PublicVariables.instance.robinBusTicketName+",\nThis is a confirmation of your purchase of a bus ticket for 11/16 to "+ location+".\nPlease download and print out this email to use as a ticket.\nTicket code: " + UnityEngine.Random.Range(1000000,9999999)
        };
        EmailManager.instance.emailDatabaseList.Add(newEmail.id,newEmail);
        EmailManager.instance.StartCoroutine(EmailManager.instance.QueueEmail(newEmail.id));
        PublicVariables.instance.boughtBusTicket = true;
        Destroy(gameObject);

    }
    public void ClickNo()
    {
        Destroy(gameObject);
    }
}
