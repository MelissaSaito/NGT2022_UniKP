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
    private float timer = 0.0f;
    [SerializeField] bool timeTrigger = false;
    [SerializeField] bool isTrigger = false;
    [SerializeField] public Text itemText;

    void Start()
    {
        mapImage.enabled = false;
        itemText.text = "";
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

            timer++;

            if (timer == 180.0f)
                itemText.text = "";
        }
    }

    

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Map")
        {
            if (Input.GetButton("ControllerA") || Input.GetKey(KeyCode.E))
            {
                Debug.Log("マップを見つけた");
                itemText.text = "マップを見つけた";

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
