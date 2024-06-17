using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToMouse : MonoBehaviour
{
    public NavMeshAgent agent;
    public RayCast go;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(go.destination);
        }
        
    }
}
