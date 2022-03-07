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

    public Vector3 RandomSpawnPosition(float Xrange)
    {
        randomY = Random.Range(yRangeDown, yRangeUp);
        return new Vector3(Xrange, randomY, 0);
        
    }



    public void SpawnObjects()
    {
        // derecha o izquierda , izquierda = velocity * -1, 
        if (!playerControllerScript.gameOver)
        {
            int IsRight = Random.Range(0, 2);
            randomIndex = Random.Range(0, gamePrefabs.Length);
            if (IsRight == 1)
            {
               
                spawnPosition = RandomSpawnPosition(xRange);
                Instantiate(gamePrefabs[randomIndex], spawnPosition, gamePrefabs[randomIndex].transform.rotation);
            }

            else
            {
              
                spawnPosition = RandomSpawnPosition(xRange * -1);
                GameObject Obj = Instantiate(gamePrefabs[randomIndex], spawnPosition, gamePrefabs[randomIndex].transform.rotation);
                Obj.GetComponent<MoveObject>().speed *= -1;
            }
        }
    }
}
