using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    GameObject targetObj;
    Vector3 targetPos;

    //��]������X�s�[�h
    private float rotateSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - targetPos;

    }

    // Update is called once per frame
    void Update()
    {
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - targetPos;

        //transform.position = pos;

        targetPos = targetObj.transform.position;

        //��]������p�x
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;

        //�v���C���[���S�ŉ�]
        transform.RotateAround(targetPos, Vector3.up, angle);

    }
}
