using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryActivateDoor : MonoBehaviour
{
    string powercell = "Powercell";
    string isUnlocked = "isUnlocked";
    public GameObject Door;
    public GameObject pointlight;
    public static int batteryRecovered;

    // Start is called before the first frame update
    void Start()
    {
        batteryRecovered = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == powercell)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            pointlight.GetComponent<Light>().color = Color.cyan;
            batteryRecovered++;
        }

        if (batteryRecovered == 3)
        {
            Door.GetComponent<Animator>().SetBool(isUnlocked, true);
        }
    }
}
