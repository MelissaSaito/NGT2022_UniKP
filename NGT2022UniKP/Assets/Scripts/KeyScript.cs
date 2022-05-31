using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public bool GetKey = false;
    
    [SerializeField] AudioClip itemGet;

    bool se = false;

    private void Update()
    {
        transform.Rotate(1.0f, 1.0f, 1.0f);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
        {
            if (se == false)
            {
                se = true;
                GetComponent<AudioSource>().PlayOneShot(itemGet);
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetKey = true;
        }
    }
}
