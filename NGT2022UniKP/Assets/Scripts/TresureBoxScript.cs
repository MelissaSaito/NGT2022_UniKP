using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxScript : MonoBehaviour
{
    public bool GameClear = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButton("ControllerX"))
        {
            this.gameObject.SetActive(false);
            GameClear = true;
        }
    }

}
