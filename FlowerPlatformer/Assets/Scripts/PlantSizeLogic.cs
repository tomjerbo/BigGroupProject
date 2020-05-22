using UnityEngine;

public class PlantSizeLogic : MonoBehaviour
{
    private Animator anim = default;
    public float size = 0;
    public float energy = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("Size", size);
    }
    public bool Grow()
    {
        if (size < 1)
        {
            size += 1f * Time.deltaTime;
            if (size > 1) size = 1;
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool Shrink()
    {
        if (size > 0)
        {
            size -= 1f * Time.deltaTime;
            if (size < 0) size = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
