using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShortcutColliderScript : MonoBehaviour
{

    [SerializeField] GameObject shortCut;

    void Start()
    {
        shortCut.SetActive(false);
    }


    void OnTriggerStay(Collider other)
    {
            Debug.Log("ギミック使用中");
            shortCut.SetActive(true);
    }
}
