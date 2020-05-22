using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafWorldAlaigner : MonoBehaviour
{
    [SerializeField] private Transform stem = default;
    Quaternion rot;

    void Update()
    {
        rot = Quaternion.LookRotation(stem.position + Vector3.up, Vector3.up);
        transform.rotation = rot;
        transform.position = stem.position;
    }
}
