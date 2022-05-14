using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskGuimmicScript : MonoBehaviour
{
    private string[] tags = new string[] { "Desk1", "Desk2", "Desk3", "Desk4", "Desk5" };    //�^�O�����p�z��
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
        //�h�A���J��     (Desk2��Desk5��Desk3��Desk1��Desk4)
        if (answerCount == 5)
        {
            door.SetActive(false);
        }

        //���Z�b�g
        if (moveCount == 5)     //���Ԃ��Ԉ���Ă����烊�Z�b�g
        {
            answerCount = 0;
            moveCount = 0;
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
        //Desk1
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[0]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk1��������");
                    pushFlag = true;

                    if (answerCount == 3)
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

        //Desk2
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk2��������");
                    pushFlag = true;

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

        //Desk3
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk3��������");
                    pushFlag = true;
                    
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

        //Desk4
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[3]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk4��������");
                    pushFlag = true;
                    
                    if (answerCount == 4)
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

        //Desk5
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[4]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                if (pushFlag == false)
                {
                    Debug.Log("Desk5��������");
                    pushFlag = true;
                    
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
    }
}

