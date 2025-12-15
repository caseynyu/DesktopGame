using UnityEngine;

public class DeleteFiles : MonoBehaviour
{

    public GameObject recycleBinWebsite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickYes()
    {
        foreach (Transform child in recycleBinWebsite.transform)
        {
            child.GetComponent<DoubleClick>().attachedWindow.SetActive(false);
            Destroy(child.gameObject);
            Destroy(child);
        }
        //recycleBinWebsite.transform.GetComponentsInChildren<GameObject>();
        Destroy(gameObject);
    }
    public void ClickNo()
    {
        Destroy(gameObject);
    }
}
