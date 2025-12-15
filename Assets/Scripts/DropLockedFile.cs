using UnityEngine;
using TMPro;
using AYellowpaper.SerializedCollections;
using UnityEditor;

public class DropLockedFile : FileManagerPage
{
    [SerializeField]
    TMP_Text fileNameTextBox;
    [SerializeField]
    GameObject popupWindow;
    bool fileLoaded=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log(hovering);
        if (hovering && pointerGrabbedObject.grabbedObject !=null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameObject fileToGrab = pointerGrabbedObject.grabbedObject.GetComponent<TempFile>().originalFile;
                //Debug.Log(fileToGrab.name);
                if (fileToGrab.gameObject.CompareTag("lockedfile"))
                {   
                    fileNameTextBox.text = "File Loaded!!";
                    fileLoaded=true;
                    
                }
                else
                {
                    GameObject newpopup = Instantiate(popupWindow,PublicVariables.canvas.transform);
                    newpopup.GetComponent<PopUpWindow>().SetupPopUp("This file doesn't need to be unlocked!!");
                }
    
            }
        }
    }

    public void UnlockFile()
    {
        NotificationWindow.instance.DownloadNotif();
        DownloadFilesManager.instance.DownloadFile("password");
        fileNameTextBox.text = "Drop Locked File Here !!!";
    }
}
