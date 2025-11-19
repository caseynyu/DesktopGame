using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PopupCreateTest : MonoBehaviour
{
    [SerializeField]
    Transform canvas;

    [SerializeField]
    GameObject popupPrefab;

    [SerializeField]
    TMP_InputField input;
    
    public void CreatePopup()
    {
        GameObject popupObj = Instantiate(popupPrefab, Vector3.zero, Quaternion.identity,canvas);
        popupObj.GetComponent<PopUpWindow>().SetupPopUp(input.text);
    }
}
