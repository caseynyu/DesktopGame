using Unity.VisualScripting;
using UnityEngine;

public class WebsiteSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject loadedSite;

    [SerializeField]
    private Transform viewport;

    [SerializeField]
    CustomScrollRect customScrollRect;



    public void LoadWebsite(GameObject siteToLoad)
    {
        if(loadedSite != null)
        {
            //reminder make error for if the link is one space
            Debug.Log("test");
            Destroy(loadedSite);
            loadedSite = null;
            loadedSite = Instantiate(siteToLoad, viewport.position, Quaternion.identity, viewport);
            customScrollRect.content = loadedSite.GetComponent<RectTransform>();
        }
    }

}
