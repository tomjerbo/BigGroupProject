using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvent.instance.DoorProgressTrigger();
    }
}
