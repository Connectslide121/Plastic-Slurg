using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int ScoreToAdd = 10;
    public GameObject CoinTakenPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTextScript.Score += ScoreToAdd;
        Instantiate(CoinTakenPrefab, transform.position, Quaternion.identity);
        DestroyCoin();
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
