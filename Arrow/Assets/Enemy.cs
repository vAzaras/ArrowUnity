using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float atackRange = 3f;
    public float followRange = 5f;
    public float atackSpeed = 5f;
    public Transform shootDir;
    private float lastAtack;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(closestPlayerDist() <= atackRange)
        {
            Atack();
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
            transform.LookAt(closestPlayerObj().transform.position);
        }
    }
    private void FollowPlayer()
    {
        
    }
}
