using UnityEngine;

public class NewBusWebsite : MonoBehaviour
{
    [SerializeField]
    GameObject ticketBuyWindowPrefab;
    GameObject canvas;
    void Start()
    {
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyTicketSeattle()
    {
        GameObject newWindow = Instantiate(ticketBuyWindowPrefab,canvas.transform);
        newWindow.GetComponent<BuyTicket>().location = "Seattle";
    }
    public void BuyTicketPortland()
    {
        GameObject newWindow = Instantiate(ticketBuyWindowPrefab,canvas.transform);
        newWindow.GetComponent<BuyTicket>().location = "Portland";
    }
    public void BuyTicketVictoria()
    {
        GameObject newWindow = Instantiate(ticketBuyWindowPrefab,canvas.transform);
        newWindow.GetComponent<BuyTicket>().location = "Victoria";
    }
}
