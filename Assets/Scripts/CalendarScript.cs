using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class CalendarScript : MonoBehaviour
{
    //popup
    [SerializeField]
    Transform canvas;

    [SerializeField]
    GameObject popupPrefab;

    public class Day
    {
        public int dayNum;
        public Color dayColor;
        public GameObject obj;

        public Day(int dayNum, Color dayColor, GameObject obj, CalendarScript parent)
        {
            this.dayNum = dayNum;
            this.dayColor = dayColor;
            this.obj = obj;

            obj.GetComponent<Image>().color = dayColor;
            UpdateDay(dayNum);

            Button b = obj.GetComponent<Button>();

            // Disable buttons on grey (invalid) days
            if (dayColor == Color.grey)
            {
                if (b != null) b.interactable = false;
            }
            else
            {
                // Add click listener on valid days
                if (b != null)
                {
                    b.onClick.RemoveAllListeners();
                    b.onClick.AddListener(() => parent.OpenDayPopup(this));
                }
            }
        }

        public void UpdateColor(Color newColor)
        {
            obj.GetComponent<Image>().color = newColor;
            dayColor = newColor;

            Button b = obj.GetComponent<Button>();

            // Disable when grey
            if (newColor == Color.grey)
            {
                if (b != null) b.interactable = false;
            }
            else
            {
                if (b != null) b.interactable = true;
            }
        }

        public void UpdateDay(int newDayNum)
        {
            this.dayNum = newDayNum;

            if (dayColor == Color.white || dayColor == Color.green)
            {
                obj.GetComponentInChildren<TMP_Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<TMP_Text>().text = "";
            }
        }
    }

    private List<Day> days = new List<Day>();
    public Transform[] weeks;
    public TMP_Text MonthAndYear;

    public DateTime currDate = DateTime.Now;

    void Start()
    {
        UpdateCalendar(2002,5);
    }

    void UpdateCalendar(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        currDate = temp;
        MonthAndYear.text = temp.ToString("MMMM") + " " + temp.Year.ToString();

        int startDay = GetMonthStartDay(year, month);
        int endDay = GetTotalNumberOfDays(year, month);

        if (days.Count == 0)
        {
            for (int w = 0; w < 6; w++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Day newDay;
                    int currDay = (w * 7) + i;

                    if (currDay < startDay || currDay - startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks[w].GetChild(i).gameObject, this);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks[w].GetChild(i).gameObject, this);
                    }

                    days.Add(newDay);
                }
            }
        }
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if (i < startDay || i - startDay >= endDay)
                {
                    days[i].UpdateColor(Color.grey);
                }
                else
                {
                    days[i].UpdateColor(Color.white);
                }

                // FIXED: no more i = startDay
                days[i].UpdateDay(i - startDay);
            }
        }

        // Highlight today
        if (DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.green);
        }
    }

    int GetMonthStartDay(int year, int month)
    {
        DateTime temp = new DateTime(year, month, 1);
        return (int)temp.DayOfWeek;
    }

    int GetTotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    public void SwitchMonth(int direction)
    {
        // FIXED: DateTime is immutable
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }

        UpdateCalendar(currDate.Year, currDate.Month);
    }

    public void CreatePopup()
    {
        Instantiate(popupPrefab, Vector3.zero, Quaternion.identity, canvas);
    }

    public void OpenDayPopup(Day day)
    {
        // Check again (safety)
        if (day.dayColor == Color.grey)
            return;

        GameObject popupObj = Instantiate(popupPrefab, canvas);

        int clickedDay = day.dayNum + 1;
        int month = currDate.Month;
        int year = currDate.Year;

        popupObj.GetComponent<PopUpCalendar>().SetupPopUp(clickedDay, month, year);
    }
}
