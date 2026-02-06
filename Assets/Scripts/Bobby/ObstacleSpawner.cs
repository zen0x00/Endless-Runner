using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] lanes;   
    
    public Player player;
    public float spawnZ = 10f;  
    public float spawnY = 0.5f; 
        
    public Transform ObstacleSpawnPoint;
    public void SpawnObstacle()
    {
        
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
                Destroy(child.gameObject);
        }

        int laneIndex = player.currentLane+1;
        
        laneIndex = Mathf.Clamp(laneIndex, 0, lanes.Length - 1);

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
