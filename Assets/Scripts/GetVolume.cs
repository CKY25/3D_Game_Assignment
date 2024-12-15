using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GetVolume : MonoBehaviour
{
    string sceneName = "MainLevel";
    string bgmObject = "PauseScript/and backgroud music";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, SoundManager.volume);

        if(SceneManager.GetActiveScene().name.Equals(sceneName))
        {
            GameObject.Find(bgmObject).GetComponent<AudioSource>().mute = true;
        }
    }

}
