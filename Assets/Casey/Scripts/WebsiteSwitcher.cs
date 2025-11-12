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
            Debug.Log("test");
            Destroy(loadedSite);
            loadedSite = null;
            loadedSite = Instantiate(siteToLoad, viewport.position, Quaternion.identity, viewport);
            customScrollRect.content = loadedSite.GetComponent<RectTransform>();
        }
    }

}
