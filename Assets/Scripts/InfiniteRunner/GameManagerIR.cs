using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerIR : MonoBehaviour
{

    public static GameManagerIR MyInstance;

    public LakePlayerMovement playerMovement;

    public GameObject RetryPanel;

    public GameObject WinPanel;

    public Text timerSeconds;

    public float gameTimer;



    private void Awake()
    {
        MyInstance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        
        gameTimer = 10f;
        RetryPanel.SetActive(false);
        WinPanel.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        WinCondition();
       
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void WinCondition()
    {
        if (playerMovement.alive == true && gameTimer <= 0)
        {
            Debug.Log("Win");
            WinPanel.SetActive (true);
           
            SceneManager.LoadScene(5);
        }

    }
}
