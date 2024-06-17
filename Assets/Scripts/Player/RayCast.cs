using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Vector3 destination;
    Camera m_Camera;

    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = m_Camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.cyan);

        if (Input.GetMouseButton(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ground))
            {
                destination = hit.point;
                Debug.Log(hit.point);
            }
        }
    }
}
