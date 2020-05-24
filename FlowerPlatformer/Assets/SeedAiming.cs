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
    [SerializeField] private LayerMask ladderPlantable = default;
    [SerializeField] private LayerMask ladder = default;
    [SerializeField] private GameObject ghostLadder = default;
    [SerializeField] private GameObject realLadder = default;
    [SerializeField] private GameObject ghostPlant = default;
    [SerializeField] private GameObject realPlant = default;
    private List<PlantSizeLogic> Props = default;
    [SerializeField] private Slider energyBar = default;
    [SerializeField] private ShittyMovement body = default;
    private bool showAim = false;


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
        CheckForTargets(plant, plantable, realPlant);
        CheckForTargets(ladder, ladderPlantable, realLadder);
        energyBar.value = energy;
        ShowAim();
    }
    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G))
            KillAllPlants();
    }

    private void KillAllPlants()
    {
        PlantSizeLogic[] prop = GameObject.FindObjectsOfType<PlantSizeLogic>();
        foreach (PlantSizeLogic objs in prop)
        { 
            Destroy(objs.transform.root.gameObject);
        }
        energy = 100f;
    }

    private void CheckForTargets(LayerMask filled, LayerMask empty, GameObject prefab)
    {
        if (Physics.Raycast(checkPlant, out RaycastHit hitPlant, range, filled, QueryTriggerInteraction.Collide))
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
            if (Input.GetMouseButtonDown(1) && !body.OnLadder())
            {
                energy += hitPlant.collider.GetComponent<PlantSizeLogic>().energy + plantCost;
                Destroy(hitPlant.collider.gameObject);
            }
        }
        else
        {
            if (Physics.Raycast(checkDirt, out RaycastHit hitDirt, range, empty, QueryTriggerInteraction.Collide))
            {
                print("Hit dirt");
                if (Input.GetMouseButtonDown(0) & energy >= plantCost)
                {
                    print("Planting");
                    Plant(hitDirt, prefab);
                }
                else
                {
                    if (energy < plantCost)
                        print("Not enough energy to plant another tree.");
                }
            }
        }
    }

    private void ShowAim()
    {
        if (Input.GetKeyDown(KeyCode.F))
            showAim = !showAim;

        if (showAim)
        {
            if (Physics.Raycast(checkPlant, out RaycastHit fakePlant, range, plantable, QueryTriggerInteraction.Collide))
            {
                ghostPlant.SetActive(true);
                ghostPlant.transform.position = fakePlant.point;
                ghostPlant.transform.rotation = Quaternion.LookRotation(fakePlant.normal);
            }
            else
            {
                ghostPlant.SetActive(false);
            }
            if (Physics.Raycast(checkPlant, out RaycastHit fakeLadder, range, ladderPlantable, QueryTriggerInteraction.Collide))
            {
                ghostLadder.SetActive(true);
                ghostLadder.transform.position = fakeLadder.point;
                ghostLadder.transform.rotation = Quaternion.LookRotation(fakeLadder.normal);
            }
            else
            {
                ghostLadder.SetActive(false);
            }
        }
        else
        {
            ghostPlant.SetActive(false);
            ghostLadder.SetActive(false);
        }
    }



    private void Plant(RaycastHit hitDirt, GameObject obj)
    {
        Instantiate(obj, hitDirt.point, Quaternion.LookRotation(hitDirt.normal, Vector3.up));
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
