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
        OnDoorProgressTrigger?.Invoke();
    }


    public event Action OnRemoveOldPlants;

    public void RemoveOldPlants()
    {
        OnRemoveOldPlants?.Invoke();
    }

    public event Action<Transform> OnPlayerDeath;
    public void PlayerDeath(Transform location)
    {
        OnPlayerDeath?.Invoke(location);
    }
}
