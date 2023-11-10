using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject Leo;
    public GameObject BulletPrefab;
    public GameObject GruntDeathPrefab;
    public float ShootingDistance = 1.0f;
    public float MaxHealth = 3;
    public float Health = 3;

    private FloatingHealthBar HealthBar;
    private float LastShoot;
    private float flickerDuration = 0.5f; // Adjust the duration as needed
    private Color originalColor;

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        HealthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Update()
    {
        if (Leo == null) return;

        Vector3 direction = Leo.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Leo.transform.position.x - transform.position.x);

        if(distance < ShootingDistance && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }


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
        bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
            Health -= 1;
            HealthBar.UpdateHealthBar(Health, MaxHealth);

            if (Health == 0)
            {
                ScoreTextScript.Score += 50;
                Destroy(gameObject);
                Instantiate(GruntDeathPrefab, transform.position, Quaternion.identity);
            }
            else
            {
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
            float alpha = flickerTimer / flickerDuration;
            alpha = Mathf.PingPong(alpha * 5f, 1f); 
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            flickerTimer += Time.deltaTime;
            yield return null;
        }

        GetComponent<SpriteRenderer>().color = originalColor;
    }


}
