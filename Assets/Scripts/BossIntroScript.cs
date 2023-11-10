using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroScript : MonoBehaviour
{
    public float upwardForce;
    public float lifeTime;
    public GameObject Boss;

    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayBossIntro();

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        StartCoroutine(ActivateBossDelayed());
    }

    private IEnumerator ActivateBossDelayed()
    {
        yield return new WaitForSeconds(lifeTime);

        GameObject Music = GameObject.FindGameObjectWithTag("Music");
        Music.GetComponent<MusicManagerScript>().PlayBossTheme();

        Boss.SetActive(true);
        Destroy(gameObject);
    }

}
