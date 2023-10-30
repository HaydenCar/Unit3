using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float spawnDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private float leftBound = -15;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacles", spawnDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound && gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void spawnObstacles()
    {
        if (playerControllerScript.gameOver == false) { 
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

        
    }
}
