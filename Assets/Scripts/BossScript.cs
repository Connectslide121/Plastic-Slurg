using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Leo;
    public GameObject BulletPrefab;
    public GameObject BossBody;
    public GameObject Boss;
    public float ShootingDistance = 2.0f;

    private Vector3 offset = new Vector3(0, -0.5f, 0);
    private float LastShoot;
    private int Health = 20;
    private float flickerDuration = 0.5f;
    private Color originalColor;

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (Leo == null) return;

        Vector3 direction = Leo.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Leo.transform.position.x - transform.position.x);

        if (distance < ShootingDistance && Time.time > LastShoot + 0.7f && (Health > 15 || (Health <= 10 && Health > 5)))
        {
            Shoot();
            LastShoot = Time.time;
        }

        if (distance < ShootingDistance && Time.time > LastShoot + 0.7f && ((Health <= 15 && Health > 10) || (Health < 10 && Health <= 5)))
        {
            ShootBombs();
            LastShoot = Time.time;
        }


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

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f + offset, Quaternion.identity);
        bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
    }

    private void ShootBombs()
    {

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
