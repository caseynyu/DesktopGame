using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using AYellowpaper.SerializedCollections;

public class DownloadLink : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    string downloadIndex;
    void Awake()
    {

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text text = GetComponent<TextMeshProUGUI>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, Camera.main);

        TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
        string linkId = linkInfo.GetLinkID();
        DownloadFilesManager.instance.DownloadFile(linkId);

        //Debug.Log(websiteDictionary.WebsiteLinks[linkId]);
        //websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks[linkId]);


        /*if(linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            Debug.Log(linkInfo.GetLinkID());
            websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks[linkInfo.GetLinkID()]);

            if(linkInfo.GetLinkID()== "debug")
            {
                
            }

            
        }*/
    }
    public void Download()
    {
        NotificationWindow.instance.DownloadNotif();
        DownloadFilesManager.instance.DownloadFile(downloadIndex);
    }
}
