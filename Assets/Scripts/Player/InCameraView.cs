using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraView : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustrum;
    Collider col;

    public bool inCamera;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = col.bounds;
        cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds))
        {
            RaycastHit raycastHit;
            Physics.Raycast(cam.transform.position, (col.transform.position - cam.transform.position).normalized, out raycastHit);
            if (raycastHit.collider == col)
            {
                inCamera = true;
            }
            else
            {
                inCamera = false;
            }
        }
        else
        {
            inCamera = false;
        }
    }
}
