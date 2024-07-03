using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToMouse : MonoBehaviour
{
    public NavMeshAgent agent;
    public RayCast go;
    [SerializeField] bool moving;
    [SerializeField] Vector3 lastPos;
    Transform myTransform;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myTransform = transform;
        lastPos = myTransform.position;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(go.destination);
        }
        if (myTransform.position != lastPos)
        {
            moving = true;
            animator.SetBool("walking", true);
        }

        else 
        { 
            moving = false;
            animator.SetBool("walking", false);
        }
        lastPos = myTransform.position;

    }
}
