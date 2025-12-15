using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    [SerializeField]
    GameObject PowerPopUp;
    GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject newWindow = Instantiate(PowerPopUp,canvas.transform);
        newWindow.GetComponent<ShutDownPopup>().powerButton = this;
    }

    public void Poweryes()
    {
        PublicVariables.instance.Ending();
    }

    public void PowerNo()
    {
        
    }
}
