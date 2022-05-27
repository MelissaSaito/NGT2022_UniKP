using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerScript : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    [SerializeField]
    float moveSpeed = 15.0f;
    [SerializeField]
    float slowMoveSpeed = 5.0f;

    
    Animator m_Animator;

    //走るse
    [SerializeField] AudioClip[] clips;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    protected AudioSource audioSource;


    //GameObject UpperBody;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //UpperBody = GameObject.Find("UpperBody");
        m_Animator = GetComponent<Animator>();
        audioSource = GetComponents<AudioSource>()[0];
    }

    void Update()
    {

        m_Animator.SetFloat("Speed", rb.velocity.magnitude);
    }
    void LateUpdate()
    {
        //キーボードのWASDとコントローラーの左スティックから入力を取るやつ
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //slow移動
        if (Input.GetButton("ControllerB"))
        //if (Input.GetKey(KeyCode.C))
        {
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * slowMoveSpeed + new Vector3(0, rb.velocity.y, 0);

            //上のCube無くす
            //UpperBody.SetActive(false);


        }
        else
        {
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            //上のCube写す
            //UpperBody.SetActive(true);

        }

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);

        }
    }


    public void PlayFootstepSE()
    {
        if (randomizePitch)
            audioSource.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
