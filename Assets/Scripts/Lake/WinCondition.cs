using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public int cutscene;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(cutscene);// load
    }
}
