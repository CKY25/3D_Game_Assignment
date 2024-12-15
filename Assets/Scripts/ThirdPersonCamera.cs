using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

    public float turnSpeed = 4.0f;
    public Transform player;

    public float height = 1f;
    public float distance = 2f;

    private Vector3 offsetX;

    void Start()
    {

        offsetX = new Vector3(0, height, distance);
    }

    void LateUpdate()
    {
        if(gameObject.activeSelf)
        {
            offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
            transform.position = player.position + offsetX;
            transform.LookAt(player.position);
        }
        else if(!gameObject.activeSelf)
        {
            gameObject.transform.parent.GetComponent<SC_FPSController>().lookSpeed = 2;
        }
        
    }
}