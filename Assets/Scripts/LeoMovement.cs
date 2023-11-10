using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeoMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce = 150;
    public float ShootCoolDown = 0.05f;
    public GameObject BulletPrefab;
    public GameObject LeoDeathPrefab;
    public GameObject GameOverScreen;
    public LayerMask ropeLayer;
    public float hangingHeight = 0.5f;
    public float hangingMoveSpeed = 5f;


    private float ropeYLevel;
    private bool isHanging = false;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private bool jumpAnimationTrigger;
    private float LastShoot;
    private int wallLayer;
    private Color originalColor;

    void Start()
    {
        GameObject Music = GameObject.FindGameObjectWithTag("Music");
        Music.GetComponent<MusicManagerScript>().PlayMainTheme();

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        wallLayer = LayerMask.GetMask("Walls");
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("jumping", jumpAnimationTrigger != false);
        Animator.SetBool("hanging", isHanging == true);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.15f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Jump();
            jumpAnimationTrigger = true;
        }
        else jumpAnimationTrigger = false;

        if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Z)) && Time.time > LastShoot + ShootCoolDown && AmmoTextScript.Ammo > 0)
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (HealthTextScript.Health <= 0)
        {
            GameOver();
        }

        if (isHanging)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Rigidbody2D.velocity = new Vector2(horizontalInput * hangingMoveSpeed, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReleaseRope();
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("HorizontalRopes") && !isHanging)
        {
            ropeYLevel = collision.transform.position.y;
            StartHanging();
        }
    }

    private void StartHanging()
    {
        isHanging = true;
        Rigidbody2D.velocity = Vector2.zero;
        Rigidbody2D.gravityScale = 0;

        Vector2 hangingPosition = new Vector2(transform.position.x, ropeYLevel - hangingHeight);
        Rigidbody2D.position = hangingPosition;

        gameObject.layer = LayerMask.NameToLayer("Hanging");
    }

    private void ReleaseRope()
    {
        isHanging = false;
        Rigidbody2D.gravityScale = 1;

        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void GameOver()
    {
        GameObject Music = GameObject.FindGameObjectWithTag("Music");
        Music.GetComponent<MusicManagerScript>().StopMainTheme();
        Music.GetComponent<MusicManagerScript>().StopBossTheme();
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayGameOver();

        Destroy(gameObject);
        Instantiate(LeoDeathPrefab, transform.position, Quaternion.identity);

        GameOverScreen.SetActive(true);
    }

    private void Jump()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayJump();

        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayShoot();

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

    public void Hit()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayHurt();

        HealthTextScript.Health = HealthTextScript.Health - 1;
        StartFlickerEffect();

    }

    private void StartFlickerEffect()
    {
        StartCoroutine(FlickerLeo());
    }

    private IEnumerator FlickerLeo()
    {
        float flickerTimer = 0f;
        float flickerDuration = 0.5f;


        while (flickerTimer < flickerDuration)
        {
            float alpha = flickerTimer / flickerDuration;
            alpha = Mathf.PingPong(alpha * 5f, 1f); 
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            flickerTimer += Time.deltaTime;
            yield return null;
        }

        GetComponent<SpriteRenderer>().color = originalColor;
    }


}