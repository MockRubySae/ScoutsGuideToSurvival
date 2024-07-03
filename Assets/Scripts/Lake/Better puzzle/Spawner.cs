using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pieces;
    public RayCast move;
    public Camera cam;
    public FollowPlayer followPlayer;
    bool hasTrigered = false;

    public void OnTriggerEnter(Collider other)
    {
        if (!hasTrigered)
        {
            move.enabled = false;
            followPlayer.enabled = false;
            for (int i = 0; i < 30; i++)
            {
                float x = Random.Range(109.0f, 90.0f);
                float z = Random.Range(5.0f, 10f);
                Vector3 temp = new Vector3(x, 0.25f, z);
                GameObject instantiatedUI = Instantiate(pieces[i], temp, Quaternion.identity);
            }
            cam.transform.position = new Vector3(100, 10, 10);
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x - 32.652f + 90, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            hasTrigered = true;
        }
      
    }
}
