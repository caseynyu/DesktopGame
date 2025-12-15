using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;

public class RecycleBinPage : MonoBehaviour
{
    private PointerGrabbedObject pointerGrabbedObject;
    Ray ray;
	RaycastHit hit;
    private bool hovering=false;
    [SerializeField]
    GameObject deleteConfirmPopup,cantBeDeletedPopup;
    GameObject canvas;
    void Start()
    {
        pointerGrabbedObject = GameObject.FindFirstObjectByType<PointerGrabbedObject>();
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }
    void Update()
    {
        if (hovering && pointerGrabbedObject.grabbedObject !=null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log(pointerGrabbedObject.grabbedObject);
                GameObject fileToGrab = pointerGrabbedObject.grabbedObject.GetComponent<TempFile>().originalFile;
                DoubleClick doubleClick;
                fileToGrab.TryGetComponent<DoubleClick>(out doubleClick);

                if(doubleClick != null)
                {
                    if (doubleClick.cantBeDeleted == false)
                    {
                        fileToGrab.transform.SetParent(gameObject.transform,false);
                        fileToGrab.GetComponentInChildren<TMP_Text>().color = Color.black;
                    }
                    else
                    {
                        GameObject popupObj = Instantiate(cantBeDeletedPopup,canvas.transform);
                        popupObj.GetComponent<PopUpWindow>().SetupPopUp("This file can not be deleted.");
                    }
                    

                } 
            }
        }
    }

    public void DeleteConfirmation()
    {
        GameObject deletepopup = Instantiate(deleteConfirmPopup,canvas.transform);
        deletepopup.GetComponent<DeleteFiles>().recycleBinWebsite = gameObject;
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
