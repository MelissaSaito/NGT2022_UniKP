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
        Debug.Log("押されました");

        GameObject obj = GameObject.Find("ShortcutObject");
        obj.SetActive(false);
    }
}