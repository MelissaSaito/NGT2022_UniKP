using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    //マップの表示
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
        //Componentを取得
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
                    Debug.Log("何もなかった");
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
                Debug.Log("マップを見つけた");

                other.gameObject.tag = "Drawer";
                mapFunction = true;
                //音(sound1)を鳴らす
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
