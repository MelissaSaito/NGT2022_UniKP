using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxScript : MonoBehaviour
{
    public bool GameClear = false;
    private bool pickUp = false;
    public bool picked = false;

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
    //    //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
    //    {
    //        this.gameObject.SetActive(false);
    //        GameClear = true;
    //    }
    //}

    void Update()
    {
        if (pickUp == true && Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("ControllerA"))
        {
            this.gameObject.SetActive(false);
            picked = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        pickUp = false;
    }

}
