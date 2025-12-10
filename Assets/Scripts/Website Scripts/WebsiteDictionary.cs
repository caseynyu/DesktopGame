using UnityEngine;



namespace AYellowpaper.SerializedCollections
{
    public class WebsiteDictionary : MonoBehaviour
    {
        public static WebsiteDictionary instance;
        void Awake()
        {
            instance = this;
        }
        [SerializedDictionary("Website Link Name", "Website Prefab")]
        public SerializedDictionary<string, GameObject> WebsiteLinks;
    }
}

