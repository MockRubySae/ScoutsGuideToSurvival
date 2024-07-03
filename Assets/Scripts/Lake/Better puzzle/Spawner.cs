using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pieces;
    public RayCast move;

    public void OnTriggerEnter(Collider other)
    {
        move.enabled = false;
       
            for (int i = 0; i < 30; i++)
            {
                float x = Random.Range(-10.0f, 10.0f);
                float z = Random.Range(-10.0f, 10f);
                Vector3 temp = new Vector3(x, 0.25f, z);
                GameObject instantiatedUI = Instantiate(pieces[i], temp, Quaternion.identity);
            }
       
    }
}
