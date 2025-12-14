using UnityEngine;
using TMPro;
using AYellowpaper.SerializedCollections;

public class EmailBar : MonoBehaviour
{
    public TMP_Text title,byline,time;
    public string id;
    private WebsiteDictionary websiteDictionary;
    private WebsiteSwitcher websiteSwitcher;
    [SerializeField]
    GameObject deleteConfirmPopup;
    private GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = transform.GetComponentInParent<Canvas>().gameObject;
        websiteDictionary = FindFirstObjectByType<WebsiteDictionary>();
        websiteSwitcher = GetComponentInParent<WebsiteSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        EmailManager.instance.currentDisplayEmail = id;
        websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks["templateEmailWebsite"]);
    }

    public void OnDeleteClick()
    {
        GameObject deletepopup = Instantiate(deleteConfirmPopup,canvas.transform);
        deletepopup.GetComponent<DeleteEmail>().idToDelete = id;

    }

    public void DeleteEmail()
    {
        
    }
}
