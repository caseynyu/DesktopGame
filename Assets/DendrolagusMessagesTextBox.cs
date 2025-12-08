using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DendrolagusMessagesTextBox : MonoBehaviour
{
    TMP_Text textBox;
    [SerializeField]
    TMP_Text playerInputText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = TextMessage.instance.textBoxText;
    }

    public void SendMessage()
    {
        TextMessage.instance.AddPlayerTextMessage(playerInputText.text);
        playerInputText.text = "";
    }
}
