using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject spearPrefabs; 
    [SerializeField] float[] lanes =  { -2.5f, 0f, 2.5f }; // mảng vị trí spawn vật thể 
    [SerializeField] private float yOffset = 0.91f; // khoảng cách spawn vật thể theo trục y


    void Start()
    {
        SpawnSpear();
    }

    private void SpawnSpear()
    {
        List<int> availableLanes = new List<int> { 0, 1, 2 }; // danh sách các lane có sẵn
        int spearToSpawn = UnityEngine.Random.Range(1, lanes.Length); // số lượng vật thể cần spawn (1 đến 3)

        for (int i =0; i < spearToSpawn; i++)
        {
            int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // chọn ngẫu nhiên một lane từ danh sách có sẵn
            int selectedLane = availableLanes[randomLaneIndex]; // lấy lane được chọn
            availableLanes.RemoveAt(randomLaneIndex); // loại bỏ lane đã chọn khỏi danh sách có sẵn để tránh spawn trùng lặp
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z); // tạo vị trí spawn dựa trên lane được chọn
            Instantiate(spearPrefabs, spawnPosition, Quaternion.identity, this.transform); // spawn vật thể tại vị trí spawn


        }
    }
}
