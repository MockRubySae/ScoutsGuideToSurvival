using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FireMiniGame : MonoBehaviour
{
    public GameObject fireUI;
    public Sticks stick;
    bool aTurn = true;
    bool dTurn = false;
    bool start = false;
    float score = 0;
    public Image image;
    public bool complete = false;
    public Animator animator;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            fireUI.SetActive(true);
            animator.SetBool("crouching", true);
            MiniGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(stick.numOfSticksCollected == 3)
            {
                start = true;
                agent.speed = 0;
            }
        }
    }
    void MiniGame()
    {
        if(Input.GetKeyDown(KeyCode.A) && aTurn) 
        {
            score = score + 5;
            image.fillAmount = score/100;
            dTurn = true;
            aTurn = false;
        }
        else if(Input.GetKeyDown(KeyCode.D) && dTurn)
        {
            score = score + 5;
            image.fillAmount = score/100;
            dTurn = false;
            aTurn = true;
        }

        if(score >= 100)
        {
            start = false;
            fireUI.SetActive(false);
            complete = true;
            agent.speed = 6;
            animator.SetBool("crouching", false);
        }
        else if(score < 100 && score > 0)
        {
            score = score - 0.1f;
            image.fillAmount = score / 100;
        }
    }
}
