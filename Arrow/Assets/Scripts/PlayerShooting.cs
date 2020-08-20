using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulet;
    public Transform shootDir;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject shoot = Instantiate
                (
                    bulet,
                    transform.position,
                    Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f,0f,90f))
                );
            Destroy(shoot, 2f);
        }
    }
}
