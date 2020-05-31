using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject stone;
    [SerializeField]
    private float nextSpawnTime = 0;
    [SerializeField]
    private float cooldownTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + cooldownTime;
            Instantiate(stone,transform.position,transform.rotation);
        }
    }
}
