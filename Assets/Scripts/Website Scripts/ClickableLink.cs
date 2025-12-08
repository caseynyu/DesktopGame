using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using AYellowpaper.SerializedCollections;

public class ClickableLink : MonoBehaviour, IPointerClickHandler
{
    private WebsiteDictionary websiteDictionary;
    private WebsiteSwitcher websiteSwitcher;
    public string storedWebsiteToSwitch;

    void Awake()
    {
        websiteDictionary = FindFirstObjectByType<WebsiteDictionary>();
        websiteSwitcher = GetComponentInParent<WebsiteSwitcher>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks[storedWebsiteToSwitch]);
    }
}
