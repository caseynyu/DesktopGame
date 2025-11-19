using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;

public class FileManagerPage : MonoBehaviour
{
    private PointerGrabbedObject pointerGrabbedObject;
    Ray ray;
	RaycastHit hit;
    void Start()
    {
        pointerGrabbedObject = GameObject.FindFirstObjectByType<PointerGrabbedObject>();
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("test");
            }
		}
    }
    public void OnPointerUp(BaseEventData eventData)
    {
        if(pointerGrabbedObject.grabbedObject != null)
        {
            Debug.Log(pointerGrabbedObject.grabbedObject);
        }
    }
}
