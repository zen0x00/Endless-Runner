using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    
    public GameObject coinPrefab;
    public Transform[] lanes;          
    public Transform coinSpawnPoint;   



    public int coinCount = 6;
    public float coinSpacing = 2f;
    public float spawnY = 0.7f;

    public float jumpHeight = 2f;

    public void SpawnCoinLine(int obstacleLane)
    {
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Coin"))
                Destroy(child.gameObject);
        }

       
        int laneIndex = Random.Range(0, lanes.Length);

        bool sameLaneAsObstacle = laneIndex == obstacleLane;

        for (int i = 0; i < coinCount; i++)
        {
            
            float t = (float) i / (coinCount-1);

            float y = spawnY;

            if (sameLaneAsObstacle)
            {
                
                float curve = Mathf.Sin(t*Mathf.PI);
                y+=curve*jumpHeight;
            }



           GameObject coin = Instantiate(coinPrefab,transform);

           coin.transform.position = new Vector3 (lanes[laneIndex].position.x,y,coinSpawnPoint.position.z+i*coinSpacing);
           
        }

}


}

