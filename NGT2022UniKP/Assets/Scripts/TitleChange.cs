using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class TitleChange : MonoBehaviour
{
    bool locks = false;
    [SerializeField] GameObject titleVideo;
    [SerializeField] GameObject transitionVideo;

    VideoPlayer titleVideoPlayer;
    VideoPlayer transitionVideoPlayer;

    bool changeScene = false;

    private void Awake()
    {
        titleVideo = GameObject.Find("title");
        transitionVideo = GameObject.Find("screen transition");

        transitionVideo.SetActive(false);

        titleVideoPlayer = titleVideo.GetComponent<VideoPlayer>();
        transitionVideoPlayer = transitionVideo.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("ControllerB") || Input.GetKeyDown(KeyCode.Return)) && locks == false)
        {
            locks = true;

        }

        if(locks == true && changeScene == false)
        {
            titleVideoPlayer.Stop();
            titleVideo.SetActive(false);
            GameObject.Find("TitleVideo").SetActive(false);
            transitionVideo.SetActive(true);
            transitionVideoPlayer.loopPointReached += Finish;
            transitionVideoPlayer.Play();
            changeScene = true;
        }

        
    }

    public void Finish(VideoPlayer vp)
    {
        SceneManager.LoadScene("SelectScene");
    }
}
