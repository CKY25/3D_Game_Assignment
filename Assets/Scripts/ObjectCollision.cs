using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public GameObject spawn;
    public GameObject obj;
    string untag = "Untagged";
    string ob = "Object";
    string powercell = "Powercell";
    bool instantiated = false;

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
        if(other.gameObject.tag == untag)
        {
            obj.transform.parent = null;
            obj.GetComponent<Rigidbody>().isKinematic = false;
            if(obj.tag == ob)
            {
                obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if(obj.tag == powercell)
            {
                obj.transform.localScale = new Vector3(30f, 30f, 30f);
            }
            
            obj.transform.GetChild(0).GetComponent<BoxCollider>().size = new Vector3(3, 3, 3);
            Destroy(obj);
            if(!instantiated)
            {
                Transform newCube = Instantiate(obj.transform, Random.insideUnitSphere + spawn.transform.position, spawn.transform.rotation);
                if(newCube.position.y <= -2)
                {
                    Destroy(newCube);
                    Instantiate(obj.transform, Random.insideUnitSphere + spawn.transform.position, spawn.transform.rotation);
                }
                instantiated = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instantiated = false;
    }
}
