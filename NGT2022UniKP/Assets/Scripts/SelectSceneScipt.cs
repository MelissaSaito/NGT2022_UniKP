using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSceneScipt : MonoBehaviour
{
    [SerializeField] private GameObject nowStage = null;
    [SerializeField] private GameObject nextStage;

    GameObject saveLoadObject;

    SaveLoadScript saveLoadScript;

    Vector3 nowStageSize = new Vector3(3.95f, 3.909882f, 0.7109794f);
    Vector3 nextStageSize = new Vector3(3.95f, 3.909882f, 1.31f);

    [SerializeField] private Material nowStageMaterial;
    [SerializeField] private Material nextStageMaterial;



    string[] stageName = new string[5] { "Stage1", "Stage2", "Stage3", "Stage4", "Stage5" };

    bool changeStage;
    
    [SerializeField] private int stageNo = 0;

    [SerializeField] public int stageLimit;


    void Start()
    {
        stageLimit = 4;

        nextStage = GameObject.Find(stageName[stageNo]);
        saveLoadObject = GameObject.Find("SaveLoadSystem");

        stageLimit = 4;

        changeStage = true;

        saveLoadScript = saveLoadObject.GetComponent<SaveLoadScript>();
        saveLoadScript.Save();
    }

    void Update()
    {
        nextStage = GameObject.Find(stageName[stageNo]);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("ControllerLTrigger"))
        {
            stageNo--;
            
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
            
            if (stageNo >= stageLimit)
            {
                stageNo = stageLimit;
            }
            nextStage = GameObject.Find(stageName[stageNo]);
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


        if (nowStage != null && nowStage != nextStage)
        {
            nowStage.transform.localScale = nowStageSize;
            nowStage.GetComponent<MeshRenderer>().material = nowStageMaterial;
        }
        

        if (nowStage != nextStage)
        {
            nextStage.transform.localScale = nextStageSize;
            nextStage.GetComponent<MeshRenderer>().material = nextStageMaterial;
        }
            
    }

}
