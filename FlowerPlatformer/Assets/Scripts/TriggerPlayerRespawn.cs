using UnityEngine;
using Toolkit;

public class TriggerPlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation = default;
    [SerializeField] private LayerMask playerMask = default;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer.Contains(playerMask))
        {
            GameEvent.instance.PlayerDeath(respawnLocation);
        }
    }
}
