using UnityEngine;

public class RemoveHistory : MonoBehaviour
{
    [SerializeField]
    GameObject allWebsites;

    [SerializeField]
    GameObject UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
        if (allWebsites != null)
        {allWebsites.SetActive(true);}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showUI()
    {
        UI.SetActive(true);
    }
    public void closeUI()
    {
        UI.SetActive(false);
    }

    public void deleteHistory()
    {
        Destroy(allWebsites);
    }
}

