using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathScript : MonoBehaviour
{
    public float downwardForce = 1;
    public float lifeTime = 1;

    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayBossDeath();

        GameObject Music = GameObject.FindGameObjectWithTag("Music");
        Music.GetComponent<MusicManagerScript>().PlayMissionCompleteTheme();


        GetComponent<Rigidbody2D>().AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }
}
