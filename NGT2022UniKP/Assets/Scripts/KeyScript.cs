using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public bool GetKey = false;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
        //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
        {
            this.gameObject.SetActive(false);
            GetKey = true;
        }
    }
}
