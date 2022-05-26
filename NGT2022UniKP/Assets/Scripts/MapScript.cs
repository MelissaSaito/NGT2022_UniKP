using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    //�}�b�v�̕\��
    [SerializeField] public Image mapImage;
    [SerializeField] public bool mapFunction = false;

    private float countTime = 0.0f;
    [SerializeField] bool timeTrigger = false;
    [SerializeField] bool isTrigger = false;

    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        mapImage.enabled = false;
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {

        //if (mapFunction == true && Input.GetKeyDown(KeyCode.T))
        if (mapFunction == true && Input.GetButtonDown("ControllerY"))

        {
            if (mapImage.enabled == true)
            {
                mapImage.enabled = false;
                return;
            }
            mapImage.enabled = true;
        }

        if (mapFunction == true)
        {
            countTime++;
            if(countTime >= 20.0f)
            {
                timeTrigger = true;
            }
            if (isTrigger && timeTrigger)
            {
                if (Input.GetButton("ControllerA") || Input.GetKey(KeyCode.E))
                {
                    Debug.Log("�����Ȃ�����");
                }
            }
        }
    }

    

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Map")
        {
            if (Input.GetButton("ControllerA") || Input.GetKey(KeyCode.E))
            {
                Debug.Log("�}�b�v��������");

                other.gameObject.tag = "Drawer";
                mapFunction = true;
                //��(sound1)��炷
                audioSource.PlayOneShot(sound1);
            }
        }

        if (other.gameObject.tag == "Drawer")
        {
            if (Input.GetButton("ControllerA") || Input.GetKey(KeyCode.E))
            {
                isTrigger = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Drawer")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drawer")
        {
            isTrigger = false;
        }
    }
}
