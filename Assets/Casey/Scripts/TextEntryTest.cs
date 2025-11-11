using UnityEngine;
using TMPro;

public class TextEntryTest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI output;
    [SerializeField]
    TMP_InputField input;


    public void ButtonTest()
    {
        output.text = input.text;
    }
}
