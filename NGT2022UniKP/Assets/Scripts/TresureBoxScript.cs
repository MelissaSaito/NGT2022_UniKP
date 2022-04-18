using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxScript : MonoBehaviour
{
    public bool GameClear = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
        //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
        {
            this.gameObject.SetActive(false);
            GameClear = true;
        }
    }

}
