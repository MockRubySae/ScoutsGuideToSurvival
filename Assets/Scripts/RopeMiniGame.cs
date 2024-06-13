using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeMiniGame : MonoBehaviour
{

    public List<GameObject> green = new List<GameObject>();
    public List<GameObject> red = new List<GameObject>();
    List<GameObject> tempGreen = new List<GameObject>();
    List<GameObject> tempRed = new List<GameObject>();

    public GameObject gameUI;
    public bool isStarting = false;

    private void Start()
    {
        isStarting = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStarting)
        {
            Game();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 0f;
        for (int i = 0; i < green.Count; i++)
        {
            tempGreen.Add(green[i]);
        }
        for (int i = 0; i < red.Count; i++)
        {
            tempRed.Add(red[i]);
        }
        for(int i = 0;i < tempRed.Count; i++)
        {
            red[i].gameObject.SetActive(true);  
        }
        isStarting = true;
    }

    public void Game()
    {
        if(tempGreen.Count > 0)
        {
            int random = Random.Range(0, tempGreen.Count);
            tempGreen[random].SetActive(true);
            tempRed[random].SetActive(false);
            tempGreen.Remove(tempGreen[random]);
            tempRed.Remove(tempRed[random]);
            isStarting = false;
        }
        else
        {
            Time.timeScale = 1f;
            gameUI.SetActive(false);
            isStarting = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartGame();
            gameUI.SetActive(true);
        }
    }
}
