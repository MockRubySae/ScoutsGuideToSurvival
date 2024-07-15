using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Vector3 destination;
    Camera m_Camera;
    public bool canMove = true;

    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.touchCount > 0) // Check if there is at least one touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch input

            Vector3 touchPos = touch.position;
            touchPos.z = 10f;
            touchPos = m_Camera.ScreenToWorldPoint(touchPos);
            Debug.DrawRay(transform.position, touchPos - transform.position, Color.cyan);

            if (touch.phase == TouchPhase.Began && canMove) // Check if the touch has just started
            {
                Ray ray = m_Camera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, ground))
                {
                    destination = hit.point;
                    // Debug.Log(hit.point);
                }
            }
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            mousePos = m_Camera.ScreenToWorldPoint(mousePos);
            Debug.DrawRay(transform.position, mousePos - transform.position, Color.cyan);

            if (Input.GetMouseButton(0) && canMove)
            {
                Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, ground))
                {
                    destination = hit.point;
                    //  Debug.Log(hit.point);
                }
            }
        }
    }
}
