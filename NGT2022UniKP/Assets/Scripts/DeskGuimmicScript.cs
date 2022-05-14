using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskGuimmicScript : MonoBehaviour
{
    private string[] tags = new string[] { "Desk1", "Desk2", "Desk3", "Desk4", "Desk5" };    //タグ検索用配列
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
        //ドアが開く     (Desk2→Desk5→Desk3→Desk1→Desk4)
        if (answerCount == 5)
        {
            door.SetActive(false);
        }

        //リセット
        if (moveCount == 5)     //順番が間違っていたらリセット
        {
            answerCount = 0;
            moveCount = 0;
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
        //Desk1
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[0]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk1を押した");
                    pushFlag = true;

                    if (answerCount == 3)
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

        //Desk2
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk2を押した");
                    pushFlag = true;

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

        //Desk3
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk3を押した");
                    pushFlag = true;
                    
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

        //Desk4
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[3]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk4を押した");
                    pushFlag = true;
                    
                    if (answerCount == 4)
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

        //Desk5
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[4]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk5を押した");
                    pushFlag = true;
                    
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
    }
}

