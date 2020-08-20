using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset = new Vector3(0,0,-10);

    void Start()
    {

    }

    void Update()
    {
        cam.transform.position = transform.position + offset;
    }
}
