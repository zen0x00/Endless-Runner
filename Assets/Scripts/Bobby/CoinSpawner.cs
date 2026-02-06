using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    
    public GameObject coinPrefab;

    public Transform[] lanes;          
    public Transform coinSpawnPoint;   

    public int coinCount = 6;
    public float coinSpacing = 2f;
    public float spawnY = 0.7f;

    public void SpawnCoinLine()
    {
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Coin"))
                Destroy(child.gameObject);
        }

       
        int laneIndex = Random.Range(0, lanes.Length);

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 spawnPos = new Vector3(
                lanes[laneIndex].position.x,                
                spawnY,                                      
                coinSpawnPoint.position.z + i * coinSpacing 
            );

            GameObject coin = Instantiate(
                coinPrefab,
                spawnPos,
                Quaternion.identity
            );

           
           
            coin.transform.SetParent(transform);
    }

}


}

