using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;

    void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0f, 0f);
    }
}
