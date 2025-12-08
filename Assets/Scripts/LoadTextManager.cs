using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using UnityEngine.Video;
using System.Data.Common;


[System.Serializable]
public class WebsiteLine
{
    public string id;
    public string textToDisplay;
}


public class LoadTextManager : MonoBehaviour
{
    [SerializeField]
    TextAsset txt;
    //string nameOfTextToLoad;
    //TMP_Text textBoxToDisplay;
    //public string lineIDToDisplay;
    public Dictionary<string,WebsiteLine> weblines=new Dictionary<string, WebsiteLine>();
    public static LoadTextManager instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {  
        instance = this;
        TextWindowLoader.loadTextManager = this;
        //textBoxToDisplay = gameObject.GetComponent<TMP_Text>();
        LoadDialogue();
        //SetText();
    }

    /*void SetText()
    {
        textBoxToDisplay.text = weblines[lineIDToDisplay].textToDisplay;
    }*/

    public void SetText(TMP_Text text,string lineIdToDisplay)
    {
        text.text = weblines[lineIdToDisplay].textToDisplay;
    }

    private void LoadDialogue()
    {
        StringReader sr=new StringReader(txt.text);
        sr.ReadLine();
        while (true)
        {
            
            string line=sr.ReadLine();
            if(line == null)
            {
                break;
            }
            string[] data= line.Split("\t");
            if(data[0] == "")
            {
                continue;
            }
            WebsiteLine newLine = new WebsiteLine
            {
                id = data[0],
                textToDisplay = data[1] == ""?"default":data[1]
            ,
            };
            weblines.Add(data[0],newLine);
        }
        

        
    }

}
