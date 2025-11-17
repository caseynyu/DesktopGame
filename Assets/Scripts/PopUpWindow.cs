using UnityEngine;
using TMPro;

public class PopUpWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBox;

    public bool destroyOnClose;

    void Awake()
    {
        
    }

    public void SetupPopUp(string message)
    {
        textBox.text = message;
    }

    public void WindowClose()
    {
        if (destroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
    

}
