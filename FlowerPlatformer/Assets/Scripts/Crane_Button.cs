using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Crane_Hook_Top; //gameobject that you're moving
    public Transform origTarget; //original target / starting point
    public Transform target; //where you want the object to go
    public float speed; //wtf??
    bool IsButtonPressed; //is the object triggered
    void Start()
    {
        IsButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) == true)
        {
            IsButtonPressed = false;
        }
        if (IsButtonPressed == false)
        {
            float step = speed * Time.deltaTime;
            Crane_Hook_Top.transform.position = Vector3.MoveTowards(Crane_Hook_Top.transform.position, origTarget.position, step);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Leaf")
        {
            IsButtonPressed = true;
            float step = speed * Time.deltaTime;
            Crane_Hook_Top.transform.position = Vector3.MoveTowards(Crane_Hook_Top.transform.position, target.position, step);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Leaf")
        {
            IsButtonPressed = false;
        }
    }

    



}
