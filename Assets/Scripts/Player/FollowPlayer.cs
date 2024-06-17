using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5f, -10f);
    private Vector3 vel = Vector3.zero;

    private float smoothTime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position + offset;
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, playerPos, ref vel, smoothTime);
    }
}
