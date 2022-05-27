using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SaveLoadScript;

public class SelectSceneScipt : MonoBehaviour
{
    [SerializeField] GameObject nowStage;
    [SerializeField] GameObject nextStage;

    GameObject saveLoadObject;
    SaveLoadScript saveLoadScript;

    string[] stageName = new string[4] { "Stage1", "Stage2", "Stage3", "Stage4"};

    bool changeStage;

    [SerializeField] private int stageNo;

    [SerializeField] public int stageLimit;

    [SerializeField] GameObject[] g_stageObject = new GameObject[4];

    public AudioClip sound1;
    AudioSource audioSource;


    void Start()
    {
        stageNo = 0;

        stageLimit = 0;

        nowStage = GameObject.Find(stageName[stageNo]);
        nextStage = GameObject.Find(stageName[stageNo]);
        saveLoadObject = GameObject.Find("SaveLoadSystem");

        saveLoadScript = saveLoadObject.GetComponent<SaveLoadScript>();
        saveLoadScript.Load();

        for (int i = 0; i < stageLimit; i++)
        {
            g_stageObject[i] = GameObject.Find(stageName[i]);
        }

        changeStage = true;

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        nextStage = GameObject.Find(stageName[stageNo]);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("ControllerLTrigger"))
        {
            stageNo--;

            if (stageNo >= 0)
            {
                //��(sound1)��炷
                audioSource.PlayOneShot(sound1);
            }

            nowStage = nextStage;

            if (stageNo <= 0)
            {
                stageNo = 0;
            }
            nextStage = GameObject.Find(stageName[stageNo]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("ControllerRTrigger"))
        { 
            stageNo++;

            nowStage = nextStage;

            if (stageNo >= stageLimit - 1)
            {
                stageNo = stageLimit - 1;
            }

            if (stageNo <= 0)
            {
                stageNo = 0;
            }
            nextStage = GameObject.Find(stageName[stageNo]);

            if (nowStage != nextStage)
            {
                //��(sound1)��炷
                audioSource.PlayOneShot(sound1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("ControllerB"))
        {
            if (changeStage == true)
            {
                changeStage = false;
                SceneManager.LoadScene(stageName[stageNo], LoadSceneMode.Single);
                Debug.Log("Loaded to " + stageName[stageNo]);

                
            }
        }



        nextStage.GetComponent<Image>().enabled = true;

        if (nowStage != nextStage)
        {
            nowStage.GetComponent<Image>().enabled = false;
        }
    }
}


