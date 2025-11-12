using UnityEngine;
using TMPro;

public class PopUpWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBox;

    void Awake()
    {
        
    }

    public void SetupPopUp(string message)
    {
        textBox.text = message;
    }

    public void WindowClose()
    {
        Destroy(gameObject);
    }
    

}
