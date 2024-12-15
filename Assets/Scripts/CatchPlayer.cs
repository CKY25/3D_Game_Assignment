using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CatchPlayer : MonoBehaviour
{
    public RawImage fade;
    public GameObject cat;
    string isCaught = "isCaught";
    string player = "Player";
    string amogusCollider = "AmogusCollider";
    string view = "ViewDistance";
    string run = "Run";

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
        if(gameObject.name.Equals(amogusCollider) && other.CompareTag(player))
        {
            fade.GetComponent<Animator>().SetBool(isCaught, true);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.transform.parent.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.transform.parent.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.parent.transform.position);
            gameObject.transform.parent.GetComponent<Animator>().enabled = false;
            cat.GetComponent<SC_FPSController>().walkingSpeed = 0;
            cat.GetComponent<SC_FPSController>().runningSpeed = 0;
            cat.GetComponent<SC_FPSController>().jumpSpeed = 0;
            cat.GetComponent<SC_FPSController>().lookSpeed = 0;
            StartCoroutine(tpPlayer(other));
        }
        else if(gameObject.name.Equals(view) && other.CompareTag(player))
        {
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponentInParent<Animator>().SetBool(run, true);
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 5;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name.Equals(amogusCollider) && other.CompareTag(player))
        {
            fade.GetComponent<Animator>().SetBool(isCaught, false);
        }
        else if (gameObject.name.Equals(view) && other.CompareTag(player))
        {
            gameObject.GetComponentInParent<Animator>().SetBool(run, false);
            gameObject.GetComponentInParent<NavMeshAgent>().speed = 1.5f;
        }
    }

    IEnumerator tpPlayer(Collider player)
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.position = new Vector3(-0.777f, 0.6847991f, 21.269f);
        Physics.SyncTransforms();
        gameObject.transform.parent.GetComponent<NavMeshAgent>().isStopped = false;
        gameObject.transform.parent.GetComponent<AmongUsPatrol>().UpdateDestination();
        gameObject.transform.parent.GetComponent<Animator>().enabled = true;
        cat.GetComponent<SC_FPSController>().walkingSpeed = 5.0f;
        cat.GetComponent<SC_FPSController>().runningSpeed = 8.0f;
        cat.GetComponent<SC_FPSController>().jumpSpeed = 5.0f;
        cat.GetComponent<SC_FPSController>().lookSpeed = 2f;
    }
}
