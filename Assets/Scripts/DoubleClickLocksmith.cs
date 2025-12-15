using UnityEngine;

public class DoubleClickLocksmith : DoubleClick
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        attachedWindow = FindFirstObjectByType<DropLockedFile>(FindObjectsInactive.Include).GetComponentInParent<ClosableWindow>(true).gameObject;
    }
}
