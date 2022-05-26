//----------------------------------------------------------------
// 徘徊エネミーのスクリプト
//  作成者:佐田
//　03/30会話関連追加(内村)
//  05/02死亡判定追加(内村)
//----------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class RoamingEnemyScript : MonoBehaviour
{
    [SerializeField] [Tooltip("巡回する地点の配列")] private Transform[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private float enemySpeed = 3.0f;

    // 05/02内村追加
    //プレイヤーとプレイヤー状態スクリプトの入れ物----------------------------
    GameObject player;
    PlayerStateScript playerState;
    //------------------------------------------------------------------------

    //03/30内村追加-------------------------------------
    //会話関連
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// 表示させるメッセージ
    public string[] message2;// 表示させるメッセージ


    [SerializeField] private bool talk1 = true;
    [SerializeField] private bool talk2 = true;
    //---------------------------------------------------

    //05/16内村追加
    public int wayPointNumber;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
        // 最初の目的地を入れる
        navMeshAgent.SetDestination(waypoints[0].position);

        //05/02内村追加---------------------------------------------------------------------------
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
        //-----------------------------------------------------------------------------

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 目的地点までの距離(remainingDistance)が目的地の手前までの距離(stoppingDistance)以下になったら
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // 目的地の番号を１更新（右辺を剰余演算子にすることで目的地をループさせれる）
            currentWaypointIndex = (currentWaypointIndex + 1);
            //0516内村追加
            wayPointNumber = currentWaypointIndex;

            currentWaypointIndex = wayPointNumber % waypoints.Length;
            // 目的地を次の場所に設定
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);

    }
    //03/30内村追加-----------------------------------------------------------------------------

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


    IEnumerator Message(string[] Conversation)// Messageコルーチン 
    {
        yield return new WaitForSeconds(0.01f);// 0.01秒待つ
        //messageScript.SetMessagePanel(message);// messageScriptのSetMessagePanelを実行する

        messageScript.SetMessagePanel(Conversation);// messageScriptのSetMessagePanelを実行する

    }

    //------------------------------------------------------------------------------------

    //Playerを発見した時
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("発見した!!");
            if (talk2 == true)
            {
                StartCoroutine("Message", message2);// Messageコルーチンを実行する
                messageScript.talkflag = true;
                messageScript.eraseTimeFlag = true;
                //05/02内村追加---------------------------------------------------------------------------
                //  発見されたら死亡判定をPlayerStateへ

                Invoke("DelayScene", 3f);
             
                //----------------------------------------------------------------------------------------
                talk2 = false;
            }
           
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.speed = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.speed = enemySpeed;
        }
    }

    void DelayScene()
    {
        playerState.flag = StateFlags.DEATH;
    }
}
