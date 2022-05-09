using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetricalScript : MonoBehaviour
{
    [SerializeField] GameObject TresureBox;
    [SerializeField] GameObject Ball_ColliderLeft;
    [SerializeField] GameObject Ball_ColliderRight;
    public float BallNum = 0;

    [SerializeField] TresureBoxScript tresureBoxScript;

    void Start ()
    {
        
    }

    void FixedUpdate()
    {
        if(Ball_ColliderLeft.GetComponent<SymmetricalScript>().BallNum == 2 && Ball_ColliderRight.GetComponent<SymmetricalScript>().BallNum == 2)
        {
            if(tresureBoxScript.picked == false)
            {
                TresureBox.SetActive(true);
            }
        }
        else
        {
            TresureBox.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SyBall")
        {
            BallNum += 0.5f;
        }
        
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "SyBall")
        {
            if(BallNum != 0)
            {
                BallNum -= 0.5f;
            }

        }


    }
}
