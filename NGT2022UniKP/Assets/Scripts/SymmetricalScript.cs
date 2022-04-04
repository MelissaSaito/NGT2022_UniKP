using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetricalScript : MonoBehaviour
{
    [SerializeField] GameObject TresureBox;

   
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
        {
            this.gameObject.SetActive(false);
            TresureBox.SetActive(true);
        }
    }
}
