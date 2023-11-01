using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKillerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HealthTextScript.Health = 0;
        }

        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(collision.gameObject);
        }

    }
}
