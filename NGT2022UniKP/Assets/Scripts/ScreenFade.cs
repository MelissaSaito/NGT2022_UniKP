using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScreenFade : MonoBehaviour
{
    public Button btnA;
    public Button btnB;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        btnA.onClick.AddListener(LoadScreenA);
        btnB.onClick.AddListener(LoadScreenB);

    }

    private void LoadScreenA()
    {
        StartCoroutine(LoadScene(1));
    }

    private void LoadScreenB()
    {
        StartCoroutine(LoadScene(2));
    }

    IEnumerator LoadScene(int index)
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
