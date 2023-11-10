using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Shoot;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Shoot);
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LeoMovement leo = collision.GetComponent<LeoMovement>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if (leo != null)
        {
            leo.Hit();
        }

        if (grunt != null)
        {
            grunt.Hit();
        }

        DestroyBullet();
    }
}
