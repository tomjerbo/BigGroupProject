using UnityEngine;

public class RespawnLocationDebug : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, Vector3.one + Vector3.up);
    }
}
