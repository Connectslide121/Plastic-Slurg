using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathScript : MonoBehaviour
{
    public float downwardForce = 1;
    public float lifeTime = 1;

    private void Start()
    {
        GameObject Music = GameObject.FindGameObjectWithTag("Music");
        Music.GetComponent<MusicManagerScript>().StopBossTheme();
        Music.GetComponent<MusicManagerScript>().PlayMissionCompleteTheme();

        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayBossDeath();

        GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
        Invoke("FreezeGame", lifeTime);

        Destroy(gameObject, lifeTime);

    }

    private void FreezeGame()
    {
        Time.timeScale = 0;
    }
}
