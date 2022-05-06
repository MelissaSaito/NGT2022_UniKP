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

    //03/30�����ǉ�-------------------------------------
    //��b�֘A
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// �\�������郁�b�Z�[�W
    public string[] message2;// �\�������郁�b�Z�[�W


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
            // �������P���Q���R���O���P���Q�E�E�E�ƃ��[�v����B
            num = (num + 1) % 4;
        }

        
        var step = Time.deltaTime * 60f;

        // Y���W�����Ƃ��āA�������X�O�x���p�x��ς���B
        // �X�O��num���|���邱�ƂŁA�X�O���P�W�O���Q�V�O���O���X�O���P�W�O�E�E�E�Ɗp�x�����[�v����i�|�C���g�j
        targetRot = Quaternion.AngleAxis(90 * num, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, step);
    }
    //03/30�����ǉ�-----------------------------------------------------------------------------

    private void FixedUpdate()
    {
        //��b�����@�\----------------------------------------------------
        if (messageScript.eraseTimeFlag == true)
        {
            messageScript.displayTime += Time.deltaTime;

        }
        if (messageScript.displayTime >= 20.0f)
        {
            //Debug.Log("�����t���O��������");
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

        Debug.Log("�������܂���");
        messageScript.messageText.text = "";
        messageScript.eraseFlag = false;

    }


    IEnumerator Message(string[] Conversation)// Message�R���[�`�� 
    {
        yield return new WaitForSeconds(0.01f);// 0.01�b�҂�
        //messageScript.SetMessagePanel(message);// messageScript��SetMessagePanel�����s����

        messageScript.SetMessagePanel(Conversation);// messageScript��SetMessagePanel�����s����

    }

    //------------------------------------------------------------------------------------

    //Player�𔭌�������
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("��������!!");
            if (talk2 == true)
            {
                StartCoroutine("Message", message2);// Message�R���[�`�������s����
                messageScript.talkflag = true;
                messageScript.eraseTimeFlag = true;

                talk2 = false;
            }

        }
    }
}
