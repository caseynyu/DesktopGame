using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class PopUpCalendar : MonoBehaviour //implement closeable
{
    [SerializeField] TMP_Text dateText;
    
    

    int day;
    int month;
    int year;

    public void SetupPopUp(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;

        // Example: "May 12, 2002"
        System.DateTime d = new System.DateTime(year, month, day);
        dateText.text = d.ToString("MMMM d, yyyy");

        if(day == 16)
        {
            dateText.text = "KANGAROO DAY";
        }
    }

    // Optional: add a close button handler
        public void WindowClose()
    {
        Destroy(gameObject);
    }
    
}
