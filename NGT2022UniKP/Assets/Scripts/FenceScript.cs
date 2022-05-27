using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    private GameObject key;
    private KeyScript keyScript;
    Animator Ani_fence_2;
    string state;

    // Start is called before the first frame update
    private void Start()
    {
        key = GameObject.Find("Key");
        keyScript = key.GetComponent<KeyScript>();
        Ani_fence_2 = GetComponent<Animator>();
        Ani_fence_2.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //if (key.GetComponent<KeyScript>().GetKey)
        //{
        if (keyScript.GetKey == true)
        {


            if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerA"))
            //if (other.CompareTag("Player") && Input.GetButton("ControllerA"))
            {
                //``doahiraku
                //this.gameObject.SetActive(false);
                if (Ani_fence_2.speed == 0)
                {
                    Ani_fence_2.speed = 1;
                }

                Ani_fence_2.SetBool(state, true);
            }
            //}
        }
    }
}

