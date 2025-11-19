using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableTest : MonoBehaviour
{
    //This Makes the windows draggable
    //[SerializeField]
    private Canvas canvas;

    private Camera mainCamera;
    float zAxis = 0;
    Vector3 dragOffset = Vector3.zero;

    private Transform baseWindow;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        
    }
    void Start()
    {
        canvas = transform.GetComponentInParent<Canvas>();
        zAxis = transform.position.z;
        mainCamera = Camera.main;
        baseWindow = transform.parent.transform;
    }

    public void OnPointerDown(BaseEventData eventData)
    {
        PointerEventData pointerData = (PointerEventData)eventData;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pointerData.position, canvas.worldCamera, out position);
        dragOffset = transform.position - canvas.transform.TransformPoint(position);
        baseWindow.SetAsLastSibling();
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnDrag(BaseEventData eventData)
    {
        //PointerEventData pointerData = (PointerEventData)data;
        PointerEventData pointerData = (PointerEventData)eventData;
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, pointerData.position, canvas.worldCamera, out position);
        baseWindow.position = canvas.transform.TransformPoint(position) + dragOffset;

        //RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
        //transform.position = canvas.transform.TransformPoint(position);
    }
}
