using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    AsyncOperation ao;

    private void OnEnable()
    {
        ao = PauseScript.ao;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return null;
        ao.allowSceneActivation = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
