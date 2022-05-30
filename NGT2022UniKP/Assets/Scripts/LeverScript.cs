using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverScript : MonoBehaviour
{
    private string[] tags = new string[] { "RightLever" , "LeftLever" , "CenterLever" };    //�^�O�����p�z��o�E�A���A�^�񒆁p�̏�
    private static int answerCount = 0, moveCount = 0;              //�����J�E���g, ����J�E���g
    private static bool pushFlag = false;       //���d���萧��(�{�^����)
    private bool miss = false;
    private bool open = false;
    private float timer = 0.0f;
    public Text misstext;

    public AudioClip sound1;
    AudioSource audioSource;

    GameObject door;

   // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        misstext.text = "";

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�^�񒆁��E�����Ńh�A���J��
        if(answerCount == 3)
        {
            door.SetActive(false);
            open = true;
        }

        if (miss)
        {
            timer++;
            if (timer == 180.0f)
            {
                misstext.text = "";
                timer = 0.0f;
                miss = false;

            }
        }

        //���Z�b�g
        if (moveCount == 3)     //���o�[�������ď��Ԃ��Ԉ���Ă����烊�Z�b�g
        {
            answerCount = 0;
            moveCount = 0;
            Debug.Log("���Z�b�g");
            miss = true;
            if (!open)
                misstext.text = "���Ԃ��Ⴄ�悤���c";
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
                
                if(pushFlag == false)
                {
                    Debug.Log("�E��������");
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

        //�����o�[
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[1]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                
                if (pushFlag == false)
                {
                    Debug.Log("����������");
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

        //�^�񒆃��o�[
        if (other.CompareTag("Player") && this.gameObject.CompareTag(tags[2]))
        {
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            {
                
                if (pushFlag == false)
                {
                    Debug.Log("�^�񒆂�������");
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
    }
}
