using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeoMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public float ShootCoolDown = 0.05f;
    public GameObject BulletPrefab;
    public GameObject LeoDeathPrefab;
    public AudioClip HurtSound;
    public AudioClip DeathSound;


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private bool jumpAnimationTrigger;
    private float LastShoot;
    private int wallLayer;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        wallLayer = LayerMask.GetMask("Walls");
    }

    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("jumping", jumpAnimationTrigger != false);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.15f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
            jumpAnimationTrigger = true;
        }
        else jumpAnimationTrigger = false;

        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > LastShoot + ShootCoolDown && AmmoTextScript.Ammo > 0)
        {
            Shoot();
            LastShoot = Time.time;
        }
        if (HealthTextScript.Health == 0)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(DeathSound);
            Destroy(gameObject);
            Instantiate(LeoDeathPrefab, transform.position, Quaternion.identity);
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);

        AmmoTextScript.Ammo--;
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = Horizontal * MovementSpeed;

        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(horizontalVelocity), 0.05f, wallLayer);

        if (wallHit.collider == null)
        {
            Rigidbody2D.velocity = new Vector2(horizontalVelocity, Rigidbody2D.velocity.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
        }
    }

    public void Hit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(HurtSound);

        HealthTextScript.Health = HealthTextScript.Health - 1;
    }

}