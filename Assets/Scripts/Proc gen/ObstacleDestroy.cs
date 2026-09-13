using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {      
            Destroy(collision.gameObject);
    }
}
