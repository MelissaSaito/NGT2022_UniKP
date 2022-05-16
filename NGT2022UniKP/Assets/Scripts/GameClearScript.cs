using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameClearScript : MonoBehaviour
{
    [SerializeField] private static float flameSec = 50.0f;
    public TresureBoxScript tresureBox;
    [SerializeField] private TMP_Text gameClearMessage;
    [SerializeField] private float gameClearCount;
    public bool stageFinish = false;//

    public Button btnA;
    public Button btnB;

    //ボタンの処理
    [SerializeField] int selectNum;

    

    void Start()
    {
        tresureBox = GameObject.Find("TresureBox").GetComponent<TresureBoxScript>();
        gameClearMessage.enabled = false;
        btnA.gameObject.SetActive(false);
        btnB.gameObject.SetActive(false);


        gameClearCount = flameSec * 5.0f;
        selectNum = 0;
    }

    void Update()
    {
        var size = new Vector2(300, 100);           //選択されてないサイズ
        var targetSize = new Vector2(400, 200);     //選択されたサイズ

        if (selectNum == 0 && stageFinish == true)
        {
            
            btnA.GetComponent<RectTransform>().sizeDelta = targetSize;

            if (Input.GetKeyDown("joystick button 0"))
            {
                Menu();
            }
            
        }
        else if (selectNum != 0 && stageFinish == true)
        {
            btnA.GetComponent<RectTransform>().sizeDelta = size;
        }

        if (selectNum == 1 && stageFinish == true)
        {
            btnB.GetComponent<RectTransform>().sizeDelta = targetSize;

            if (Input.GetKeyDown("joystick button 0"))
            {
                Continue();
            }

        }
        else if (selectNum != 1 && stageFinish == true)
        {
            btnB.GetComponent<RectTransform>().sizeDelta = size;
        }

        if (stageFinish == true)
        {
            float hor = Input.GetAxis("ControllerD-pad/H");
            //float ver = Input.GetAxis("Vertical2");

            if (hor == -1)
            {
                selectNum--;
                if (selectNum < 0)
                {
                    selectNum = 0;
                }
            }

            if (hor == 1)
            {
                selectNum++;
                if (selectNum > 1)
                {
                    selectNum = 1;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (tresureBox.GameClear == true)
        {
            gameClearMessage.enabled = true;
            btnA.gameObject.SetActive(true);
            btnB.gameObject.SetActive(true);

            stageFinish = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Continue()
    {
        string nowStage = SceneManager.GetActiveScene().name;

        if (nowStage == "Stage1")
        {
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        }

        if (nowStage == "Stage2")
        {
            SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
        }

        if (nowStage == "Stage3")
        {
            SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
        }

        if (nowStage == "Stage4")
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
