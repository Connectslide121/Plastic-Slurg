using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombScript : MonoBehaviour
{
    public GameObject BossBombExplosionPrefab;
    public Vector3 offset;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        LeoMovement leo = collision.GetComponent<LeoMovement>();

        if (leo != null)
        {
            leo.Hit();
        }

        Instantiate(BossBombExplosionPrefab, transform.position + offset, Quaternion.identity);
        Destroy(gameObject);
    }

}
