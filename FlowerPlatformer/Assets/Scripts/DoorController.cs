using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Vector3 pos;
    private void Start()
    {
        pos = transform.position;
        GameEvent.instance.OnDoorProgressTrigger += OnDoorwayOpen;
    }

    private void OnDoorwayOpen()
    {
        transform.position = pos + Vector3.up * 8;
        GameEvent.instance.OnDoorProgressTrigger -= OnDoorwayOpen;
    }

}
