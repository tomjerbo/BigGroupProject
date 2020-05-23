using UnityEngine;

public class LavaTextureFlow : MonoBehaviour
{
    [SerializeField] private Material lava = default;
    [SerializeField] private float flowSpeed = 1f;
    [SerializeField] private Vector2 lavaUV = default;

    private void Update()
    {
        MoveLavaUVOffset();
        lava.mainTextureOffset = lavaUV;
    }


    private void MoveLavaUVOffset()
    {
        lavaUV.y += flowSpeed * Time.deltaTime;
    }

}
