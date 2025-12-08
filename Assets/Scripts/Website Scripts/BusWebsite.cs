using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BusWebsite : MonoBehaviour
{
    public GameObject calendarPopup;

    //Inputs
    public TMP_InputField originInput;
    public TMP_InputField destinationInput;
    public TMP_InputField dateInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDatePicker()
    {
        Instantiate(calendarPopup);
    }
}
