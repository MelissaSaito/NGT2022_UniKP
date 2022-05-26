using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskGuimmicScript : MonoBehaviour
{
    private string[] tags = new string[] { "Desk1", "Desk2", "Desk3", "Desk4", "Desk5" };    //�^�O�����p�z��
    private static int answerCount = 0, moveCount = 0;              //�����J�E���g, ����J�E���g
    private static bool pushFlag = false;       //���d���萧��(�{�^����)
    [SerializeField] public Text misstext;
    private float timer = 0.0f;
    private bool miss = false;
    private bool open = false;

    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        misstext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //�h�A���J��     (Desk2��Desk5��Desk3��Desk1��Desk4)
        if (answerCount == 5)
        {
            open = true;
            door.SetActive(false);
        }

        //���Z�b�g
        if (moveCount == 5)     //���Ԃ��Ԉ���Ă����烊�Z�b�g
        {
            answerCount = 0;
            moveCount = 0;
            Debug.Log("���Z�b�g");
            miss = true;

            if(!open)
                misstext.text = "���Ԃ��Ⴄ�悤���c";
        }

        if (miss)
            timer++;

        if(timer == 180.0f)
        {
            misstext.text = "";
            timer = 0.0f;
            miss = false;
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

