using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene2 : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(Load());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Load()
    {
        yield return new WaitForSecondsRealtime(15);
        SceneManager.LoadScene(scene);
    }
}
