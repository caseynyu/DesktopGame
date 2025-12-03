using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BusGenerate : MonoBehaviour
{
    [SerializeField]
    public TMP_Text busOrigin;
    [SerializeField]
    private TMP_Text busDestination;
    [SerializeField]
    private TMP_Text busDate;
    [SerializeField]
    private TMP_Text busPrice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string origin, string destination, string date, float price)
    {
        busOrigin.text = origin;
        busDestination.text = destination;
        busDate.text = date;
        busPrice.text = price.ToString();
        
    }
}
