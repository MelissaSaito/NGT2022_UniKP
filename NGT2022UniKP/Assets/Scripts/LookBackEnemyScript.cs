using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class LookBackEnemyScript : MonoBehaviour
{
    private int num;
    private int count;
    private Quaternion targetRot;

    //03/30“à‘º’Ç‰Á-------------------------------------
    //‰ï˜bŠÖ˜A
    [SerializeField]
    private Message messageScript;

    [Header("EnemyMassage")]
    [SerializeField]
    public string[] message1;// •\¦‚³‚¹‚éƒƒbƒZ[ƒW
    public string[] message2;// •\¦‚³‚¹‚éƒƒbƒZ[ƒW


    private bool talk1 = true;
    private bool talk2 = true;
    //---------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;

        if (count % 500 == 0)
        {
            // ”š‚ª‚P„‚Q„‚R„‚O„‚P„‚QEEE‚Æƒ‹[ƒv‚·‚éB
            num = (num + 1) % 4;
        }

        
        var step = Time.deltaTime * 60f;

        // YÀ•W‚ğ²‚Æ‚µ‚ÄA‚ä‚Á‚­‚è‚X‚O“x‚¸‚ÂŠp“x‚ğ•Ï‚¦‚éB
        // ‚X‚O‚Énum‚ğŠ|‚¯‚é‚±‚Æ‚ÅA‚X‚O„‚P‚W‚O„‚Q‚V‚O„‚O„‚X‚O„‚P‚W‚OEEE‚ÆŠp“x‚ªƒ‹[ƒv‚·‚éiƒ|ƒCƒ“ƒgj
        targetRot = Quaternion.AngleAxis(90 * num, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, step);
    }
    //03/30“à‘º’Ç‰Á-----------------------------------------------------------------------------

    private void FixedUpdate()
    {
        //‰ï˜bÁ‹‹@”\----------------------------------------------------
        if (messageScript.eraseTimeFlag == true)
        {
            messageScript.displayTime += Time.deltaTime;

        }
        if (messageScript.displayTime >= 20.0f)
        {
            //Debug.Log("Á‹ƒtƒ‰ƒO‚ª‚½‚Á‚½");
            //messageScript.eraseFlag = true;
            EraseTalk();
            messageScript.eraseTimeFlag = false;
            messageScript.displayTime = 0.0f;
        }
        //---------------------------------------------------------------------


    }

    void EraseTalk()
    {
        if (talk1 == false)
        {
            talk1 = true;
        }
        if (talk2 == false)
        {
            talk2 = true;
        }

        Debug.Log("Á‹‚µ‚Ü‚µ‚½");
        messageScript.messageText.text = "";
        messageScript.eraseFlag = false;

    }


    IEnumerator Message(string[] Conversation)// MessageƒRƒ‹[ƒ`ƒ“ 
    {
        yield return new WaitForSeconds(0.01f);// 0.01•b‘Ò‚Â
        //messageScript.SetMessagePanel(message);// messageScript‚ÌSetMessagePanel‚ğÀs‚·‚é

        messageScript.SetMessagePanel(Conversation);// messageScript‚ÌSetMessagePanel‚ğÀs‚·‚é

    }

    //------------------------------------------------------------------------------------

    //Player‚ğ”­Œ©‚µ‚½
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("”­Œ©‚µ‚½!!");
            if (talk2 == true)
            {
                StartCoroutine("Message", message2);// MessageƒRƒ‹[ƒ`ƒ“‚ğÀs‚·‚é
                messageScript.talkflag = true;
                messageScript.eraseTimeFlag = true;

                talk2 = false;
            }

        }
    }
}
