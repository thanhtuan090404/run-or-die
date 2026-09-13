using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pickup collected by: " + other.gameObject.name);
            // Add logic for what happens when the pickup is collected
            Destroy(gameObject); // Destroy the pickup object
        }
    }
}
