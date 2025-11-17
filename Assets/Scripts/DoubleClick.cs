using System.Collections;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool hovering = false;
    bool clickedOnce = false;
    public GameObject myWindow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (hovering && Input.GetMouseButtonDown(0))
        {
            if (clickedOnce)
            {
                myWindow.SetActive(true);
                Debug.Log("second click");
            }
            else
            {
                Debug.Log("first click");
                clickedOnce = true;
                StartCoroutine(doubleClick());
            }
        }
    }

    IEnumerator doubleClick()
    {
        yield return new WaitForSeconds(.5f);
        clickedOnce = false;
    }

    public void pointerEnter()
    {
        hovering = true;
        Debug.Log("pointer enter");
    }
    public void pointerExit()
    {
        hovering = false;
        Debug.Log("pointer exit");
    }
}
