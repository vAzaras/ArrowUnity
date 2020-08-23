﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMenu : MonoBehaviour
{
    private Camera cam;
    private float heightCam;
    private float widthCam;
    private float speed;

    void Start()
    {
        cam = Camera.main;
        speed = Random.Range(2, 5);
    }

    void Update()
    {
        heightCam = cam.pixelHeight;
        transform.Translate(0f, -speed * Time.deltaTime, 0f);

    }
}
