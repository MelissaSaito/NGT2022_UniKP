using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRayScript : MonoBehaviour

{
    //��b�֘A
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// �\�������郁�b�Z�[�W
    public string[] message2;// �\�������郁�b�Z�[�W

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

    private bool isFounded = false;//�����锻��

    [SerializeField] GameObject playerRockScript;

    //�V�[���t���O�p04/27�����ǉ�-----------------------------------
    public bool fine;
    [SerializeField] GameObject player;
    [SerializeField] PlayerStateScript playerState;
    //----------------------------------------------------------------



    void Start()
    {
        //05/02�����ǉ�----------------------------------------------------
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerStateScript>();
        //-----------------------------------------------------------------
    }
    //--------------------------------------------------------------

    //enemy����player�܂Ō������o��
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


        //enemy���ʂ̃x�N�g��
        var enemyForward = gameObject.transform.forward;

        //����������������
        if (Physics.Raycast(transform.position, enemyForward, out RaycastHit hit, rayDistance))
        {
            //�Ώۂ�tag��player�������猩�������Ɖ�ʂɕ\������B
            if (isTrigger == true && hit.collider.gameObject.tag == ("Player"))
            {
                //////�����ǉ��t���b�V���̗L��
                //if (playerRockScript.GetComponent<PlayerLockScript>().getFlash() == false)
                //{
                    isFounded = true;
                fine = true;
                    if (talk2 == true)
                    {
                        StartCoroutine("Message", message2);// Message�R���[�`�������s����
                        messageScript.talkflag = true;
                        talk2 = false;
                    }
                //}
                //else
                //{

                //}
                //05/03�ǉ�����
                //�v���C���[�̏�Ԃ�DEATH��--------------------------
                //playerState.flag = StateFlags.DEATH;
                //---------------------------------------------------
            }
            else
            {
                messageScript.talkflag = false;
                isFounded = false;
                fine = false;

            }

            //�����������̂̏����擾�������ꍇ��
            //GameObject hitObject = hit.collider.gameObject;
            //Debug.Log(hitObject);

            //������ԐF��Draw����
            Debug.DrawRay(transform.position, enemyForward * rayDistance, Color.red);
        }



        //
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

    void ForwardToPlayer()
    {
        //���ʂ��������x�N�g��
        var current = transform.forward;

        //player�܂ł̃x�N�g��
        var target = playerRig.position - transform.position;

        //x-z���ʂɂ�����@���x�N�g��
        var plane = Vector3.up;

        //x-z���ʂɂ������x�N�g��
        var from = Vector3.ProjectOnPlane(current, plane);
        var to = Vector3.ProjectOnPlane(target, plane);

        //y������]���ɂ����v���C���[�܂ł̊p�x
        var targetAngle = Vector3.SignedAngle(from, to, plane) * Mathf.Rad2Deg;

        //��]���X���[�Y�ɂ���
        var smoothAngle = Mathf.SmoothDamp(transform.eulerAngles.y, targetAngle, ref vel, smooth, maxSpeed);

        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        isTrigger = true;

        if (other.gameObject.tag == ("Player") && isFounded == false)
        {
            ForwardToPlayer();
            //K�������Ɖ�b���󂯎���
            //if (Input.GetKeyDown(KeyCode.K))
            if (Input.GetButtonDown("ControllerRTrigger") || Input.GetKeyDown(KeyCode.K))

            {
                if (talk1 == true)
                {
                    Debug.Log("���̕����͂����Ǝ���Ă��邾�낤��");
                    StartCoroutine("Message", message1);// Message�R���[�`�������s����
                    messageScript.talkflag = true;
                    messageScript.eraseTimeFlag = true;

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

    IEnumerator Message(string[] Conversation)// Message�R���[�`�� 
    {
        yield return new WaitForSeconds(0.01f);// 0.01�b�҂�
        //messageScript.SetMessagePanel(message);// messageScript��SetMessagePanel�����s����

        messageScript.SetMessagePanel(Conversation);// messageScript��SetMessagePanel�����s����

    }


}

