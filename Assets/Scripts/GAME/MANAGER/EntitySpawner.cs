using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a fucking entity factory oh shit, but completly wrong implementation...but i dont care enough to change it

public class EntitySpawner : MonoBehaviour
{
    public GameObject HollowEntityPrefab;

    public GameObject EntityShadowPrefab;

    public GameObject SpawnEntity(EntityDataContainer entityData)
    {
        var result = GameObject.Instantiate(HollowEntityPrefab, Vector3.zero, Quaternion.identity);

        result.GetComponent<Entity>().InitEntity(entityData, EntityShadowPrefab);

        return result;
    }
}
