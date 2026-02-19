using System.Collections.Generic;
using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] lanes;   
    public float spawnZ = 10f;  
    public float spawnY = 0.5f; 
    
    // static bool alternateLane = true;    
    public Transform ObstacleSpawnPoint;

    // public int obstacleSpawnlane ;

    static int exerciseStep =0;

    public List<int> obstacleSpawnlanes = new List<int>() ;
    public void SpawnObstacle()
    {
        obstacleSpawnlanes.Clear();
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
                Destroy(child.gameObject);
        }


        // int PlayerlaneIndex = playerLine+1;
        // PlayerlaneIndex = Mathf.Clamp(PlayerlaneIndex, 0, lanes.Length - 1);

        // obstacleSpawnlanes.Add(1);



        // List<int> otherLanes = new List<int>{0,1,2};

        // otherLanes.Remove(PlayerlaneIndex); 

        // int secondLane = otherLanes[Random.Range(0,otherLanes.Count)];
        // obstacleSpawnlanes.Add(secondLane);


        // if (alternateLane)
        // {
        //     obstacleSpawnlanes.Add(2);
        // }
        // else
        // {
        //     obstacleSpawnlanes.Add(0);
        // }

        // alternateLane = !alternateLane;

        if (exerciseStep == 0)
        {
            obstacleSpawnlanes.Add(1);
            obstacleSpawnlanes.Add(2);

        }
        else if(exerciseStep==1)
        {
            obstacleSpawnlanes.Add(0);
            obstacleSpawnlanes.Add(1);
            
        }
        else if (exerciseStep == 2)
        {
            obstacleSpawnlanes.Add(0);
            obstacleSpawnlanes.Add(1);
            obstacleSpawnlanes.Add(2);

            
        }


        foreach (int laneIndex in obstacleSpawnlanes)
        {
            Vector3 spawnPos = new Vector3(
            lanes[laneIndex].position.x,             
            spawnY,                                  
            ObstacleSpawnPoint.position.z + spawnZ    
            );
       
            GameObject obs = Instantiate(
            obstaclePrefab,
            spawnPos,
            Quaternion.identity
            );

            obs.transform.SetParent(transform);
        }

        
    }

    public int GetExerciseStep()
    {
        return exerciseStep;
    }

    public void nextExerciseStep()
    {
        exerciseStep = (exerciseStep+1)%3;
    }
}
