using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    public void DragHandler (BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
