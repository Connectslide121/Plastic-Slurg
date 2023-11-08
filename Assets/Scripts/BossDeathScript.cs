using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathScript : MonoBehaviour
{
    public float downwardForce = 1;
    public float lifeTime = 1;
    public AudioClip BossDeath;
    public AudioClip MissionCompleted;


    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(BossDeath);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(MissionCompleted);
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }
}
