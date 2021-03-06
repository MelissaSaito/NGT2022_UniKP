using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class LookBackEnemyScript : MonoBehaviour
{
    private int num;
    private int count;
    private Quaternion targetRot;

    //03/30内村追加-------------------------------------
    //会話関連
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// 表示させるメッセージ
    public string[] message2;// 表示させるメッセージ


    private bool talk1 = true;
    private bool talk2 = true;
    //---------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += 1;

        if (count % 500 == 0)
        {
            // 数字が１＞２＞３＞０＞１＞２・・・とループする。
            num = (num + 1) % 4;
        }


        var step = Time.deltaTime * 60f;

        // Y座標を軸として、ゆっくり９０度ずつ角度を変える。
        // ９０にnumを掛けることで、９０＞１８０＞２７０＞０＞９０＞１８０・・・と角度がループする（ポイント）
        targetRot = Quaternion.AngleAxis(90 * num, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, step);
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

                talk2 = false;
            }

        }
    }
}
