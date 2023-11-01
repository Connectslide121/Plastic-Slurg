using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public int HealthToAdd = 5;
    public GameObject HeartTakenPrefab;
    public Vector3 heightOffset = new Vector3(0f, 0.05f, 0f);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthTextScript.Health += HealthToAdd;
        Instantiate(HeartTakenPrefab, transform.position + heightOffset, Quaternion.identity); 
        DestroyHeart();
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }


}
