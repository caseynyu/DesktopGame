using UnityEngine;
using TMPro;

public class DropEmailSendingPDF : FileManagerPage
{
    [SerializeField]
    TMP_Text fileNameTextBox;
    [SerializeField]
    TMP_InputField emailAddressBox;
    string storedFileID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    public override void Update()
    {
        Debug.Log(hovering);
        if (hovering && pointerGrabbedObject.grabbedObject !=null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameObject fileToGrab = pointerGrabbedObject.grabbedObject.GetComponent<TempFile>().originalFile;
                //Debug.Log(fileToGrab.name);
                PDFClick pDFClick;
                if (fileToGrab.GetComponent<PDFClick>()!= null)
                {
                    pDFClick = fileToGrab.GetComponent<PDFClick>();
                }
                else
                {
                    return;
                }
                //fileToGrab.TryGetComponent<PDFClick>(out pDFClick);
                //DoubleClick doubleClick;
                //fileToGrab.TryGetComponent<DoubleClick>(out doubleClick);
                if(pDFClick != null)
                {
                    fileNameTextBox.text = fileToGrab.GetComponent<PDFClick>().iconNameTextBox.text;
                    storedFileID = pDFClick.emailID;
                }
                else
                {
                    //fileToGrab.transform.SetParent(gameObject.transform,false);
                }
                
            }
        }
    }

    public void SendEmail()
    {
        NotificationWindow.instance.SentEmailNotif();
        PublicVariables.instance.EmailSentCheck(emailAddressBox.text,storedFileID);
        emailAddressBox.text = "";
        storedFileID = "";
        fileNameTextBox.text = "Drop PDF Here";
    }
}
