using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RaftMovement : MonoBehaviour
{
    public float moveSpeed;
    public float mouseSensitivity = 100f;
    public GameObject playerCamera;
    private Rigidbody rb;
    private float xRotation = 0f;
    public GameObject mainCam;

    private NavMeshAgent agent;
    public MoveToMouse moveTo;
    public RopeMiniGame rope;

    public GameObject raft;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rope.isRaymondFinished == true)
        {
            agent.enabled = false;
            moveTo.enabled = false;
            mainCam.SetActive(false);
            playerCamera.SetActive(true);
            raft.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen

            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            // Get input from the horizontal and vertical axes
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = 1f;

            // Create a new vector for movement
            Vector3 move = new Vector3(moveX, 0, moveY);

            MovePlayer(move);
            RotatePlayer();
        }
   
    }
    private void MovePlayer(Vector3 move)
    {
        // Transform the movement vector from local space to world space
        Vector3 moveDirection = transform.TransformDirection(move).normalized;

        // Calculate the movement velocity
        Vector3 velocity = moveDirection * moveSpeed;

        // Set the Rigidbody's velocity
        rb.AddForce(velocity, ForceMode.Force);
    }
    private void RotatePlayer()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera around the x-axis
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation to avoid flipping

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player around the y-axis
        transform.Rotate(Vector3.up * mouseX);
    }
}
