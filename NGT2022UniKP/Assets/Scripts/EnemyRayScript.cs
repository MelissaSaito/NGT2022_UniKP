using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRayScript : MonoBehaviour

{
    //会話関連
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// 表示させるメッセージ
    public string[] message2;// 表示させるメッセージ

    [SerializeField] private bool talk1;
    [SerializeField] private bool talk2;


    [Header("Ray")]
    [SerializeField] LayerMask mask;
    [SerializeField] float rayDistance;
    [SerializeField] float smooth;
    [SerializeField] float maxSpeed;
    [SerializeField] Rigidbody playerRig;

    [Header("Collider")]
    [SerializeField] bool isTrigger = false;

    private float vel;

    private bool isFounded = false;//見つかる判定

    [SerializeField] GameObject playerRockScript;

    //シーンフラグ用04/27内村追加-----------------------------------
    public bool fine;
    [SerializeField] GameObject player;
    [SerializeField] PlayerStateScript playerState;
    //----------------------------------------------------------------

    [SerializeField]private bool kikimimi = false;


    void Start()
    {
        talk1 = true;
        talk2 = true;
        //05/02内村追加----------------------------------------------------
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
        //-----------------------------------------------------------------
    }
    //--------------------------------------------------------------

    //enemyからplayerまで光線を出す
    private void Update()
    {

        //会話消去機能----------------------------------------------------
        if (messageScript.eraseTimeFlag == true)
        {
            messageScript.displayTime += Time.deltaTime;

        }


        if (messageScript.displayTime >= 20.0f)
        {
            //Debug.Log("消去フラグがたった");
            //messageScript.eraseFlag = true;
            EraseTalk();
            //talk1 = true;
            messageScript.eraseTimeFlag = false;
            messageScript.displayTime = 0.0f;
            //messageText.text = "";// 文字を空白にする
            //StartCoroutine("Message", message3);
            

        }
        //---------------------------------------------------------------------


        //enemy正面のベクトル
        var enemyForward = gameObject.transform.forward;

        //光線があたった時
        if (Physics.Raycast(transform.position, enemyForward, out RaycastHit hit, rayDistance))
        {
            //対象のtagがplayerだったら見つかったと画面に表示する。
            if (isTrigger == true && hit.collider.gameObject.tag == ("Player"))
            {
                //////ここ追加フラッシュの有無
                //if (playerRockScript.GetComponent<PlayerLockScript>().getFlash() == false)
                //{
                    isFounded = true;
                fine = true;
                    if (talk2 == true)
                    {
                        StartCoroutine("Message", message2);// Messageコルーチンを実行する
                        messageScript.talkflag = true;
                        talk2 = false;
                    }

                //}
                //else
                //{

                //}
                //05/03追加内村
                //プレイヤーの状態をDEATHへ--------------------------
                Invoke("DelayScene", 3f);

                //---------------------------------------------------
            }
            else
            {
                messageScript.talkflag = false;
                isFounded = false;
                fine = false;

            }

            //あたったものの情報を取得したい場合↓
            //GameObject hitObject = hit.collider.gameObject;
            //Debug.Log(hitObject);

            //光線を赤色でDrawする
            Debug.DrawRay(transform.position, enemyForward * rayDistance, Color.red);
        }

        if (kikimimi == true)
        {
            ForwardToPlayer();
            //Kを押すと会話が受け取れる
            //if (Input.GetKeyDown(KeyCode.K))
            if (Input.GetButtonDown("ControllerRTrigger") || Input.GetKeyDown(KeyCode.K))

            {
                EraseTalk();

                if (talk1 == true)
                {
                    Debug.Log("奥の部屋はちゃんと守られているだろうか");
                    StartCoroutine("Message", message1);// Messageコルーチンを実行する
                    messageScript.talkflag = true;
                    messageScript.eraseTimeFlag = true;
                    
                }
                else
                {

                    if (messageScript.displayTime >= 20.0f)
                    {
                        EraseTalk();
                        messageScript.eraseTimeFlag = false;
                        messageScript.displayTime = 0.0f;

                    }
                    messageScript.talkflag = false;
                }
                
            }

        }
    }

    void EraseTalk()
    {

        talk1 = true;
        talk2 = true;

        Debug.Log("消去しました");
        messageScript.messageText.text = "";
        //messageScript.conversation = null;
        //StartCoroutine("");
        messageScript.eraseFlag = false;

    }

    void ForwardToPlayer()
    {
        //正面を向いたベクトル
        var current = transform.forward;

        //playerまでのベクトル
        var target = playerRig.position - transform.position;

        //x-z平面における法線ベクトル
        var plane = Vector3.up;

        //x-z平面にうつしたベクトル
        var from = Vector3.ProjectOnPlane(current, plane);
        var to = Vector3.ProjectOnPlane(target, plane);

        //y軸を回転軸にしたプレイヤーまでの角度
        var targetAngle = Vector3.SignedAngle(from, to, plane) * Mathf.Rad2Deg;

        //回転をスムーズにする
        var smoothAngle = Mathf.SmoothDamp(transform.eulerAngles.y, targetAngle, ref vel, smooth, maxSpeed);

        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        isTrigger = true;

        if (other.gameObject.tag == ("Player") && isFounded == false)
        {

            kikimimi = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            isTrigger = false;
            kikimimi = false;
        }
            
    }

    IEnumerator Message(string[] Conversation)// Messageコルーチン 
    {
        yield return new WaitForSeconds(0.01f);// 0.01秒待つ
        //messageScript.SetMessagePanel(message);// messageScriptのSetMessagePanelを実行する

        messageScript.SetMessagePanel(Conversation);// messageScriptのSetMessagePanelを実行する

    }

    void DelayScene()
    {
        playerState.flag = StateFlags.DEATH;
    }
}

