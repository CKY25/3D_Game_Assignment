using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public static AsyncOperation ao;

    private void Start()
    {
        ao = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
    }

    public void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return null;
        ao.allowSceneActivation = true;
    }
}
