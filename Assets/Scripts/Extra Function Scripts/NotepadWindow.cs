using UnityEngine;
using TMPro;

public class NotepadWindow : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input;
    void Start()
    {
        input.text = "ptrgale012\nRPassword123";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WindowClose()
    {
        gameObject.SetActive(false);
    }
}
