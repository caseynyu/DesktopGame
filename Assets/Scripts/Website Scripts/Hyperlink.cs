using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using AYellowpaper.SerializedCollections;

public class Hyperlink : MonoBehaviour, IPointerClickHandler
{
    private WebsiteDictionary websiteDictionary;
    private WebsiteSwitcher websiteSwitcher;

    void Awake()
    {
        websiteDictionary = FindFirstObjectByType<WebsiteDictionary>();
        websiteSwitcher = GetComponentInParent<WebsiteSwitcher>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text text = GetComponent<TextMeshProUGUI>();
        //Debug.Log(text.text);

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, Camera.main);

        TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
        string linkId = linkInfo.GetLinkID();

        Debug.Log(websiteDictionary.WebsiteLinks[linkId]);
        websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks[linkId]);


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
}
