using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LoadSpecificScene : MonoBehaviour
{

    public string sceneName;
    public Animator fadeSystem;

    void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            loadNextScene();
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

}
