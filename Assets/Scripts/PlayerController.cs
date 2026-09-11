using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // khai báo biến moveSpeed để điều chỉnh tốc độ di chuyển của người chơi
    [SerializeField] private float xClamp = 3.7f; // khai báo biến xClamp để giới hạn vị trí x của người chơi
    [SerializeField] private float zClamp = 3.7f; // khai báo biến zClamp để giới hạn vị trí z của người chơi
    Vector3 moveDirection; // khai báo biến moveDirection để lưu trữ hướng di chuyển của người chơi
    Vector3 curentPosition; // khai báo biến currentPosition để lưu trữ vị trí hiện tại của người chơi
    private Rigidbody rb; // khai báo biến rb để lưu trữ thông tin về Rigidbody của người chơi
    private Vector2 movement; // khai báo biến movement để lưu trữ thông tin di chuyển của người chơi
    public void Move(InputAction.CallbackContext context) // hàm Move được gọi khi người chơi di chuyển
    {
        movement = context.ReadValue<Vector2>(); // đọc giá trị di chuyển từ input và lưu trữ vào biến movement
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // lấy thông tin về Rigidbody của người chơi
    }
    void FixedUpdate()
    {
        HandeMovement(); // gọi hàm HandeMovement để xử lý di chuyển của người chơi
        
    }

    private void HandeMovement()
    {
        Vector3 currentPosition = rb.position; // lấy vị trí hiện tại của người chơi
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y); // tạo hướng di chuyển dựa trên giá trị di chuyển của người chơi
        Vector3 newPosition = currentPosition + moveDirection * moveSpeed * Time.fixedDeltaTime; // tính toán vị trí mới của người chơi dựa trên vị trí hiện tại và hướng di chuyển

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp); // giới hạn vị trí x của người chơi
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp); // giới hạn vị trí z của người chơi
        rb.MovePosition(newPosition);

    }
}
