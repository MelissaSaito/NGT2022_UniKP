using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryGimmickScript : MonoBehaviour
{
    [SerializeField] GameObject carryDoor, carryDoor2;
    private bool set = false;

    // Start is called before the first frame update
    void Start()
    {
        carryDoor.SetActive(true);
        carryDoor2.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            carryDoor.SetActive(false);
            carryDoor2.SetActive(false);
        }
           
        if(other.gameObject.tag == "SyBall")
        {
            carryDoor.SetActive(false);
            carryDoor2.SetActive(false);
            set = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && set == false)
        {
            carryDoor.SetActive(true);
            carryDoor2.SetActive(true);
        }
        
        if (other.gameObject.tag == "SyBall")
        {
            carryDoor.SetActive(true);
            carryDoor2.SetActive(true);
            set = false;
        }

    }
}
