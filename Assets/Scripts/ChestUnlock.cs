using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUnlock : MonoBehaviour
{
    public GameObject powercell;
    string isUnlocked = "isUnlocked";
    string key = "Key";
    string chest = "Chest";

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<Animator>().SetBool(isUnlocked, false);
        if(gameObject.transform.parent.name.Equals(chest))
        {
            powercell.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(key))
        {
            Destroy(other.gameObject);
            GetComponentInParent<Animator>().SetBool(isUnlocked, true);
            if (gameObject.transform.parent.name.Equals(chest))
            {
                StartCoroutine(wait());
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.35f);
        powercell.transform.GetChild(0).gameObject.SetActive(true);
    }
}
