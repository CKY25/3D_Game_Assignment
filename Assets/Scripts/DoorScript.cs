using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    string player = "Player";
    string isOpen = "isOpen";
    string speed = "Speed";
    string door1 = "DoorTrigger";
    string door2 = "Door2Trigger";
    string door2Anim = "Door2OpenClose";
    string isUnlocked = "isUnlocked";

    private void Start()
    {
        animator.SetBool(isOpen, false);
        animator.SetBool(isUnlocked, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player))
        {
            if(gameObject.name.Equals(door1))
            {
                if(animator.GetBool(isUnlocked))
                {
                    animator.SetBool(isOpen, true);
                }
            }

            else if (gameObject.name.Equals(door2))
            {
                if (animator.GetBool(isUnlocked))
                {
                    animator.SetFloat(speed, 2);
                    animator.Play(door2Anim, 0, 0.25f);
                }
            }
        }

    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(player))
        {
            if (gameObject.name.Equals(door1))
            {
                animator.SetBool(isOpen, false);
            }

            else if (gameObject.name.Equals(door2))
            {
                animator.SetFloat(speed, -2);
                animator.Play(door2Anim);
            }
        }
    }
}
