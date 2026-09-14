using UnityEngine;

public class Crystal : Pickup
{
    protected override void OnPickup()
    {
        // Add logic for what happens when the crystal is picked up
        Debug.Log("Crystal picked up!");
    }
}
