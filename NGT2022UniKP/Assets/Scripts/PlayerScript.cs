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

    //����se
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
        //�L�[�{�[�h��WASD�ƃR���g���[���[�̍��X�e�B�b�N������͂������
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //slow�ړ�
        if (Input.GetButton("ControllerB"))
        //if (Input.GetKey(KeyCode.C))
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * slowMoveSpeed + new Vector3(0, rb.velocity.y, 0);

            //���Cube������
            //UpperBody.SetActive(false);


        }
        else
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            //���Cube�ʂ�
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
