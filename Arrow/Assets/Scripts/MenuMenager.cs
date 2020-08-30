using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMenager : MonoBehaviour
{
    public GameObject star;
    public float speedSpawnStars = 10f;
    private float lastSpawn;
    private float horizontalCamSize;
    private float verticalCamSize;
    
    void Start()
    {
        verticalCamSize = Camera.main.orthographicSize;
        horizontalCamSize = verticalCamSize * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        float spawnX = Random.Range(-horizontalCamSize, horizontalCamSize);
        Vector3 spawnStar = new Vector3(spawnX, verticalCamSize + 1f, 0f);

        if(Time.time - lastSpawn  > 1/speedSpawnStars)
        {
            lastSpawn = Time.time;
            Instantiate(star, spawnStar, Quaternion.identity);
        }
    }
}
