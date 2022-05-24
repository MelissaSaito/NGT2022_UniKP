using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleChange : MonoBehaviour
{
    bool locks = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("ControllerB") && locks == false)
        {
            locks = true;
            SceneManager.LoadScene("SelectScene");

        }

        if (Input.GetButtonUp("ControllerB"))
        {
            locks = false;
        }
    }
}
