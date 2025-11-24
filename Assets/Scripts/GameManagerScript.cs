using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public GameObject openingVideo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(playVideo(openingVideo, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playVideo(GameObject videoPlayer, float s)
    {
        yield return new WaitForSeconds(s);
        videoPlayer.SetActive(false);
    }
}
