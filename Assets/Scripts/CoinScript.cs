using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject CoinTakenPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinTextScript.Coins += 1;
        Instantiate(CoinTakenPrefab, transform.position, Quaternion.identity);
        DestroyCoin();
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
