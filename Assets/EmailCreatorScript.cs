using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;

public class EmailCreatorScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text title,byline,body;
    string id;

    void Start()
    {
        id = EmailManager.instance.currentDisplayEmail;
        Email displayingEmail = EmailManager.instance.emailDatabaseList[id];
        title.text = displayingEmail.subject;
        byline.text = displayingEmail.sender + "\t"+ displayingEmail.dateAndTime;
        body.text = displayingEmail.bodyText;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownloadEmail()
    {
        //Email displayingEmail = EmailManager.instance.emailDatabaseList[id];
        DownloadFilesManager.instance.DownloadEmail(id);
        NotificationWindow.instance.DownloadNotif();
    }
}
