using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject teleporter;
    string player = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(player))
        {
            other.transform.position = teleporter.transform.position;
            other.transform.rotation = teleporter.transform.rotation;
            Physics.SyncTransforms();
        }
    }
}
