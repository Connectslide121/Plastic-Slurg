using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject Leo;
    public GameObject BulletPrefab;
    public GameObject GruntDeathPrefab;

    private float LastShoot;
    private int Health = 3;
    private float flickerDuration = 0.5f; // Adjust the duration as needed
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Leo == null) return;

        Vector3 direction = Leo.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Leo.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
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

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
            Health -= 1;
            if (Health == 0)
            {
                Destroy(gameObject);
                Instantiate(GruntDeathPrefab, transform.position, Quaternion.identity);
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
