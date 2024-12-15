using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EasterEggDoor : MonoBehaviour
{
    string isUnlocked = "isUnlocked";
    string player = "Player";
    bool enter = false;
    string passcode = "";
    string cheeyung = "CHEEYUNG";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.GetComponent<Animator>().SetBool(isUnlocked, false);
    }

    private void Update()
    {
        if(enter)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                passcode += KeyCode.C.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                passcode += KeyCode.H.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                passcode += KeyCode.E.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                passcode += KeyCode.Y.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                passcode += KeyCode.U.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                passcode += KeyCode.N.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                passcode += KeyCode.G.ToString();
            }

            if(passcode.Equals(cheeyung))
            {
                gameObject.GetComponentInParent<Animator>().SetBool(isUnlocked, true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(player))
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            enter = false;
            passcode = "";
        }
    }
}
