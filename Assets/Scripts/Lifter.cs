using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifter : MonoBehaviour
{
    public GameObject lifter;
    public GameObject specimenDoor;
    public RawImage interactUI;
    public Material[] materials;
    bool entered;
    bool isDown;
    string player = "Player";
    string down = "Down";
    string isUnlocked = "isUnlocked";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(specimenDoor.GetComponent<Animator>().GetBool(isUnlocked))
        {
            if (entered)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isDown = lifter.GetComponent<Animator>().GetBool(down);
                    if (isDown)
                    {
                        lifter.GetComponent<Animator>().SetBool(down, false);
                        gameObject.transform.parent.GetChild(2).GetComponent<MeshRenderer>().material = materials[0];
                    }
                    else
                    {
                        lifter.GetComponent<Animator>().SetBool(down, true);
                        gameObject.transform.parent.GetChild(2).GetComponent<MeshRenderer>().material = materials[1];
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(player))
        {
            if (specimenDoor.GetComponent<Animator>().GetBool(isUnlocked))
            {
                interactUI.enabled = true;
                entered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactUI.enabled = false;
        entered = false;
    }
}
