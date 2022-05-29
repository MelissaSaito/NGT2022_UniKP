using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class TitleChange : MonoBehaviour
{
    bool locks = false;
    GameObject titleVideo1;
    GameObject titleVideo2;
    GameObject titleVideo3;
    GameObject transitionVideo;
    GameObject transitionVideo2;

    GameObject Startbutton;
    GameObject Exitbutton; 

    VideoPlayer titleVideoPlayer1;
    VideoPlayer titleVideoPlayer2;
    VideoPlayer titleVideoPlayer3;
    VideoPlayer transitionVideoPlayer;
    VideoPlayer transitionVideoPlayer2;

    bool changeScene = true;

    bool selectScene = false;

    bool finalScene = false;

    //最初スタートボタンの表示
    bool startSelect = true;

    bool goToNextScene = false;

    [SerializeField] int selectNum = 0;

    //SE
    [SerializeField] AudioClip select;
    [SerializeField] AudioClip enter;

    //一回だけガラスSE
    static bool selectMusic = false;
    static bool enterMusic = false;
    void Start()
    {
        titleVideo1 = GameObject.Find("title(1)");
        titleVideo2 = GameObject.Find("title(2)");
        titleVideo3 = GameObject.Find("title(3)");
        transitionVideo = GameObject.Find("screen transition");
        transitionVideo2 = GameObject.Find("screen transition2");

        Startbutton = GameObject.Find("Start");
        Exitbutton = GameObject.Find("Exit");

        Startbutton.GetComponent<Image>().enabled = false;
        Exitbutton.GetComponent<Image>().enabled = false;

        titleVideoPlayer1 = titleVideo1.GetComponent<VideoPlayer>();
        titleVideoPlayer2 = titleVideo2.GetComponent<VideoPlayer>();
        titleVideoPlayer3 = titleVideo3.GetComponent<VideoPlayer>();
        transitionVideoPlayer = transitionVideo.GetComponent<VideoPlayer>();
        transitionVideoPlayer2 = transitionVideo2.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goToNextScene)
        {
            SceneManager.LoadScene("SelectScene");
        }

        titleVideoPlayer1.loopPointReached += TitleScene1;
        transitionVideoPlayer.loopPointReached += TitleScene2;
        transitionVideoPlayer2.loopPointReached += Finish;


        if ((Input.anyKeyDown) && changeScene == false)
        {
            locks = true;
            changeScene = true;
            
        }

        if(locks == true && changeScene == true)
        {

            titleVideoPlayer2.enabled = false;
            transitionVideoPlayer.enabled = true;
            transitionVideoPlayer.Play();
            
        }

        if (selectScene == true)
        {
            float ver = Input.GetAxis("Vertical");

            if (startSelect)
            {
                startSelect = false;
                Startbutton.GetComponent<Image>().enabled = true;
            }

            if (ver == -1 || Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectMusic = true;
                if (selectMusic == true)
                {
                    selectMusic = false;
                    GetComponent<AudioSource>().PlayOneShot(select);
                }

                selectNum++;
                if (selectNum > 1)
                {
                    selectNum = 1;
                }
                Startbutton.GetComponent<Image>().enabled = false;
                Exitbutton.GetComponent<Image>().enabled = true;


            }

            if (ver == 1 || Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectMusic = true;
                if (selectMusic == true)
                {
                    selectMusic = false;
                    GetComponent<AudioSource>().PlayOneShot(select);
                }
                selectNum--;
                if (selectNum < 0)
                {
                    selectNum = 0;
                }
                Exitbutton.GetComponent<Image>().enabled = false;
                Startbutton.GetComponent<Image>().enabled = true;
            }

            if (selectNum == 0 && (Input.GetButtonDown("ControllerB") || Input.GetKeyDown(KeyCode.Return)))
            {
                enterMusic = true;
                if (enterMusic == true)
                {
                    enterMusic = false;
                    GetComponent<AudioSource>().PlayOneShot(enter);
                }
                titleVideoPlayer3.Stop();
                titleVideoPlayer3.enabled = false;
                finalScene = true;
            }

            if (selectNum == 1 && (Input.GetButtonDown("ControllerB") || Input.GetKeyDown(KeyCode.Return)))
            {
                enterMusic = true;
                if (enterMusic == true)
                {
                    enterMusic = false;
                    GetComponent<AudioSource>().PlayOneShot(enter);
                }
                Application.Quit();
            }

            
        }
        if (finalScene == true)
        {
            changeScene = false;
            Startbutton.SetActive(false);
            Exitbutton.SetActive(false);
            transitionVideoPlayer2.enabled = true;
            transitionVideoPlayer2.Play();

        }
    }

    public void TitleScene1(VideoPlayer vp)
    {
        changeScene = false;
        titleVideoPlayer1.Stop();
        titleVideoPlayer1.enabled = false;
        titleVideoPlayer2.enabled = true;
        titleVideoPlayer2.Play();
    }

    public void TitleScene2(VideoPlayer vp)
    {
        locks = false;
        transitionVideoPlayer.Stop();
        transitionVideoPlayer.enabled = false;
        selectScene = true;
        titleVideoPlayer3.enabled = true;
        titleVideoPlayer3.Play();
    }

    public void Finish(VideoPlayer vp)
    {
        transitionVideoPlayer2.Stop();
        transitionVideoPlayer2.enabled = false;
        finalScene = false;

        goToNextScene = true;
    }
}
