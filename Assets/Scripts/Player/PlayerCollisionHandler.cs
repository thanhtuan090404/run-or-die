using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("Tham chiếu")]
    [SerializeField] private Animator playerAnimator;

    [Header("Thông số va chạm")]
    [SerializeField] private float collisionCooldown = 1f;
    [SerializeField] private float adjustChangeMoveSpeedAmount = -2f;

    private const string obstacleTag = "Obstacle";
    private const string hitTrigger = "Hit";

    private float cooldownTimer = 0f;
    private LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;
    }

    // Va chạm vật lý (đá lăn, vật thể có Rigidbody)
    private void OnCollisionEnter(Collision collision)
    {
        HandleHit(collision.gameObject);
    }

    // Va chạm trigger (spear, vật cản cho phép đi xuyên qua)
    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject obj)
    {
        if (!obj.CompareTag(obstacleTag))
            return;

        if (cooldownTimer > 0f)
            return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        playerAnimator.SetTrigger(hitTrigger);

        cooldownTimer = collisionCooldown;
    }
}