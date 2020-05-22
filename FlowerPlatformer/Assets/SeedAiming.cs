using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedAiming : MonoBehaviour
{

    public float energy = 100f;
    private float growSpeed = 40f;
    private float plantCost = 30f;
    private float range = 15f;
    private Ray checkPlant;
    private Ray checkDirt;
    [SerializeField] private LayerMask plantable = default;
    [SerializeField] private LayerMask plant = default;
    [SerializeField] private GameObject ghostPlant = default;
    [SerializeField] private GameObject realPlant = default;
    private List<GameObject> Plants = default;
    private int plantIndex = 0;
    [SerializeField] private Slider energyBar = default;


    private void AimRaycast()
    {
        checkPlant.origin = transform.position;
        checkPlant.direction = transform.forward;
        checkDirt.origin = transform.position;
        checkDirt.direction = transform.forward;
    }

    private void Update()
    {
        AimRaycast();
        CheckForTargets();
        energyBar.value = energy;
    }

    private void CheckForTargets()
    {
        if (Physics.Raycast(checkPlant, out RaycastHit hitPlant, range, plant, QueryTriggerInteraction.Collide))
        {
            print("Hit plant");
            if (Input.GetKey(KeyCode.R) && energy > growSpeed * Time.deltaTime)
            {
                print("Growing plant");
                if (hitPlant.collider.GetComponent<PlantSizeLogic>().size < 1)
                {
                    hitPlant.collider.GetComponent<PlantSizeLogic>().size += 0.7f * Time.deltaTime;
                    hitPlant.collider.GetComponent<PlantSizeLogic>().energy += growSpeed * Time.deltaTime;
                    energy -= growSpeed * Time.deltaTime;
                }
            }
            if(Input.GetKey(KeyCode.E))
            {
                print("Shrinking plant");
                if (hitPlant.collider.GetComponent<PlantSizeLogic>().size > 0.3)
                {
                    hitPlant.collider.GetComponent<PlantSizeLogic>().size -= 0.7f * Time.deltaTime;
                    hitPlant.collider.GetComponent<PlantSizeLogic>().energy -= growSpeed * Time.deltaTime;
                    energy += growSpeed * Time.deltaTime;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                energy += hitPlant.collider.GetComponent<PlantSizeLogic>().energy + 30f;
                Destroy(hitPlant.collider.gameObject);
            }
        }
        else
        {
            if (Physics.Raycast(checkDirt, out RaycastHit hitDirt, range, plantable, QueryTriggerInteraction.Collide))
            {
                print("Hit dirt");
                if (Input.GetMouseButtonDown(0) & energy >= plantCost)
                {
                    print("Planting");
                    PlantFlower(hitDirt);
                }
                else
                {
                    if (energy < 30)
                        print("Not enough energy to plant another tree.");
                }
            }
        }
    }


    private void PlantFlower(RaycastHit hitDirt)
    {
        Instantiate(realPlant, hitDirt.point, Quaternion.LookRotation(Vector3.up, hitDirt.normal));
        energy -= plantCost;
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(checkPlant.origin, checkPlant.origin + checkPlant.direction * 15f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(checkDirt.origin, checkDirt.origin + checkDirt.direction * 15f);
    }
}
