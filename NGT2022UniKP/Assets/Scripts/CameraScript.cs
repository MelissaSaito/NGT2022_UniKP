using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    GameObject targetObj;
    Vector3 targetPos;

    //回転させるスピード
    [SerializeField]
    private float rotateSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;

    }

    // Update is called once per frame
    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;


        targetPos = targetObj.transform.position;

        //回転させる角度
        float angle = 0;
        if (Input.GetKey(KeyCode.L))
        {
            angle = 1 * rotateSpeed;
        }
        if (Input.GetKey(KeyCode.J))
        {
            angle = -1 * rotateSpeed;
        }
        if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.J))
        {
            angle = 0;
        }


        //プレイヤー中心で回転
        transform.RotateAround(targetPos, Vector3.up, angle);

    }
}
