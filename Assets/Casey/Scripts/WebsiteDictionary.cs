using UnityEngine;



namespace AYellowpaper.SerializedCollections
{
    public class WebsiteDictionary : MonoBehaviour
    {
        [SerializedDictionary("Website Link Name", "Website Prefab")]
        public SerializedDictionary<string, GameObject> WebsiteLinks;
    }
}

