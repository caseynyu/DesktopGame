using UnityEngine;


namespace AYellowpaper.SerializedCollections
{
        public class DownloadFilesManager : MonoBehaviour
    {

        public static DownloadFilesManager instance;

        [SerializedDictionary("Download Link ID", "DownloadPrefab")]
        public SerializedDictionary<string, GameObject> downloadObjects;

        [SerializeField]
        Transform downloadFolderParent;
        void Awake()
        {
            instance = this;
        }
        public void DownloadFile(string linkId)
        {
             Instantiate(downloadObjects[linkId],downloadFolderParent);
        }
    }
}

