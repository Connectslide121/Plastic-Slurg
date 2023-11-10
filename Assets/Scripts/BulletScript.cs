using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public GameObject BulletImpactPrefab;
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
        Direction = direction.normalized;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GruntScript grunt = collision.GetComponent<GruntScript>();
        BossScript boss = collision.GetComponent<BossScript>();

        if ( grunt != null)
        {
            grunt.Hit();
        }

        if ( boss != null)
        {
            boss.Hit();
        }

        Instantiate(BulletImpactPrefab, transform.position, Quaternion.identity);

        DestroyBullet();
    }
}
