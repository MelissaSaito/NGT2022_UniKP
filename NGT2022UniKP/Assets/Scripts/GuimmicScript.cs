using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuimmicScript : MonoBehaviour
{
    [SerializeField] GameObject shortCut;
    GameObject player;

    private int count1,count2, count3, count4, count5, count6, count7, count8, count9;
    private bool use1, use2, use3, use4, use5, use6, use7, use8, use9;

    [SerializeField] bool startShortCut;

    MapScript playerMapScript;

    bool hadMap;

    public AudioClip sound1;
    public AudioClip close;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        shortCut.SetActive(false);
        
        startShortCut = false;
        player = GameObject.Find("Player");

        playerMapScript = player.GetComponent<MapScript>();

        hadMap = false;

        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("ControllerA") && startShortCut == true)
        {
            

            ButtonClick1();
        }

        if (Input.GetButtonDown("ControllerLTrigger") && startShortCut == true)
        {
            ButtonClick2();
        }

        if (Input.GetButtonDown("Back") && startShortCut == true)
        {
            ButtonClick3();
        }

        if (Input.GetButtonDown("ControllerY") && startShortCut == true)
        {
            if (playerMapScript.mapImage.enabled == true)
            {
                return;
            }
            ButtonClick5();
        }

        if (Input.GetButtonDown("ControllerX") && startShortCut == true)
        {
            ButtonClick7();
        }

        if (Input.GetButtonDown("ControllerB") && startShortCut == true)
        {
            ButtonClick8();
        }

        if (Input.GetButtonDown("Enter") && startShortCut == true)
        {
            ButtonClick9();
        }

        Open();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�M�~�b�N�g�p��");
        shortCut.SetActive(true);
        startShortCut = true;

        if (playerMapScript.mapFunction == true)
        {
            playerMapScript.mapFunction = false;
            playerMapScript.mapImage.enabled = false;
            hadMap = true;
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        shortCut.SetActive(false);
        startShortCut = false;
        
        if(hadMap == true)
        {
            playerMapScript.mapFunction = true;
        }
        
    }


    public void ButtonClick1()
    {
        GameObject button1 = GameObject.Find("Shortcut1");
        count1++;
        if(count1 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button1.GetComponent<Image>().color = Color.white;
            use1 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button1.GetComponent<Image>().color = Color.black;
            use1 = true;
        }
            
    }

    public void ButtonClick2()
    {
        GameObject button2 = GameObject.Find("Shortcut2");
        count2++;
        if (count2 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button2.GetComponent<Image>().color = Color.white;
            use2 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button2.GetComponent<Image>().color = Color.black;
            use2 = true;
        }
            
    }

    public void ButtonClick3()
    {
        GameObject button3 = GameObject.Find("Shortcut3");
        count3++;
        if (count3 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button3.GetComponent<Image>().color = Color.white;
            use3 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button3.GetComponent<Image>().color = Color.black;
            use3 = true;
        }
            
    }

    public void ButtonClick4()
    {
        GameObject button4 = GameObject.Find("Shortcut4");
        count4++;
        if (count4 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button4.GetComponent<Image>().color = Color.white;
            use4 = false;
        } 
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button4.GetComponent<Image>().color = Color.black;
            use4 = true;
        }
           
    }

    public void ButtonClick5()
    {
        GameObject button5 = GameObject.Find("Shortcut5");
        count5++;
        if (count5 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button5.GetComponent<Image>().color = Color.white;
            use5 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button5.GetComponent<Image>().color = Color.black;
            use5 = true;
        }
           
    }

    public void ButtonClick6()
    {
        GameObject button6 = GameObject.Find("Shortcut6");
        count6++;
        if (count6 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button6.GetComponent<Image>().color = Color.white;
            use6 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button6.GetComponent<Image>().color = Color.black;
            use6 = true;
        }
           
    }

    public void ButtonClick7()
    {
        GameObject button7 = GameObject.Find("Shortcut7");
        count7++;
        if (count7 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button7.GetComponent<Image>().color = Color.white;
            use7 = false;
        }
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button7.GetComponent<Image>().color = Color.black;
            use7 = true;
        }
            
    }

    public void ButtonClick8()
    {
        GameObject button8 = GameObject.Find("Shortcut8");
        count8++;
        if (count8 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button8.GetComponent<Image>().color = Color.white;
            use8 = false;
        }   
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button8.GetComponent<Image>().color = Color.black;
            use8 = true;
        }
            
    }

    public void ButtonClick9()
    {
        GameObject button9 = GameObject.Find("Shortcut9");
        count9++;
        if (count9 % 2 == 0)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button9.GetComponent<Image>().color = Color.white;
            use9 = false;
        }           
        else
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);
            button9.GetComponent<Image>().color = Color.black;
            use9 = true;
        }
           
    }

    void Open()
    {
        if (use1 == true && use2 == true && use3 == true && use4 == false && use5 == true && use6 == false && use7 == true && use8 == true && use9 == true)
        {
            GameObject fence = GameObject.Find("fence");
            GameObject gimmick = GameObject.Find("gimmick");
            GameObject shortcutButton = GameObject.Find("Shortcut");
            fence.SetActive(false);
            gimmick.SetActive(false);
            shortcutButton.SetActive(false);
            use1 = false;
            ////��(close)��炷
            //audioSource.PlayOneShot(close);
        }
    }
}
