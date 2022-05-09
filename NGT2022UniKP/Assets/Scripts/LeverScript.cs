using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private string[] tags = new string[] { "RightLever" , "LeftLever" , "CenterLever" };    //タグ検索用配列｛右、左、真ん中｝の順
    /*private static int[] leverLock = new int[] { 0, 0, 0 };*/     //何故かboolうまくいかなかったのでint型で制御(レバー式)
    private static int answerCount = 0, moveCount = 0;              //正解カウント, 操作カウント
    private static bool pushFlag = false;       //多重判定制御(ボタン式)

    GameObject door;

   // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        //真ん中→右→左でドアが開く
        if(answerCount == 3)
        {
            door.SetActive(false);
        }

        //リセット
        if (moveCount == 3)     //レバーを押して順番が間違っていたらリセット
        {
            answerCount = 0;
            moveCount = 0;
            //leverLock[0] = 0;
            //leverLock[1] = 0;
            //leverLock[2] = 0;
            Debug.Log("リセット");
        }

        //フラグリセット
        if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonUp("ControllerA"))
        {
            pushFlag = false;
        }

    }

    //キーボード、コントローラー判定
    void OnTriggerStay(Collider other)
    {
        //右レバー
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[0]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[0] == 0)
                if(pushFlag == false)
                {
                    Debug.Log("右を押した");
                    pushFlag = true;
                    //leverLock[0]++;

                    if (answerCount == 1)
                    {

                        answerCount++;
                        moveCount++;
                        Debug.Log("合ってる");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("違う");
                    }
                }
            }

        }

        //左レバー
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[1] == 0)
                if (pushFlag == false)
                {
                    Debug.Log("左を押した");
                    pushFlag = true;
                    //leverLock[1]++;

                    if (answerCount == 2)
                    {
                        answerCount++;
                        moveCount++;
                        Debug.Log("合ってる");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("違う");
                    }
                }
            }
        }

        //真ん中レバー
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[2] == 0)
                if (pushFlag == false)
                {
                    Debug.Log("真ん中を押した");
                    pushFlag = true;
                    //leverLock[2]++;

                    if (answerCount == 0)
                    {
                        answerCount++;
                        moveCount++;
                        Debug.Log("合ってる");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("違う");
                    }
                }
            }
        }
    }
}
