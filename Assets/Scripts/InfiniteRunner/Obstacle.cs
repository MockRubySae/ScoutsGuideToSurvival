using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    LakePlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<LakePlayerMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
if (collision.gameObject.name == "PlayerLakeGame")
{
    playerMovement.Dead();
}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
