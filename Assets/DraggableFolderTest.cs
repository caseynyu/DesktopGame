using Microsoft.Unity.VisualStudio.Editor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableFolderTest : MonoBehaviour
{
    private PointerGrabbedObject pointerGrabbedObject;
    private UnityEngine.UI.Image selfImage;
    private bool dragging = false;
    GameObject tempImage = null;
    [SerializeField]
    GameObject tempImagePrefab;
    protected Canvas canvas;

    protected Camera mainCamera;
    float zAxis = 0;
    protected Vector3 dragOffset = Vector3.zero;

    private Transform baseWindow;

    void Start()
    {
        pointerGrabbedObject = GameObject.FindFirstObjectByType<PointerGrabbedObject>();
        canvas = transform.GetComponentInParent<Canvas>();
        zAxis = transform.position.z;
        mainCamera = Camera.main;
        baseWindow = transform.parent.transform;
        selfImage = gameObject.GetComponent<UnityEngine.UI.Image>();
    }
    public void OnPointerDown(BaseEventData eventData)
    {
        //base.OnPointerDown(eventData);
    }
    public void OnPointerUp(BaseEventData eventData)
    {
        
    }
    public void OnDrag(BaseEventData eventData)
    {
        if (dragging && Input.GetMouseButton(0))
        {
            PointerEventData pointerData = (PointerEventData)eventData;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pointerData.position, canvas.worldCamera, out position);
            tempImage.transform.position = canvas.transform.TransformPoint(position);
        }
    }
    public void OnDragEnd(BaseEventData eventData)
    {
        
    }
    public void OnBeginDrag(BaseEventData eventData)
    {
        PointerEventData pointerData = (PointerEventData)eventData;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pointerData.position, canvas.worldCamera, out position);

        dragging = true;
        pointerGrabbedObject.grabbedObject = gameObject;
        tempImage = Instantiate(tempImagePrefab, canvas.transform.TransformPoint(position), quaternion.identity, canvas.transform);
        tempImage.GetComponent<UnityEngine.UI.Image>().sprite = gameObject.GetComponent<UnityEngine.UI.Image>().sprite;
        tempImage.GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
        tempImage.GetComponent<UnityEngine.UI.Image>().raycastTarget = false;
        tempImage.transform.SetAsLastSibling();
    }

    void Update()
    {
        if(dragging && Input.GetMouseButtonUp(0))
        {
            dragging = false;
            GameObject.Destroy(tempImage.gameObject);
            tempImage = null;
            pointerGrabbedObject.grabbedObject = null;
        }
    }
}
