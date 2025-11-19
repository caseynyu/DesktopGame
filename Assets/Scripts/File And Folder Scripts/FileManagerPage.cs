using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;

public class FileManagerPage : MonoBehaviour
{
    private PointerGrabbedObject pointerGrabbedObject;
    Ray ray;
	RaycastHit hit;
    private bool hovering=false;
    void Start()
    {
        pointerGrabbedObject = GameObject.FindFirstObjectByType<PointerGrabbedObject>();
    }
    void Update()
    {
        if (hovering && pointerGrabbedObject.grabbedObject !=null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(pointerGrabbedObject.grabbedObject);
                GameObject fileToGrab = pointerGrabbedObject.grabbedObject.GetComponent<TempFile>().originalFile;

                fileToGrab.transform.SetParent(gameObject.transform,false);
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
