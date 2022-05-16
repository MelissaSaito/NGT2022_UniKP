using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEnemyManagmentScript : MonoBehaviour
{

    FlagEnemyScript flagEnemyScript;
    RoamingEnemyScript roamingEnemyScript1;
    RoamingEnemyScript roamingEnemyScript2;


    GameObject flagEnemy1;
    GameObject flagEnemy1_2;
    GameObject flagEnemy1_3;




    GameObject flagEnemy2;
    GameObject flagEnemy2_2;
    GameObject flagEnemy2_3;


    public bool moveFlag;

    //Collider boxCollider;
    //Collider sphereCollider;
    //Collider boxCollider2;
    //Collider sphereCollider2;

    //FlagEnemy2Script flagEnemyScript;

    //FlagEnemyScript enemyRayScript;
    //FlagEnemyScript roamingEnemyScript;



    void Start()
    {
        flagEnemy1 = GameObject.Find("FlagEnemy1");
        flagEnemy1_2 = GameObject.Find("FlagEnemy1_2");
        flagEnemy1_3 = GameObject.Find("FlagEnemy1_3");

        flagEnemy2 = GameObject.Find("FlagEnemy2");
        flagEnemy2_2 = GameObject.Find("FlagEnemy2_2");
        flagEnemy2_3 = GameObject.Find("FlagEnemy2_3");


        moveFlag = false;

        //boxCollider = flagEnemy1.GetComponent<BoxCollider>();
        //sphereCollider = flagEnemy1.GetComponent<SphereCollider>();
        //boxCollider2 = flagEnemy2.GetComponent<BoxCollider>();
        //sphereCollider2 = flagEnemy2.GetComponent<SphereCollider>();

        flagEnemyScript = flagEnemy1.GetComponent<FlagEnemyScript>();
        roamingEnemyScript1 = flagEnemy1_2.GetComponent<RoamingEnemyScript>();
        roamingEnemyScript2 = flagEnemy2_2.GetComponent<RoamingEnemyScript>();

        flagEnemy1.SetActive(true);
        flagEnemy2.SetActive(true);
        flagEnemy2_2.SetActive(false);
        flagEnemy2_3.SetActive(false);
        flagEnemy1_2.SetActive(false);
        flagEnemy1_3.SetActive(false);



    }
    //--------------------------------------------------------------

    private void FixedUpdate()
    {

        //聞き耳でエネミーが動き始めるやつ
        if (flagEnemyScript.moveEnemyFlag == true)
        {
            flagEnemy1.SetActive(false);
            flagEnemy2.SetActive(false);
            flagEnemy1_2.SetActive(true);
            flagEnemy2_2.SetActive(true);

        }
        else
        {
            flagEnemy1.SetActive(true);
            flagEnemy2.SetActive(true);
        }

        //フラグエネミー２がベッドに着いたらうごくのきえて寝てるの出る
        if (roamingEnemyScript2.wayPointNumber >= 5)
        {
            flagEnemy2_2.SetActive(false);
            flagEnemy2_3.SetActive(true);
        }
        if (roamingEnemyScript1.wayPointNumber >= 2)
        {
            flagEnemy1_2.SetActive(false);
            flagEnemy1_3.SetActive(true);
        }


        if (moveFlag == false)
        {
            //sphereCollider.enabled = true;
            //sphereCollider2.enabled = true;


            //boxCollider.enabled = false;
            //boxCollider2.enabled = false;
        }
        if (moveFlag == true)
        {


            //boxCollider.enabled = true;
            //boxCollider2.enabled = true;

            //sphereCollider.enabled = false;
            //sphereCollider2.enabled = false;

            //これをtrueにするとFlagEnemyScriptで鍵ゲットできる状態になる
            //flagEnemyScript.keyFlag = true;


        }
    }


}
