//---------------------------------------------------------------------------------------------
// シーン移行に関するプログラム  作成:キテイ　死亡判定とか:内村
//
//---------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player; //プレイヤーの入れ物
    [SerializeField] PlayerStateScript playerState;//PlayerStateScriptの入れ物


    void Start()
    {
        //プレイヤーとPlayerStateScript持ってくる
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
    }

    void FixedUpdate()
    {
        GetComponent<VideoPlayer>().loopPointReached += GameOver;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            // 処理実行
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("ControllerY"))
            {
                //シーンを変える
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            //プレイヤーステータスの状態がDEATHの時
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("死亡");
                //次のゲームシーンの為に生き返らせる
                playerState.flag = StateFlags.LIVE;
                //シーンを変える
                SceneManager.LoadScene("GameOver");

            }

        }
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            //プレイヤーステータスの状態がDEATHの時
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("死亡");
                //次のゲームシーンの為に生き返らせる
                playerState.flag = StateFlags.LIVE;
                GameObject.Find("Panel").SetActive(false);
                GetComponent<VideoPlayer>().Play();

            }

        }

        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            //プレイヤーステータスの状態がDEATHの時
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("死亡");
                //次のゲームシーンの為に生き返らせる
                playerState.flag = StateFlags.LIVE;
                GameObject.Find("Panel").SetActive(false);
                GetComponent<VideoPlayer>().Play();

            }

        }

        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            //プレイヤーステータスの状態がDEATHの時
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("死亡");
                //次のゲームシーンの為に生き返らせる
                playerState.flag = StateFlags.LIVE;
                GameObject.Find("Panel").SetActive(false);
                GetComponent<VideoPlayer>().Play();

            }

        }
        if (SceneManager.GetActiveScene().name == "Stage4")
        {
            //プレイヤーステータスの状態がDEATHの時
            if (playerState.flag == StateFlags.DEATH)
            {
                Debug.Log("死亡");
                //次のゲームシーンの為に生き返らせる
                playerState.flag = StateFlags.LIVE;
                GameObject.Find("Panel").SetActive(false);
                GetComponent<VideoPlayer>().Play();

            }

        }



        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            // 処理実行
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("ControllerY"))
            {
                //シーンを変える
                SceneManager.LoadScene("Title");
            }
        }

    }

    public void GameOver(VideoPlayer vp)
    {
        SceneManager.LoadScene("SelectScene");
    }
}
