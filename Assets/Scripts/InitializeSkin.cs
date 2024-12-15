using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeSkin : MonoBehaviour
{
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        Object.GetComponent<Renderer>().material = UiManager.changeMaterial;
    }

}
