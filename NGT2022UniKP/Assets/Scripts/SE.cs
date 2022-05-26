using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if ()
        //{
        //    //‰¹(sound1)‚ð–Â‚ç‚·
        //    audioSource.PlayOneShot(sound1);
        //}
    }
}