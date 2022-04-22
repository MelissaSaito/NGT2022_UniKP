using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpScript : MonoBehaviour
{
    [SerializeField] private GameObject objectHolder;

    [SerializeField] private GameObject itemToPickUp = null;
    [SerializeField] private GameObject itemHolding = null;

    private string pickUpItemTag = null;

    [SerializeField] private bool pickUp = false;
    [SerializeField] private bool holdingItem = false;
    private bool lockPickUp = false;

    void FixedUpdate()
    {
        if(pickUp == true && Input.GetKey(KeyCode.R) || Input.GetButton("ControllerY"))
        {
            HeldItem();
        }

        if(holdingItem && Input.GetKey(KeyCode.R) || Input.GetButton("ControllerY"))
        {
            itemHolding.transform.position = objectHolder.transform.position;
            lockPickUp = true;
        }
        else if(holdingItem)
        {
            itemHolding.GetComponent<Rigidbody>().isKinematic = false;
            holdingItem = false;
            lockPickUp = false;
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject pickUpItem = other.gameObject;

        pickUpItem.GetComponent<Rigidbody>().isKinematic = true;

        if (pickUpItem.tag == "SyBall" && lockPickUp == false)
        {
            itemToPickUp = pickUpItem;
            pickUp = true;
        }
    }   


    void OnTriggerExit(Collider other)
    {
        if (other == null)
        {
            itemToPickUp = null;
            pickUp = false;
        }
    }

    void HeldItem ()
    {
        itemHolding = itemToPickUp;
        itemToPickUp = null;
        holdingItem = true;
        pickUp = false;
    }

    
}
