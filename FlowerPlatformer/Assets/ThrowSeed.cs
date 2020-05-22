using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSeed : MonoBehaviour
{
    [SerializeField] private Transform origin = default;
    [SerializeField] private GameObject plantPrefab = default;
    [SerializeField] private float throwForce = 10f;
    private Rigidbody rb = default;
    private bool isThrown = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (!isThrown)
        {
            if (Input.GetMouseButtonDown(0))
                OnThrowSeed();
        }
    }

    private void LateUpdate()
    {
        if (!isThrown)
        {
            transform.position = origin.position;
            transform.rotation = origin.rotation;
        }
    }


    private void OnThrowSeed()
    {
        isThrown = true;
        rb.useGravity = true;
        rb.AddForce((transform.forward + Vector3.up / 2) * throwForce);
    }


    private void PlantFlowerPlatform(Vector3 position, Vector3 rotation)
    {
        Instantiate(plantPrefab, position, Quaternion.LookRotation(rotation));
    }

    private void ResetThrowingSeed()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        isThrown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Plantable"))
        {
            PlantFlowerPlatform(other.bounds.ClosestPoint(transform.position), other.transform.up);
            ResetThrowingSeed();
        }
    }



}
