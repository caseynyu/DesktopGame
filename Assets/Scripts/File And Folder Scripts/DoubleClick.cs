using System.Collections;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool hovering = false;
    bool clickedOnce = false;
    public GameObject attachedWindow;
    [SerializeField]
    private float doubleClickTimeMax=.4f;
    private float doubleClickTimeCount;

    public bool cantBeDeleted=false;
    public virtual void Start()
    {
        doubleClickTimeCount = 0f;
    }

    // Update is called once per frame
    public void Update()
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
                WhenDoubleClicked();
            }
            else
            {
                clickedOnce = true;
                //StartCoroutine(doubleClick());
            }
        }

    }

    public virtual void WhenDoubleClicked()
    {
        if (attachedWindow.activeSelf)
        {
            attachedWindow.SetActive(false);
        }
        else
        {
            attachedWindow.SetActive(true);
        }
        
        attachedWindow.GetComponent<RectTransform>().SetAsLastSibling();
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
