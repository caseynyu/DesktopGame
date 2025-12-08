using System.Collections;
using UnityEngine;
using UnityEngine.Video;

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
        //DEBUG KEYS ETC - REMOVE BEFORE SUBMITTING FINAL
        if (Input.GetKey(KeyCode.Space))
        {
            openingVideo.SetActive(false);
        }
    }

    IEnumerator playVideo(GameObject videoPlayer, float s)
    {
        yield return new WaitForSeconds(s);
        videoPlayer.SetActive(false);
    }
}
