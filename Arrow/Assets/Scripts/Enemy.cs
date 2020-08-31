using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float atackRange = 3f;
    public float followRange = 5f;
    public float atackSpeed = 5f;
    public float movSpeed = 3f;
    public float randomMoveTime = 2f;
    public Transform shootDir;
    private float lastAtack;
    private float lastRandomMove = 0f;
    private int randomMoveNum;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(closestPlayerDist() <= followRange)
        {
            FollowPlayer();
            if(closestPlayerDist() <= atackRange)
            {
                Atack();
            }
        }
        else
        {
            RandomMove();
        }
    }

    private GameObject closestPlayerObj()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closestDist = Mathf.Infinity;
        GameObject closestPlayer = null;
        foreach(GameObject player in players)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist < closestDist)
            {
                closestDist = dist;
                closestPlayer = player;
            }
        }
        return closestPlayer;
    }
    private float closestPlayerDist()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closestDist = Mathf.Infinity;
        GameObject closestPlayer = null;
        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestPlayer = player;
            }
        }
        return closestDist;
    }
    private void Atack()
    {
        if(Time.time - lastAtack > 1 / atackSpeed)
        {
            lastAtack = Time.time;
        }
    }
    private void FollowPlayer()
    {
        Vector3 diff = closestPlayerObj().GetComponent<Transform>().position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    private void RandomMove()
    {
        if(Time.time - lastRandomMove >= randomMoveTime)
        {
            randomMoveNum = Random.Range(1, 4);
            lastRandomMove = Time.time;
        }
        switch (randomMoveNum)
        {
            //Up
            case 1:
                if(transform.rotation.z != 0f)
                {
                    transform.Rotate(0f, 0f, 0f);
                }
                transform.Translate(Vector2.up * movSpeed * Time.deltaTime);
                break;
            //Down
            case 2:
                if (transform.rotation.z != 180f)
                {
                    transform.Rotate(0f, 0f, 180f);
                }
                transform.Translate(-Vector2.up * movSpeed * Time.deltaTime);
                break;
            //Left
            case 3:
                if (transform.rotation.z != 90f)
                {
                    transform.Rotate(0f, 0f, 90f);
                }
                transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
                break;
            //Right
            case 4:
                if (transform.rotation.z != 270f)
                {
                    transform.Rotate(0f, 0f, 270f);
                }
                transform.Translate(-Vector2.right * movSpeed * Time.deltaTime);
                break;
            default:

                break;
        }
    }
}
