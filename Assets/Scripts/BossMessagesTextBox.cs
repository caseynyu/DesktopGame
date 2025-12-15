using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BossMessagesTextBox : MonoBehaviour
{
    TMP_Text textBox;
    [SerializeField]
    TMP_InputField playerInputText;
    [SerializeField]
    int linesize=45;
    
    [SerializeField]
    public ScrollRect scrollView;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.parent.GetComponent<RectTransform>().sizeDelta.x,textBox.textInfo.lineCount * linesize);
        if(textBox.text != TextMessage.instance.bossBoxText)
        {
            textBox.text = TextMessage.instance.bossBoxText;
            transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.parent.GetComponent<RectTransform>().sizeDelta.x,textBox.textInfo.lineCount * linesize);
            scrollView.verticalScrollbar.value = 0;
        }
        
        //NotificationWindow.instance.Hide();
    }


    public void SendMessage()
    {
        TextMessage.instance.AddBossPlayerTextMessage(playerInputText.text);
        playerInputText.text = "";
    }
}
