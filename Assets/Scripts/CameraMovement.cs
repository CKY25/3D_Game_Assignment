using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public int rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(x: 0, y: 1, z: 0), rotationSpeed * Time.deltaTime);
    }
}
