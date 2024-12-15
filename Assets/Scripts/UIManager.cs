using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class UiManager : MonoBehaviour
{
    private string levelToLoad;
    public AudioClip meow;
    AsyncOperation ao;

    //Screen Game Objects
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject instructionMenu;
    public string SceneNameToLoad;

    //Material
    public Material material0;
    public Material material1;
    public Material material2;
    public Material material3;
    public static Material changeMaterial;
    public GameObject Object;


    private void Start()
    {
        changeMaterial = material0;
        settingMenu.SetActive(false);
        instructionMenu.SetActive(false);
        ao = SceneManager.LoadSceneAsync(SceneNameToLoad, LoadSceneMode.Single);
        ao.allowSceneActivation = false;

    }
    void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = meow;
        audio.Play();
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

    public void PlayBtnClicked()
    {
        levelToLoad = SceneNameToLoad;
        playBtnSound();
        StartCoroutine(Wait());
    }

    public void SkinUpBtn()
    {
        if(changeMaterial == material0)
        {
            changeMaterial = material1;
        }
        else if(changeMaterial == material1)
        {
            changeMaterial = material2;
        }
        else if (changeMaterial == material2)
        {
            changeMaterial = material3;
        }
        else if(changeMaterial == material3)
        {
            changeMaterial = material0;
        }



         Object.GetComponent<Renderer>().material = changeMaterial;
    }

    public void SkinDownBtn()
    {
        if(changeMaterial == material3)
        {
            changeMaterial = material2;
        }
        else if(changeMaterial == material2)
        {
            changeMaterial = material1;
        }
        else if(changeMaterial == material1)
        {
            changeMaterial = material0;
        }
        else if (changeMaterial == material0)
        {
            changeMaterial = material3;
        }

        Object.GetComponent<Renderer>().material = changeMaterial;
    }

    public void ActivateSetting()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
        playBtnSound();
    }

    public void Return()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
        instructionMenu.SetActive(false);
        playBtnSound();
    }
    public void Insturction()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(false);
        instructionMenu.SetActive(true);
        playBtnSound();
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
