using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sad : MonoBehaviour
{
    public GameObject sadFace;

    void Start()
    {
        StartCoroutine(NextScene(2));
    }
    public void ShowSad()
    {
        sadFace.SetActive(true);
    }

    public void NoSad()
    {
        sadFace.SetActive(false); 
    }

    public IEnumerator NextScene(int level)
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene(level);
    }
}
