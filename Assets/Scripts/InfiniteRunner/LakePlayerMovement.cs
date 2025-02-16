
using UnityEngine;
using UnityEngine.SceneManagement;

public class LakePlayerMovement : MonoBehaviour
{

    public GameManagerIR gameManager;

public bool alive = true;
public float speed = 12;
public Rigidbody rb;

float horizontalInput;
public float horizontalMulti = 1.5f;

public void FixedUpdate()
{
    if (!alive) return;


    Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
    Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMulti;
    rb.MovePosition(rb.position + forwardMove + horizontalMove);

    
}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Moved)
            {
                horizontalInput = touch.deltaPosition.x;
            }
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }

    public void Dead ()
    {
        alive = false;
        Invoke("Restart", 2);
        GameManagerIR.MyInstance.RetryPanel.SetActive(true);
        
    }

    void Restart()
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
