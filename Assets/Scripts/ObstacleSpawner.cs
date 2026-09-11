using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclesPrefab; // object cho vật thể 
    private float obstaclesSpawnTime = 2f; // tốc độ spawn vật thể
    [SerializeField] private Transform swapPoint; 

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine()); // gọi hàm DelaySpawn để spawn vật thể sau 1 giây
    }

    IEnumerator SpawnObstacleRoutine()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(obstaclesSpawnTime);

            Instantiate(obstaclesPrefab, swapPoint.position, Random.rotation); // tạo vật thể tại vị trí spawn
        }
    }
    
}
