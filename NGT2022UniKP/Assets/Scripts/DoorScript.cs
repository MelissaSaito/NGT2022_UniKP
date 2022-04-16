using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (key.GetComponent<KeyScript>().GetKey)
        {
            if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
                //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))

            {
                this.gameObject.SetActive(false);
            }

        }
    }
}

