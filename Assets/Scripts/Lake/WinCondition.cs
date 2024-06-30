using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public RayCast rayCastScript;
    // Start is called before the first frame update
    void Start()
    {
        rayCastScript = FindObjectOfType<RayCast>();
        rayCastScript.canMove = true;
    }
    public void winCondition()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SceneManager.LoadScene(cutscene);// load
    
}
