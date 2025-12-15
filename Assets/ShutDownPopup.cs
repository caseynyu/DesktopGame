using UnityEngine;

public class ShutDownPopup : MonoBehaviour
{
    public PowerButton powerButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickYes()
    {
        powerButton.Poweryes();
        Destroy(gameObject);
    }

    public void ClickNo()
    {
        Destroy(gameObject);
    }
}
