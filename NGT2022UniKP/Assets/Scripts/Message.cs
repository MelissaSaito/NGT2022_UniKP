using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// UI�@�\���g�p���邽�߂ɒǋL

public class Message : MonoBehaviour
{
    public bool isActive;// Canvas�̕\����\��
    public GameObject canvas;// �g�p����Canvas
    public Text messageText;// ���b�Z�[�W��\�����镶��
    private string message;// �\�����郁�b�Z�[�W
    [SerializeField]
    private int maxTextLength = 90;// 1��̃��b�Z�[�W�̍ő啶����
    private int textLength = 0;// 1��̃��b�Z�[�W�̌��݂̕�����
    [SerializeField]
    private int maxLine = 3;// ���b�Z�[�W�̍ő�s��
    private int nowLine = 0;// ���݂̍s
    [SerializeField]
    private float textSpeed = 0.05f;// �e�L�X�g�X�s�[�h
    private float elapsedTime = 0f;// �o�ߎ���
    private int nowTextNum = 0;// �����Ă��镶���ԍ�
    private Image clickIcon;// �}�E�X�N���b�N�𑣂��A�C�R��
    [SerializeField]
    private float clickFlashTime = 0.2f;// �N���b�N�A�C�R���̓_�ŕb��
    private bool isOneMessage = false;// 1�񕪂̃��b�Z�[�W��\���������ǂ���
    private bool isEndMessage = false;// ���b�Z�[�W�����ׂĕ\���������ǂ���
    private string[] conversation;// ��b
    private int i = 0;// ������̗�
    private int stringsCount = 0;// ������̑��s��

    public bool talkflag = false;//��b�t���O
    public float displayTime = 0.0f;
    public bool eraseFlag = false;
    public bool eraseTimeFlag = false;


    void Start()
    {
        gameObject.SetActive(true);// ���̃I�u�W�F�N�g��\������
        //clickIcon = canvas.transform.Find("Panel/Image").GetComponent<Image>();// clickIcon���L�����o�X�̒���Panel�̒���Image�ɂ���
        //clickIcon.enabled = false;// clickIcon�̃R���|�[�l���g���I�t�ɂ���
        messageText.text = "";// �������󔒂ɂ���
    }

    void Update()
    {

        //Debug.Log(displayTime);


        if (isEndMessage || message == null)// �����A���b�Z�[�W���I����Ă��Ȃ��A�܂��͐ݒ肳��Ă���Ȃ�
        {
            return;// �Ԃ�
        }

        if (!isOneMessage)// �����A1��ɕ\�����郁�b�Z�[�W��\�����Ă��Ȃ��āA
        {
            if (elapsedTime >= textSpeed)// �e�L�X�g�\�����Ԃ��o�߂�����A
            {
                messageText.text += message[nowTextNum];// ���̕����ԍ��ɂ���

                if (message[nowTextNum] == '\n')// �����A���s������������
                {
                    nowLine++;// �s���𑫂�
                }

                nowTextNum++;// ���̕����ԍ��ɂ���
                textLength++;// ���̕������ɂ���
                elapsedTime = 0f;// �o�ߎ��Ԃ�0�ɂ���

                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)// �����A���b�Z�[�W��S���\���A�܂��͍s�����ő吔�\�����ꂽ�Ȃ�A
                {
                    isOneMessage = true;// isOneMessage��true�ɂ���
                }
            }


            elapsedTime += Time.deltaTime;// �o�ߎ��ԂɎ��Ԃ̌o�ߕ�����

        }

        else// �N���b�N����Ă��Ȃ���΁A
        {
            elapsedTime += Time.deltaTime;// �o�ߎ��ԂɎ��Ԃ̌o�ߕ�����
            //displayTime += Time.deltaTime;

            if (elapsedTime >= clickFlashTime)// �N���b�N�A�C�R����_�ł��鎞�Ԃ𒴂����Ȃ�A
            {
                //clickIcon.enabled = !clickIcon.enabled;// �N���b�N�A�C�R����_�ł�����
                elapsedTime = 0f;// �o�ߎ��Ԃ�0�ɂ���
            }

            // �N���b�N���ꂽ�玟�̕�����\�����鏈��
            //if (Input.GetMouseButtonDown(0))// �����A�N���b�N���ꂽ��A
            if (talkflag == true)// 
            {
                //messageText.text = "\n";

                //clickIcon.enabled = false;// �N���b�N�A�C�R�����I�t�ɂ���
                elapsedTime = 0f;// �o�ߎ��Ԃ�0�ɂ���
                textLength = 0;// ��������0�ɂ���
                isOneMessage = false;// isOneMessage��0�ɂ���
                                     //messageText.text = "\n";

                eraseTimeFlag = true;//�\�����Ԍv��


                if (nowTextNum >= message.Length)// �����A���b�Z�[�W���S���\������Ă�����A
                {
                    nowTextNum = 0;// ���݂̕����ԍ���0�ɂ���

                    if (i == stringsCount - 1)// �����A������̑��s���ɒB������A
                    {
                        isEndMessage = true;// isEndMessage��true�ɂ���
                        canvas.transform.GetChild(0).gameObject.SetActive(false);// �L�����o�X�̎q�I�u�W�F�N�g���\���ɂ��� 
                    }

                    else// �����A������̑��s���ɒB���Ă��Ȃ���΁A
                    {
                        i++; //i��1���₷
                        SetMessage(conversation[i]);// SetMessage�����s����
                    }
                }
            }
        }


    }

    void SetMessage(string message)// SetMessage
    {
        this.message = message + "\n";// ���̃I�u�W�F�N�g��message��message�ɂ���
    }

    public void SetMessagePanel(string[] message)// SetMessagePanel
    {
        i = 0;// i��0�ɂ���
        stringsCount = message.Length;// ������̑��s����message�̗v�f���ɂ���
        conversation = message;// coversation��message�ɂ���
        canvas.SetActive(true);// �L�����o�X��\������
        SetMessage(conversation[0]);// SetMessage�����s����
        canvas.transform.GetChild(1).gameObject.SetActive(true);// �L�����o�X�̎q�I�u�W�F�N�g��\������
        isEndMessage = false;// isEndMessage��false�ɂ���
    }
}