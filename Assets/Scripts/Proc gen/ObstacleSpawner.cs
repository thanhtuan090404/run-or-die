using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesPrefabs; // object cho vật thể 
    private float obstaclesSpawnTime = 2f; // tốc độ spawn vật thể
    [SerializeField] private float spawnWidth = 4f; // chiều rộng spawn vật thể
    [SerializeField] private Transform obstaclesParent; 




    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine()); // gọi hàm DelaySpawn để spawn vật thể sau 1 giây
    }

    IEnumerator SpawnObstacleRoutine()
    {
        
        while (true)
        {
            GameObject obstaclesPrefab = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)]; // chọn ngẫu nhiên vật thể từ mảng obstaclesPrefabs
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z); // tạo vị trí spawn ngẫu nhiên trong phạm vi spawnWidth
            yield return new WaitForSeconds(obstaclesSpawnTime);

            Instantiate(obstaclesPrefab, spawnPosition, Random.rotation); // tạo vật thể tại vị trí spawn
        }
    }
    
}
