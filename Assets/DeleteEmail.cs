using UnityEngine;

public class DeleteEmail : MonoBehaviour
{
    public string idToDelete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickYes()
    {
        EmailManager.instance.currentEmails.RemoveAt(EmailManager.instance.currentEmails.IndexOf(idToDelete));
        Destroy(gameObject);
    }

    public void ClickNo()
    {
        Destroy(gameObject);
    }
}
