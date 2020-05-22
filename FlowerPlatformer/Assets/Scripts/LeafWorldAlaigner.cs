using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafWorldAlaigner : MonoBehaviour
{
    [SerializeField] private Transform stem = default;
    Quaternion rot;

    void Update()
    {
        
        rot = Quaternion.LookRotation(Vector3.ProjectOnPlane(stem.forward, Vector3.up), Vector3.up);
        transform.rotation = rot;
    }
}
