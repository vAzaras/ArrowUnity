using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulet;
    public Transform shootDir;
    private Camera cam;
    public Vector3 offset = new Vector3(0, 0, -10);
    private Rigidbody2D rb2d;
    public float speed = 2f;
    public float maxSpeed = 5f;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        CameraFollow();
        LookAtMouse();
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject shoot = Instantiate
            (
                bulet,
                transform.position,
                Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, 90f))
            );
        Destroy(shoot, 2f);
    }
    void CameraFollow()
    {
        cam.transform.position = transform.position + offset;
    }
    void LookAtMouse()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        Vector2 mov = new Vector2(x, y);

        rb2d.AddForce(mov);

        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }
}
