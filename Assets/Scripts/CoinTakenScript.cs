using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTakenScript : MonoBehaviour
{
    public float upwardForce;
    public float lifeTime;


    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayCoinTaken();

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }
}
