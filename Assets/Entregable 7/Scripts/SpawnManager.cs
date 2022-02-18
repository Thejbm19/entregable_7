using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject[] gamePrefabs;
    private float yRangeUp = 14f;
    private float yRangeDown = 1f;
    private float xRange = 14f;
    private float startTime = 2f;
    private float repeatRate = 1.5f;
    private float randomY;
    private int randomIndex;
    public bool gameOver;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObjects", startTime, repeatRate);
    }

   
    void Update()
    {

    }

    public Vector3 RandomSpawnPosition()
    {
        randomY = Random.Range(yRangeDown, yRangeUp);
        return new Vector3(xRange, randomY, 0);
        
    }



    public void SpawnObjects()
    {
        if (!playerControllerScript.gameOver)
        { 
            randomIndex = Random.Range(0, gamePrefabs.Length);
            spawnPosition = RandomSpawnPosition();
            Instantiate(gamePrefabs[randomIndex], spawnPosition, gamePrefabs[randomIndex].transform.rotation); 
        }
    }
}
