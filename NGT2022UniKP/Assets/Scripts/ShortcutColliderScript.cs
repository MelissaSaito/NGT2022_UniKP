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
            Debug.Log("�M�~�b�N�g�p��");
            shortCut.SetActive(true);
    }
}
