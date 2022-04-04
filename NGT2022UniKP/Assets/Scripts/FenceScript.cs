using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key");
    }

    void OnTriggerStay(Collider other)
    {
        if (key.GetComponent<KeyScript>().GetKey == true)
        {
            if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
            //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))

            {
                this.gameObject.SetActive(false);
            }

        }
    }
}

