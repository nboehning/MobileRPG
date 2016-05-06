using UnityEngine;

// Author: Tiffany Fisher
public class MessagingClientBroadcast : MonoBehaviour
{
    // Player enters our collision
    void OnCollisionEnter2D(Collision2D other)
    {
        // Call the broadcast
        MessagingManager.Instance.Broadcast();
    }
}
