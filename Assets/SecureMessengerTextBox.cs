using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecureMessengerTextBox : MonoBehaviour
{
    TMP_Text textBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textBox = GetComponent<TMP_Text>();
        SecureTextMessenger.instance.StartSecureMessenger();
    }

    void Update()
    {
        textBox.text = SecureTextMessenger.instance.textBoxText;
        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.parent.GetComponent<RectTransform>().sizeDelta.x,textBox.textInfo.lineCount * 45);
    }

    public void ButtonYes()
    {
        SecureTextMessenger.instance.PlayerYes();
    }

    public void ButtonNo()
    {
        SecureTextMessenger.instance.PlayerNo();
    }
}
