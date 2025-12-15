using TMPro;
using UnityEngine;

public class PDFViewer : MonoBehaviour
{
    [SerializeField]
    TMP_Text titleTextBox,bodyTextBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupPDF(string titleText,string bodyText)
    {
        titleTextBox.text = titleText;
        bodyTextBox.text = bodyText;
    }

    public void PrintPDF()
    {
        NotificationWindow.instance.PrintingNotif();
        PublicVariables.instance.PrintedDocuments(bodyTextBox.text);
    }
}
