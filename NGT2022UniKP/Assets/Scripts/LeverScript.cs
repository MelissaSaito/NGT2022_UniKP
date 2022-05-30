using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverScript : MonoBehaviour
{
    private string[] tags = new string[] { "RightLever" , "LeftLever" , "CenterLever" };    //タグ検索用配列｛右、左、真ん中｝の順
    private static int answerCount = 0, moveCount = 0;              //正解カウント, 操作カウント
    private static bool pushFlag = false;       //多重判定制御(ボタン式)
    private bool miss = false;
    private bool open = false;
    private float timer = 0.0f;
    public Text misstext;

    public AudioClip sound1;
    AudioSource audioSource;

    GameObject door;

   // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        misstext.text = "";

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //真ん中→右→左でドアが開く
        if(answerCount == 3)
        {
            door.SetActive(false);
            open = true;
        }

        if (miss)
        {
            timer++;
            if (timer == 180.0f)
            {
                misstext.text = "";
                timer = 0.0f;
                miss = false;

            }
        }

        //リセット
        if (moveCount == 3)     //レバーを押して順番が間違っていたらリセット
        {
            answerCount = 0;
            moveCount = 0;
            Debug.Log("リセット");
            miss = true;
            if (!open)
                misstext.text = "順番が違うようだ…";
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
                
                if(pushFlag == false)
                {
                    Debug.Log("右を押した");
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

        //左レバー
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                
                if (pushFlag == false)
                {
                    Debug.Log("左を押した");
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

        //真ん中レバー
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                
                if (pushFlag == false)
                {
                    Debug.Log("真ん中を押した");
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
    }
}
