using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public RopeMiniGame check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if (check.green.Contains(gameObject))
        {
            check.isStarting = true;
            gameObject.SetActive(false);
        }
    }
}
