using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        // Logic for when the coin is picked up
        Debug.Log("Coin collected!");
        // You can add more logic here, such as increasing the player's score
    }
}
