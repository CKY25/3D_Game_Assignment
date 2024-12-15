using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    public bool hasItem; // a bool to see if you have an item in your hand

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public RawImage interactUI;
    string iObject = "InteractableObject";
    string obj = "Object";
    string powercell = "Powercell";
    string keyTag = "Key";
    string key2 = "Item_Key2 (1)";
    string mouseX = "Mouse X";
    string mouseY = "Mouse Y";
    float h;
    float v;

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
        interactUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKeyDown(KeyCode.E) && hasItem == false && ObjectIwantToPickUp != null)  // can be e or any key
            {
                if(ObjectIwantToPickUp.name.Equals(key2))
                {
                    if (ObjectIwantToPickUp.GetComponent<Rigidbody>() == null)
                    {
                        ObjectIwantToPickUp.AddComponent<Rigidbody>();
                    }     
                }

                ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                ObjectIwantToPickUp.transform.position = gameObject.transform.GetChild(2).position;

                if(ObjectIwantToPickUp.CompareTag(obj))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                    //ObjectIwantToPickUp.transform.GetChild(2).localScale = new Vector3(0.02f, 0.02f, 0.02f);
                }
                else if (ObjectIwantToPickUp.CompareTag(powercell))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(3f, 3f, 3f);
                }
                else if (ObjectIwantToPickUp.CompareTag(keyTag))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }

                ObjectIwantToPickUp.transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(10, 10, 10);
                ObjectIwantToPickUp.transform.parent = gameObject.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && hasItem == true && !Input.GetMouseButton(1) && ObjectIwantToPickUp != null && gameObject.GetComponent<SC_FPSController>().moveDirection.x == 0) // if you have an item and get the key to remove the object, again can be any key
            {
                ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again

                ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands

                if (ObjectIwantToPickUp.CompareTag(obj))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                else if( ObjectIwantToPickUp.CompareTag(powercell))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(30f, 30f, 30f);
                }
                else if (ObjectIwantToPickUp.CompareTag(keyTag))
                {
                    ObjectIwantToPickUp.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                ObjectIwantToPickUp.transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(3, 3, 3);
                ObjectIwantToPickUp = null;
                hasItem = false;
            }
        }

        if (Input.GetMouseButton(1) && hasItem == true)
        {
            h = horizontalSpeed * Input.GetAxis(mouseX);
            v = verticalSpeed * Input.GetAxis(mouseY);

            gameObject.GetComponent<SC_FPSController>().lookSpeed = 0;
            
            ObjectIwantToPickUp.transform.RotateAround(ObjectIwantToPickUp.transform.position, Vector3.up, h);
            ObjectIwantToPickUp.transform.RotateAround(ObjectIwantToPickUp.transform.position, Vector3.right, v);
        }
        else if(hasItem)
        {
            gameObject.GetComponent<SC_FPSController>().lookSpeed = 2;
        }

        if(ObjectIwantToPickUp.IsDestroyed())
        {
            hasItem = false;
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.tag == iObject) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject.transform.parent.gameObject; //set the gameobject you collided with to one you can reference
            
            if(!hasItem)
            {
                interactUI.enabled = true;
            }
            else
            {
                interactUI.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
        interactUI.enabled = false;
    }
}