using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    //マップの表示
    GameObject mapItem;
    [SerializeField] private Image mapImage;
    [SerializeField] bool mapFunction = false;

    void Start()
    {
        mapItem = GameObject.Find("MapItem");
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
    }

    void OnTriggerStay()
    {
        //if (Input.GetKey(KeyCode.E))
        if (Input.GetButton("ControllerA"))
        {
            mapItem.SetActive(false);
            mapFunction = true;
        }
    }
           
}
