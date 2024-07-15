using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerIR : MonoBehaviour
{

    public static GameManagerIR MyInstance;

    public LakePlayerMovement playerMovement;

    public GameObject RetryPanel;

    public GameObject WinPanel;

    public TextMeshProUGUI timer;

    public float gameTimer;

    public bool loadScene = false;

    public int scene;



    private void Awake()
    {
        MyInstance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        
        gameTimer = 60f;
        RetryPanel.SetActive(false);
        WinPanel.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        WinCondition();
        timer.text = gameTimer.ToString("0");
        if(loadScene)
        {
            StartCoroutine(LoadFinalCutscene());
        }
       
        
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
            loadScene = true;
            Time.timeScale = 0;
            WinPanel.SetActive (true);
        }

    }


    IEnumerator LoadFinalCutscene()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
    }
}
