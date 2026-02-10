using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundrecycleScript : MonoBehaviour
{
    public CoinSpawner coinSpawner;
    public ObstacleSpawner obstacleSpawner;
    public Transform player;      

    public playermovement playerSript;
    
    public float groundLength = 20f; 
    

    void Update()
    {
       
        if (transform.position.z + groundLength < player.position.z)
        {
            RecycleGround();
        }
    }

    void RecycleGround()
    {
        Vector3 moveAmount = Vector3.forward * groundLength * 3f;
        transform.position += moveAmount;


        obstacleSpawner.SpawnObstacle();
        coinSpawner.SpawnCoinLine();
        obstacleSpawner.nextExerciseStep();
    }

    
}
