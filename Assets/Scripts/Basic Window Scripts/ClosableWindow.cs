using UnityEngine;

public class ClosableWindow : MonoBehaviour
{
    public bool destroyOnClose = true;
    public void WindowClose()
    {
        if (destroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
    

}
