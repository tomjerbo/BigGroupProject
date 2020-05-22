using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent instance;

    private void Awake()
    {
        instance = this;
    }
    public event Action OnDoorProgressTrigger;
    public void DoorProgressTrigger()
    {
        if (OnDoorProgressTrigger != null)
            OnDoorProgressTrigger();
    }


    public event Action OnRemoveOldPlants;

    public void RemoveOldPlants()
    {
        if (OnRemoveOldPlants != null)
            OnRemoveOldPlants();
    }
}
