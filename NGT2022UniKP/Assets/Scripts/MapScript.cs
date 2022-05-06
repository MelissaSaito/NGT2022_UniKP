using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    //マップの表示
    [SerializeField] private Image mapImage;
    [SerializeField] bool mapFunction = false;

    private float countTime = 0.0f;
    [SerializeField] bool timeTrigger = false;
    [SerializeField] bool isTrigger = false;

    void Start()
    {
        mapImage.enabled = false;
    }

    
    void Update()
    {

        //if (mapFunction == true && Input.GetKeyUp(KeyCode.T))
        if (mapFunction == true && Input.GetButtonUp("ControllerY"))

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
