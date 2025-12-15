using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class CultWebsiteLogin : MonoBehaviour
{
    [SerializeField]
    TMP_InputField usernameField,passwordField;
    string websiteIDToChangeTo;
    private WebsiteDictionary websiteDictionary;
    private WebsiteSwitcher websiteSwitcher;
    
    void Start()
    {
        websiteDictionary = FindFirstObjectByType<WebsiteDictionary>();
        websiteSwitcher = GetComponentInParent<WebsiteSwitcher>();
    }
    public void LoginButtonPress()
    {
        Debug.Log(usernameField.text);
        Debug.Log(passwordField.text);
        if(usernameField.text.Trim() == PublicVariables.instance.cultLoginUsername && passwordField.text.Trim() == PublicVariables.instance.cultLoginPassword)
        {
            
            websiteSwitcher.LoadWebsite(websiteDictionary.WebsiteLinks["cultWebsiteLogin"]);
        }
    }
}
