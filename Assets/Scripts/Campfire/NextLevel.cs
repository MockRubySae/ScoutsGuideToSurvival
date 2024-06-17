using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int level;

    public FireMiniGame fireMini;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fireMini.complete)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
