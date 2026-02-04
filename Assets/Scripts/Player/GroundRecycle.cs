using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRecycle : MonoBehaviour
{

  public Transform player;
  public List<Transform> chunks;
  public float chunkLength = 10f;

  private Queue<Transform> chunkQueue;

  void Start()
  {

    chunkQueue = new Queue<Transform>();

    foreach (Transform chunk in chunks)
    {
      chunkQueue.Enqueue(chunk);
    }
  }

  void Update()
  {
    Transform firstChunk = chunkQueue.Peek();

    // ✅ If player passed the first chunk
    if (player.position.z > firstChunk.position.z + chunkLength)
    {
      RecycleChunk();
    }
  }

  void RecycleChunk()
  {
    // Remove first chunk
    Transform oldChunk = chunkQueue.Dequeue();

    // Find last chunk position
    Transform lastChunk = null;
    foreach (Transform chunk in chunkQueue)
    {
      lastChunk = chunk;
    }

    // Move old chunk after last chunk
    oldChunk.position = new Vector3(
        oldChunk.position.x,
        oldChunk.position.y,
        lastChunk.position.z + chunkLength
    );

    // Add chunk back to queue
    chunkQueue.Enqueue(oldChunk);
  }
}


