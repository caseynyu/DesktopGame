using System.Collections;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleClickBrowser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool hovering = false;
    bool clickedOnce = false;
    public GameObject attachedWindow;
    [SerializeField]
    private float doubleClickTimeMax=.4f;
    private float doubleClickTimeCount;

    void Start()
    {
        doubleClickTimeCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickedOnce == true)
        {
            doubleClickTimeCount+=Time.deltaTime;
            if (doubleClickTimeCount >= doubleClickTimeMax)
            {
                doubleClickTimeCount = 0;
                clickedOnce = false;
            }
        }
        else
        {
            doubleClickTimeCount = 0;
        }

        if (hovering && Input.GetMouseButtonDown(0))
        {
            if (clickedOnce)
            {
                if (attachedWindow.activeSelf)
                {
                    attachedWindow.SetActive(false);
                }
                else
                {
                    attachedWindow.GetComponent<WebsiteSwitcher>().LoadWebsite(WebsiteDictionary.instance.WebsiteLinks["home"]);
                    attachedWindow.SetActive(true);

                }
                
                attachedWindow.GetComponent<RectTransform>().SetAsLastSibling();
            }
            else
            {
                clickedOnce = true;
                //StartCoroutine(doubleClick());
            }
        }

    }

    public void PointerEnter()
    {
        hovering = true;
    }
    public void PointerExit()
    {
        hovering = false;
    }
}
