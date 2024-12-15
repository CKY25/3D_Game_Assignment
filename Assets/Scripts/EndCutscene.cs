using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public GameObject endCamera;
    public GameObject player;
    string playerTag = "Player";

    private void Start()
    {
        endCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerTag))
        {
            player.SetActive(false);
            endCamera.SetActive(true);
        }
    }
}
