using UnityEngine;
using TMPro;

public class TextWindowLoader : MonoBehaviour
{
    public static LoadTextManager loadTextManager;
    [SerializeField]
    private TMP_Text textBoxToDisplay;
    [SerializeField]
    private string lineIdToDisplay;

    void Start()
    {
        textBoxToDisplay = GetComponent<TMP_Text>();
        LoadTextManager.instance.SetText(textBoxToDisplay,lineIdToDisplay);
    }

    /*void SetText()
    {
        
    }*/
}
