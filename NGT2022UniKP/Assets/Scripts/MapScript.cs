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
        if (mapFunction == true && Input.GetKeyUp(KeyCode.T) || Input.GetButton("ControllerY"))
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
        if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerX"))
        {
            mapItem.SetActive(false);
            mapFunction = true;
        }
    }
           
}
