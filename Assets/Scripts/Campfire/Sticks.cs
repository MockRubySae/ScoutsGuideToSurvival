using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    public int numOfSticksCollected = 0;
    public int numOfSticks = 3;

    public GameObject indicator;
    public MoveToMouse move;

    public Animator animator;

    bool destroyStick = false;
    public void CollectStick()
    {
        numOfSticksCollected++;
        move.agent.speed = 0;
        animator.SetBool("pickup", true);
        indicator.SetActive(true);
        StartCoroutine(ControlDesableTime());
    }
    
    IEnumerator ControlDesableTime()
    {
        yield return new WaitForSeconds(3);
        move.agent.speed = 6;
        animator.SetBool("pickup", false);
        indicator.SetActive(false);
        destroyStick = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stick"))
        {
            CollectStick();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if( destroyStick && other.CompareTag("Stick"))
        {
            other.gameObject.SetActive(false);
            destroyStick = false;
        }
    }
}
