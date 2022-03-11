using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed = 15.0f;
    float slowMoveSpeed = 5.0f;
    GameObject UpperBody;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpperBody = GameObject.Find("UpperBody");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        inputVertical = Input.GetAxisRaw("Vertical");


        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //slow�ړ�
        if (Input.GetKey(KeyCode.C))
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * slowMoveSpeed + new Vector3(0, rb.velocity.y, 0);

            //���Cube������
            UpperBody.SetActive(false);


        }
        else
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            //���Cube�ʂ�
            UpperBody.SetActive(true);

        }

        transform.rotation = Quaternion.LookRotation(moveForward);


    }

}
