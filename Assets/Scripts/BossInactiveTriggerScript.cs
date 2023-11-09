using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInactiveTriggerScript : MonoBehaviour
{
    public GameObject Boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boss.SetActive(false);
        }
    }

}
