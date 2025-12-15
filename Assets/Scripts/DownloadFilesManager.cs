using TMPro;
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
        [SerializeField]
        GameObject EmailFilePrefab;
        void Awake()
        {
            instance = this;
        }
        public void DownloadFile(string linkId)
        {
             Instantiate(downloadObjects[linkId],downloadFolderParent);
        }

        public void DownloadEmail(string emailID)
        {
            Debug.Log(emailID);
            GameObject newFile = Instantiate(EmailFilePrefab,downloadFolderParent);
            newFile.GetComponent<PDFClick>().Setup(emailID);
        }
    }
}

