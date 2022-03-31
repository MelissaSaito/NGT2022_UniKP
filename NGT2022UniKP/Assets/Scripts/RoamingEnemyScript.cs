using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class RoamingEnemyScript : MonoBehaviour
{
    [SerializeField] [Tooltip("���񂷂�n�_�̔z��")] private Transform[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private float enemySpeed = 3.0f;

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
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
        // �ŏ��̖ړI�n������
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        // �ړI�n�_�܂ł̋���(remainingDistance)���ړI�n�̎�O�܂ł̋���(stoppingDistance)�ȉ��ɂȂ�����
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // �ړI�n�̔ԍ����P�X�V�i�E�ӂ���]���Z�q�ɂ��邱�ƂŖړI�n�����[�v�������j
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            // �ړI�n�����̏ꏊ�ɐݒ�
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
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
}
