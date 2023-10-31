using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTakenScript : MonoBehaviour
{
    public float upwardForce;
    public float lifeTime;
    public AudioClip CoinTaken;


    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(CoinTaken);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }
}
