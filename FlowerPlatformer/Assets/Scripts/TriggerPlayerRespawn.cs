using UnityEngine;
using Toolkit;

public class TriggerPlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation = default;
    [SerializeField] private LayerMask playerMask = default;
    private void OnCollisionEnter(Collision other)
    {
        print("A");
        if (other.gameObject.layer.Contains(playerMask))
        {
            print("B");
            GameEvent.instance.PlayerDeath(respawnLocation);
        }
    }
}
