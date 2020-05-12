using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlowerController : MonoBehaviour
{
    [SerializeField] FlowerGrow[] Flowers = default;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Flowers[0].ToggleFlower();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Flowers[1].ToggleFlower();
        if (Input.GetKeyDown(KeyCode.Alpha3)) Flowers[2].ToggleFlower();
    }
}
