using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject key;
    Animator Ani_Door;
    string state;

    [SerializeField] AudioClip door;

    // Start is called before the first frame update
    private void Start()
    {
        key = GameObject.Find("Key");
        state = "IsOpen";
        Ani_Door = GetComponent<Animator>();
        Ani_Door.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (key.GetComponent<KeyScript>().GetKey)
        {
            if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
                //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
            {
                //``doahiraku
                //this.gameObject.SetActive(false);
                if (Ani_Door.speed == 0 )
                {
                    Ani_Door.speed = 1;
                }

                Ani_Door.SetBool(state, true);
                GetComponent<AudioSource>().PlayOneShot(door);
            }
        }
    }
}

