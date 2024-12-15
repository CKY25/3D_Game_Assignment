using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject cat;
    bool paused = false;
    public AudioClip meow;

    public static AsyncOperation ao;

    private void Start()
    {
        pauseMenu.SetActive(false);
        ao = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
    }
    IEnumerator Wait()
    {
        yield return null;
        ao.allowSceneActivation = true;
        paused = false;
        cat.GetComponent<SC_FPSController>().lookSpeed = 2;

    }

    void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = meow;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && cat.activeSelf)
        {
            if (paused == false)
            {
                Time.timeScale = 0.0f;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cat.GetComponent<SC_FPSController>().lookSpeed = 0;
                paused = true;

            }
            else if (paused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cat.GetComponent<SC_FPSController>().lookSpeed = 2;
                paused = false;
            }
        }

    }

    public void Return()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cat.GetComponent<SC_FPSController>().lookSpeed = 2;
        paused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1.0f;
        playBtnSound();
        StartCoroutine(Wait());
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
