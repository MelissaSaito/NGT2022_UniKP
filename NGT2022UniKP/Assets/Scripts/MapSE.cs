using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSE : MonoBehaviour
{
    GameObject player;
    MapScript mapSc;
    private int push;
    private bool get = false;
    public AudioClip sound1, sound2, itemGet;
    AudioSource audioSource;


    void Start()
    {
        //Component‚ðŽæ“¾
        player = GameObject.Find("Player");
        mapSc = player.GetComponent<MapScript>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(mapSc.mapFunction == true && get == false)
        {
            audioSource.PlayOneShot(itemGet);
            get = true;
        }

        if (mapSc.mapFunction == true && Input.GetButtonDown("ControllerY"))
        {
            push++;
            if (push % 2 == 0)
                audioSource.PlayOneShot(sound1);

            else
                audioSource.PlayOneShot(sound2);


        }
    }
}
