using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sticks : MonoBehaviour
{
    public int numOfSticksCollected = 0;
    public int numOfSticks = 3;

    public GameObject indicator;
    public MoveToMouse move;

    public Animator animator;

    public TextMeshProUGUI charDialog;
    public GameObject charPanel;

    bool destroyStick = false;
    public void CollectStick()
    {
        if (numOfSticksCollected >= 3)
        {
            StartCoroutine(SticksComplete());
        }
        else
        {
            numOfSticksCollected++;
            move.agent.speed = 0;
            animator.SetBool("pickup", true);
            indicator.SetActive(true);
            StartCoroutine(ControlDesableTime());
        }
    }

    IEnumerator SticksComplete()
    {
        charPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        charDialog.text = "I don't need any more kindling...";
        yield return new WaitForSeconds(5f);
        charDialog.text = "";
        charPanel.SetActive(false);
    }


    IEnumerator ControlDesableTime()
    {
        yield return new WaitForSeconds(3);
        move.agent.speed = 6;
        animator.SetBool("pickup", false);
        indicator.SetActive(false);
        destroyStick = true;
        if (numOfSticksCollected >= 3)
        {
            charPanel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            charDialog.text = "I think I have enough kindling...";
            yield return new WaitForSeconds(5f);
            charDialog.text = "";
            charPanel.SetActive(false);
        }
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
