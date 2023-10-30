using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Shoot;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Shoot);
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

        if ( grunt != null)
        {
            grunt.Hit();
        }

        DestroyBullet();
    }
}
