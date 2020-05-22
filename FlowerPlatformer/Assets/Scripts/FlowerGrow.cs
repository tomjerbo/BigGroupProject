using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrow : MonoBehaviour
{
    public Animator anim;
    public bool grow = true;
    public float growSpeed = 10f;
    public GameObject leaf = default;
    public float size = 0f;

    private void Awake()
    {
        anim.SetFloat("Grow", 0f);
        //PlayerFlowerController.instance.oldFlower = this.gameObject;
        Instantiate(leaf);

    }

    public void ToggleFlower()
    {
        grow = !grow;
    }
    void Update()
    {
        if (grow)
        {
            if (anim.GetFloat("Grow") < 1)
            {
                anim.SetFloat("Grow", anim.GetFloat("Grow") + growSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Grow", 1f);
            }
        }
        else
        {
            if (anim.GetFloat("Grow") > 0)
            {
                anim.SetFloat("Grow", anim.GetFloat("Grow") - (growSpeed * Time.deltaTime));
            }
            else
            {
                anim.SetFloat("Grow", 0f);
            }
        }
    }

    public void RemoveOld()
    {
        ToggleFlower();
        Destroy(this.gameObject, 2f);
    }
}

