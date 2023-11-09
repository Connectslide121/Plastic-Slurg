using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Leo;
    public GameObject BulletPrefab;
    public GameObject BossBody;
    public GameObject Boss;
    public GameObject BossBombPrefab;
    public Vector3 BombYOffset;
    public Vector3 BombXOffset;
    public float ShootingDistance = 2.0f;

    private float LastShoot;
    private int Health = 32;
    private float flickerDuration = 0.5f;
    private Color originalColor;
    private Vector3 playerPosition;

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        playerPosition = Leo.transform.position;

        if (Leo == null) return;

        Vector3 direction = Leo.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Leo.transform.position.x - transform.position.x);

        if (distance < ShootingDistance && Time.time > LastShoot + 0.7f && Health > 24)
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (distance < ShootingDistance && Time.time > LastShoot + 1.2f && (Health <= 24 && Health > 16))
        {
            Shoot();
            ShootBombs();
            LastShoot = Time.time;
        }

        if (distance < ShootingDistance && Time.time > LastShoot + 0.5f && (Health <= 16 && Health > 8))
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (distance < ShootingDistance && Time.time > LastShoot + 1f && Health <= 8)
        {
            Shoot();
            ShootBombs();
            LastShoot = Time.time;
        }

        if(Health <= 24 && Health > 16)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if(Health <= 8)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }


    }

    private void Shoot()
    {
        Vector3 playerDirection = (Leo.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + playerDirection * 0.1f, Quaternion.identity);
        bullet.GetComponent<EnemyBulletScript>().SetDirection(playerDirection);
    }

    private void ShootBombs()
    {
        Instantiate(BossBombPrefab, playerPosition + BombYOffset, Quaternion.Euler(0, 0, -90));
        Instantiate(BossBombPrefab, playerPosition + BombYOffset - BombXOffset, Quaternion.Euler(0, 0, -90));
        Instantiate(BossBombPrefab, playerPosition + BombYOffset + BombXOffset, Quaternion.Euler(0, 0, -90));

    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0)
        {
            ScoreTextScript.Score += 1000;
            Boss.GetComponent<BossPrefabScript>().BossPrefabSpawn();
            Destroy(Boss);
        }
        else
        {
            // Call a method to start the flicker effect
            StartFlickerEffect();
        }
    }

    private void StartFlickerEffect()
    {
        StartCoroutine(FlickerEnemy());
    }

    private IEnumerator FlickerEnemy()
    {
        float flickerTimer = 0f;

        while (flickerTimer < flickerDuration)
        {
            // Calculate the alpha value based on the flicker timer.
            float alpha = flickerTimer / flickerDuration;
            alpha = Mathf.PingPong(alpha * 5f, 1f); // Adjust the speed as needed
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            flickerTimer += Time.deltaTime;
            yield return null;
        }

        // Reset the sprite renderer to its original state.
        GetComponent<SpriteRenderer>().color = originalColor;
    }


}
