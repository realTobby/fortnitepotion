using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    EntityDataContainer myData;
    SpriteRenderer mySpriteRenderer;
    GameObject myShadowGO;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitEntity(EntityDataContainer dataIn, GameObject shadowPrefab)
    {
        myShadowGO = GameObject.Instantiate(shadowPrefab, transform);
        myShadowGO.SetActive(false);

        myData = dataIn;

        ApplySprite();
    }

    private void ApplySprite()
    {
        mySpriteRenderer.sprite = myData.EntitySprite;
    }


}
