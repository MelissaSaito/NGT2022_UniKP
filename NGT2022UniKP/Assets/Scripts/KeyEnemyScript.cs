using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyEnemyScript : MonoBehaviour

{
    //会話関連
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// 表示させるメッセージ
    public string[] message2;// 表示させるメッセージ

    private bool talk1 = true;
    private bool talk2 = true;


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

    //05/27追加内村
    private GameObject key;
    private KeyScript keyScript;

    //

    void Start()
    {
        //05/02内村追加----------------------------------------------------
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
        //-----------------------------------------------------------------

        //05/27追加内村
        key = GameObject.Find("Key");
        keyScript = key.GetComponent<KeyScript>();

        //
    }
    //--------------------------------------------------------------

    //enemyからplayerまで光線を出す
    private void FixedUpdate()
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
            messageScript.eraseTimeFlag = false;
            messageScript.displayTime = 0.0f;
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
                isFounded = true;
                fine = true;
                if (talk2 == true)
                {
                    StartCoroutine("Message", message2);// Messageコルーチンを実行する
                    messageScript.talkflag = true;
                    talk2 = false;
                }
            }
            else
            {
                messageScript.talkflag = false;
                isFounded = false;
                fine = false;

            }

            //光線を赤色でDrawする
            Debug.DrawRay(transform.position, enemyForward * rayDistance, Color.red);
        }

    }

    void EraseTalk()
    {
        if (talk1 == false)
        {
            talk1 = true;
        }
        if (talk2 == false)
        {
            talk2 = true;
        }

        Debug.Log("消去しました");
        messageScript.messageText.text = "";
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
            ForwardToPlayer();
            //Kを押すと会話が受け取れる
            //if (Input.GetKeyDown(KeyCode.K))
            if (Input.GetButtonDown("ControllerRTrigger") || Input.GetKeyDown(KeyCode.K))

            {
                if (talk1 == true)
                {
                    Debug.Log("鍵ゲット");
                    StartCoroutine("Message", message1);// Messageコルーチンを実行する
                    messageScript.talkflag = true;
                    messageScript.eraseTimeFlag = true;


                    //0527内村追加------------------------------
                    //鍵フラグ手に入れる
                    keyScript.GetKey = true;
                    //------------------------------------------

                    talk1 = false;


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

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    IEnumerator Message(string[] Conversation)// Messageコルーチン 
    {
        yield return new WaitForSeconds(0.01f);// 0.01秒待つ

        messageScript.SetMessagePanel(Conversation);// messageScriptのSetMessagePanelを実行する

    }


}

