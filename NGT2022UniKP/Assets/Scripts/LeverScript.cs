using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private string[] tags = new string[] { "RightLever" , "LeftLever" , "CenterLever" };    //�^�O�����p�z��o�E�A���A�^�񒆁p�̏�
    /*private static int[] leverLock = new int[] { 0, 0, 0 };*/     //���̂�bool���܂������Ȃ������̂�int�^�Ő���(���o�[��)
    private static int answerCount = 0, moveCount = 0;              //�����J�E���g, ����J�E���g
    private static bool pushFlag = false;       //���d���萧��(�{�^����)

    GameObject door;

   // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        //�^�񒆁��E�����Ńh�A���J��
        if(answerCount == 3)
        {
            door.SetActive(false);
        }

        //���Z�b�g
        if (moveCount == 3)     //���o�[�������ď��Ԃ��Ԉ���Ă����烊�Z�b�g
        {
            answerCount = 0;
            moveCount = 0;
            //leverLock[0] = 0;
            //leverLock[1] = 0;
            //leverLock[2] = 0;
            Debug.Log("���Z�b�g");
        }

        //�t���O���Z�b�g
        if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonUp("ControllerA"))
        {
            pushFlag = false;
        }

    }

    //�L�[�{�[�h�A�R���g���[���[����
    void OnTriggerStay(Collider other)
    {
        //�E���o�[
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[0]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[0] == 0)
                if(pushFlag == false)
                {
                    Debug.Log("�E��������");
                    pushFlag = true;
                    //leverLock[0]++;

                    if (answerCount == 1)
                    {

                        answerCount++;
                        moveCount++;
                        Debug.Log("�����Ă�");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("�Ⴄ");
                    }
                }
            }

        }

        //�����o�[
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[1] == 0)
                if (pushFlag == false)
                {
                    Debug.Log("����������");
                    pushFlag = true;
                    //leverLock[1]++;

                    if (answerCount == 2)
                    {
                        answerCount++;
                        moveCount++;
                        Debug.Log("�����Ă�");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("�Ⴄ");
                    }
                }
            }
        }

        //�^�񒆃��o�[
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                //if (leverLock[2] == 0)
                if (pushFlag == false)
                {
                    Debug.Log("�^�񒆂�������");
                    pushFlag = true;
                    //leverLock[2]++;

                    if (answerCount == 0)
                    {
                        answerCount++;
                        moveCount++;
                        Debug.Log("�����Ă�");
                    }

                    else
                    {
                        moveCount++;
                        Debug.Log("�Ⴄ");
                    }
                }
            }
        }
    }
}
