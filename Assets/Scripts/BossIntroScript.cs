using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroScript : MonoBehaviour
{
    public float upwardForce;
    public float lifeTime;
    public AudioClip BossIntro;
    public GameObject Boss;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(BossIntro);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        StartCoroutine(ActivateBossDelayed());
    }

    private IEnumerator ActivateBossDelayed()
    {
        // Wait for the specified lifetime
        yield return new WaitForSeconds(lifeTime);

        // Activate the "Boss" GameObject
        if (Boss != null)
        {
            Boss.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Boss GameObject is not assigned.");
        }

        // Destroy the current game object
        Destroy(gameObject);
    }
    public void StopMainTheme()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }

}
