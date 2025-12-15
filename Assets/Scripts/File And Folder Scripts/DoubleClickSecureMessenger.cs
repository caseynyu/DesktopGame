using System.Collections;
using UnityEngine;

public class DoubleClickSecureMessenger : DoubleClick
{
    public override void Start()
    {
        base.Start();
        attachedWindow = FindFirstObjectByType<SecureMessengerTextBox>(FindObjectsInactive.Include).GetComponentInParent<WebsiteSwitcher>(true).gameObject;
    }
}
