using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EntityDataContainer entityToSpawn;

    EntitySpawner MANAGER_ENTITY_SPAWNER;

    List<GameObject> entityList = new List<GameObject>();

    private void Awake()
    {
        MANAGER_ENTITY_SPAWNER = GetComponent<EntitySpawner>();
    }


    // Start is called before the first frame update
    void Start()
    {

        var newEntity = MANAGER_ENTITY_SPAWNER.SpawnEntity(entityToSpawn);
        entityList.Add(newEntity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
