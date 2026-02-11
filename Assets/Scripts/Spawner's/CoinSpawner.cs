using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    public ObstacleSpawner obstacleSpawner;
    public GameObject coinPrefab;
    public Transform[] lanes;          
    public Transform coinSpawnPoint;   



    public int coinCount = 6;
    public float coinSpacing = 2f;
    public float spawnY = 0.7f;

    public float jumpHeight = 2f;

    public void SpawnCoinLine()
    {
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Coin"))
                Destroy(child.gameObject);
        }

        int step = obstacleSpawner.GetExerciseStep();

        // Debug.Log(step);

        if (step==0)
        {
            SpawnstarightCoinLine(0);
        }
        else if (step == 1)
        {
            SpawnstarightCoinLine(2);
        }
        else if (step == 2)
        {
           spawnCurveCoinline(1);
        }
       
        // int laneIndex = Random.Range(0, lanes.Length);

        // bool sameLaneAsObstacle = obstacleLanes.Contains(laneIndex);

        // for (int i = 0; i < coinCount; i++)
        // {
            
        //     float t = (float) i / (coinCount-1);

        //     float y = spawnY;

        //     if (sameLaneAsObstacle)
        //     {
                
        //         float curve = Mathf.Sin(t*Mathf.PI);
        //         y+=curve*jumpHeight;
        //     }



        //    GameObject coin = Instantiate(coinPrefab,transform);

        //    coin.transform.position = new Vector3 (lanes[laneIndex].position.x,y,coinSpawnPoint.position.z+i*coinSpacing);


        void SpawnstarightCoinLine(int lane)
        {
            for(int i =0; i<coinCount; i++)
            {
              
                GameObject coin = Instantiate(coinPrefab,transform);

                coin.transform.position = new Vector3 (lanes[lane].position.x,spawnY,coinSpawnPoint.position.z+i*coinSpacing);
            }
        }

        void spawnCurveCoinline(int lane)
        {
           for(int i =0; i<coinCount; i++)
           {
                float t = (float) i / (coinCount-1);
                float y = spawnY;    
                float curve = Mathf.Sin(t*Mathf.PI);
                y+=curve*jumpHeight;


                GameObject coin = Instantiate(coinPrefab,transform);

                coin.transform.position = new Vector3 (lanes[lane].position.x,y,coinSpawnPoint.position.z+i*coinSpacing);
           } 
        }
           
        }

}



