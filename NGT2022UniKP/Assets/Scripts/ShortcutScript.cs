using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutScript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick()
    {
        Debug.Log("‰Ÿ‚³‚ê‚Ü‚µ‚½");

        GameObject obj = GameObject.Find("ShortcutObject");
        obj.SetActive(false);
    }
}