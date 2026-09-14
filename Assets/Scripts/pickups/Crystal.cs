using UnityEngine;

public class Crystal : Pickup
{
    [SerializeField] private float adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount); 
    }
}
