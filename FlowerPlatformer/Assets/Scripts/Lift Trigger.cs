using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lift; //gameobject that you're moving
    public Transform origTarget; //original target / starting point
    public Transform target; //where you want the object to go
    public float speed; //wtf??
    bool IsTriggered; //is the object triggered
    void Start()
    {
        IsTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTriggered == false)
        {
            float step = speed * Time.deltaTime;
            Lift.transform.position = Vector3.MoveTowards(Lift.transform.position, origTarget.position, step);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "_PlayerBody")
        {
            IsTriggered = true;
            float step = speed * Time.deltaTime;
            Lift.transform.position = Vector3.MoveTowards(Lift.transform.position, target.position, step);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "_PlayerBody")
        {
            IsTriggered = false;
        }
    }
}
