using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject spearPrefabs;
    [SerializeField] GameObject crystalPrefabs;
    [SerializeField] GameObject coinPrefabs;

    [SerializeField] private float crystalSpawnChance = 0.2f; // xác suất spawn vật thể crystal
    [SerializeField] private float coinSpawnChance = 0.5f; // xác suất spawn vật thể coin
    [SerializeField] private float coinSeparationLength = 2f; // khoảng cách spawn vật thể coin theo trục y
    [SerializeField] float[] lanes =  { -2.5f, 0f, 2.5f }; // mảng vị trí spawn vật thể 
    [SerializeField] private float yOffset = 0.91f; // khoảng cách spawn vật thể theo trục y

    private bool isSafe = false;   // thêm dòng này

    public void SetSafe(bool safe)  // thêm hàm này
    {
        isSafe = safe;
    }

    List<int> availableLanes = new List<int> { 0, 1, 2 }; // danh sách các lane có sẵn


    public void Initialize()       
    {
        if (isSafe) return;
        SpawnSpear();
        SpawnCrystal();
        SpawnCoin();
    }

    private void SpawnSpear()
    {
        
        int spearToSpawn = UnityEngine.Random.Range(1, lanes.Length); // số lượng vật thể cần spawn (1 đến 3)

        for (int i =0; i < spearToSpawn; i++)
        {
            if (availableLanes.Count == 0) break; // nếu không còn lane nào có sẵn thì dừng spawn
            int selectedLane = SelectLane(); // lấy lane được chọn
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z); // tạo vị trí spawn dựa trên lane được chọn
            Instantiate(spearPrefabs, spawnPosition, Quaternion.identity, this.transform); // spawn vật thể tại vị trí spawn


        }
    }
    private void SpawnCrystal()
    {
        if (UnityEngine.Random.value > crystalSpawnChance || availableLanes.Count == 0) return; // nếu xác suất spawn vật thể crystal không đạt hoặc không còn lane nào có sẵn thì dừng spawn
        if (availableLanes.Count == 0) return; // nếu không còn lane nào có sẵn thì dừng spawn
        int selectedLane = SelectLane(); // lấy lane được chọn
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z); // tạo vị trí spawn dựa trên lane được chọn
        Instantiate(crystalPrefabs, spawnPosition, Quaternion.identity, this.transform); // spawn vật thể tại vị trí spawn
    }
    private void SpawnCoin()
    {
        if (UnityEngine.Random.value > coinSpawnChance || availableLanes.Count == 0) return; // nếu xác suất spawn vật thể coin không đạt hoặc không còn lane nào có sẵn thì dừng spawn
        if (availableLanes.Count == 0) return; // nếu không còn lane nào có sẵn thì dừng spawn
        int selectedLane = SelectLane(); // lấy lane được chọn
        int maxCoinsToSpawn = 6; // số lượng vật thể coin tối đa có thể spawn
        int coinsToSpawn = UnityEngine.Random.Range(1, maxCoinsToSpawn ); // số lượng vật thể coin cần spawn (1 đến 5)
        float topOfChunkZPos = transform.position.z + (coinSeparationLength * 2f); // tính toán vị trí z của vật thể coin đầu tiên dựa trên số lượng vật thể coin cần spawn và khoảng cách spawn
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeparationLength); // tính toán vị trí z của vật thể coin hiện tại dựa trên vị trí z của vật thể coin đầu tiên và khoảng cách spawn
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y + yOffset, spawnPositionZ); // tạo vị trí spawn dựa trên lane được chọn
            Instantiate(coinPrefabs, spawnPosition, Quaternion.identity, this.transform); // spawn vật thể tại vị trí spawn
        }
       
    }
    private int SelectLane()
    {
        int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // chọn ngẫu nhiên một lane từ danh sách có sẵn
        int selectedLane = availableLanes[randomLaneIndex]; // lấy lane được chọn
        availableLanes.RemoveAt(randomLaneIndex); // loại bỏ lane đã chọn khỏi danh sách có sẵn để tránh spawn trùng lặp
        return selectedLane;

    }
}
