using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement; // khai báo biến movement để lưu trữ thông tin di chuyển của người chơi
   public void Move(InputAction.CallbackContext context) // hàm Move được gọi khi người chơi di chuyển
    {
        movement = context.ReadValue<Vector2>(); // đọc giá trị di chuyển từ input và lưu trữ vào biến movement
    }
    void Update()
    {
        transform.Translate(movement * Time.deltaTime); // di chuyển người chơi dựa trên giá trị của biến movement
    }
}
