using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static float volume;
    string musicVol = "musicVolume";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.parent.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey(musicVol))
        {
            PlayerPrefs.SetFloat(musicVol, 0.5f);
            volumeSlider.value = 0.5f;
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(musicVol);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(musicVol, volumeSlider.value);
        volume = volumeSlider.value;
    }
}
