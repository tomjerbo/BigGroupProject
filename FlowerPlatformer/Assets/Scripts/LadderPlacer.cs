using UnityEngine;

public class LadderPlacer : MonoBehaviour
{
    // What flower it plants
    [SerializeField] private GameObject flower = default;
    // Can only plant a flower if it is thrown
    private bool isThrown = true;
    
    // Gizmo variables
    private Vector3 from = default;
    private Vector3 to = default;

    // On collision with an object
    private void OnCollisionEnter(Collision other)
    {
        // Only checks collision code if it's thrown
        if (!isThrown)
            return;
        // Checks if it's something it can plant on
        if (other.gameObject.layer == LayerMask.NameToLayer("Climbable"))
        {
            // Location of the impact
            from = other.GetContact(0).point;
            // Direction of the surface it impacted
            to = other.GetContact(0).normal;
            // Plant relevant flower ('from' is a world location, 'to' is a normalized direction, from + to = world position + normalized-direction)
            PlantFlower(from, from + to);
        }
    }

    public void SetFlowerToPlant(GameObject newFlower)
    {
        flower = newFlower;
    }


    // Method for planting the flower
    private void PlantFlower(Vector3 location, Vector3 direction)
    {
        // Creates the flower prefab
        GameObject flr =  Instantiate(flower, location, Quaternion.identity);
        // Sets rotation to it matches the surface direction
        flr.transform.LookAt(direction);
        // Disables further collisions
        isThrown = false;
    }

    // Debugging the impact point and direction of impact surface
    private void OnDrawGizmos()
    {
        if (from != default && to != default)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(from, from + to);
        }
    }
}
