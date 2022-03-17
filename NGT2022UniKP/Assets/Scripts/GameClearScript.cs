using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClearScript : MonoBehaviour
{
    [SerializeField] private static float flameSec = 50.0f;
    public TresureBoxScript tresureBox;
    [SerializeField] private TMP_Text gameClearMessage;
    [SerializeField] private float gameClearCount;
    public bool stage1Finish = false;


    void Start()
    {
        tresureBox = GameObject.Find("TresureBox").GetComponent<TresureBoxScript>();
        gameClearMessage.enabled = false;
        gameClearCount = flameSec * 5.0f;
    }

    void FixedUpdate()
    {
        if (stage1Finish == true)
        {
            gameClearCount -= Time.deltaTime * 50.0f;
            Debug.Log(gameClearCount);
        }

        if (gameClearCount <= 0.0f)
        {
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (tresureBox.GameClear == true)
        {
            gameClearMessage.enabled = true;
            stage1Finish = true;
        }
    }
}
