using System;
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ChunkPrefabs; 
    [SerializeField] private int startingChunkAmount = 10; // Number of chunks to generate at the start 
    [SerializeField] private float chunkLength = 10f; // Length of each chunk along the z-axis
    [SerializeField] private Transform chunkParent; 
    [SerializeField] private float moveSpeed = 5f; // Speed at which the chunks move towards the player

    private Camera mainCamera; 
    List<GameObject> chunks = new List<GameObject>(); // List to hold references to the spawned chunks



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main; // cache 1 lần duy nhất
        SpawnStartingChunks();


    }
    // Update is called once per frame
    void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        float despawnZ = mainCamera.transform.position.z - chunkLength;

        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // chunk cũ nhất luôn ở đầu list
        if (chunks.Count > 0 && chunks[0].transform.position.z <= despawnZ)
        {
            GameObject oldChunk = chunks[0];
            chunks.RemoveAt(0);
            Destroy(oldChunk);
            SpawnChunks();
        }
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunks();

        }

    }

    private void SpawnChunks()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject newChunk = Instantiate(ChunkPrefabs, spawnPosition, Quaternion.identity, chunkParent); // khởi tạo phần tử chunk mới và đặt nó làm con của chunkParent
        chunks.Add(newChunk); // Add the new chunk to the list
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

            if ( chunks.Count == 0)
            {
               spawnPositionZ = transform.position.z; // First chunk at the player's starting position
        }
         
            else
            {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength; // tạo spawnPositionZ dựa trên vị trí của chunk cuối cùng trong danh sách và cộng thêm chiều dài của chunk

        }
        return spawnPositionZ;
    }
 
  

   
}
