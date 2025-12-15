using System.Collections;
using TMPro;
using UnityEngine;

public class PDFClick : DoubleClick
{
    [SerializeField]
    GameObject templatePDFWindow;
    GameObject canvas;
    [SerializeField]
    public TMP_Text iconNameTextBox;
    public string emailID;
    public override void Start()
    {
        base.Start();
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
    }

    public void Setup(string iconName)
    {
        iconNameTextBox.text = iconName;
    }
    public override void WhenDoubleClicked()
    {
        if(attachedWindow == null)
        {
            attachedWindow = GameObject.Instantiate(templatePDFWindow,canvas.transform);
            Email emailToDispaly = EmailManager.instance.emailDatabaseList[emailID];
            attachedWindow.GetComponent<PDFViewer>().SetupPDF(emailToDispaly.subject,emailToDispaly.bodyText);
        }
        else if (attachedWindow.activeSelf)
        {
            Destroy(attachedWindow);
            attachedWindow = null;
        }
    }
}
