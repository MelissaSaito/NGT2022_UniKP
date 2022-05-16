using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TresureBoxScript : MonoBehaviour
{
    public bool GameClear = false;
    private bool pickUp = false;
    public bool picked = false;

    public string  sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (pickUp == true && Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("ControllerA"))
        {
            if (sceneName == "Stage3")
            {
                this.gameObject.SetActive(false);
            }


            GameClear = true;

            picked = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUp = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        pickUp = false;
    }

}
