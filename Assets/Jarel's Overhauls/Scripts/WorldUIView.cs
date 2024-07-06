using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// This is to keep world UI canvas elements fixed to the camera view
/// </summary>
public class WorldUIView : MonoBehaviour
{
    public Transform mainCam;
    void Start()
    {
    }

    void Update()
    {
        transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward,
                         mainCam.transform.rotation * Vector3.up);
    }
}
