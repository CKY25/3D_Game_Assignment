using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScript : MonoBehaviour
{
    public string sceneToLoad;
    AsyncOperation ao;

    public void LoadScene()
    {
        ao = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        while (!ao.isDone)
        {
            if (ao.progress >= 0.9f)
                ao.allowSceneActivation = true;
            yield return null;
        }
    }
}
