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

    [SerializeField]
    bool overridePDF=false;
    [SerializeField]
    int photoInt;
    public override void Start()
    {
        base.Start();
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
        if (overridePDF)
        {
            attachedWindow = PublicVariables.instance.photos[photoInt];
        }
    }

    public void Setup(string newemailID)
    {
        Debug.Log(newemailID);
        emailID = newemailID;
        string titleText = EmailManager.instance.emailDatabaseList[newemailID].subject;
        string iconName;
        if (titleText.Length > 12)
        {
            iconName = titleText.Substring(0,10)+"...";
        }
        else
        {
            iconName = titleText;
        }
        iconNameTextBox.text = iconName;
        
    }
    public override void WhenDoubleClicked()
    {
        if (!overridePDF)
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
        else
        {
            if (attachedWindow.activeSelf)
            {
                attachedWindow.SetActive(false);
            }
            else
            {
                attachedWindow.SetActive(true);
            }
            
            attachedWindow.GetComponent<RectTransform>().SetAsLastSibling();
        }
        
    }
}
