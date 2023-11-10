using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagerScript : MonoBehaviour
{

    public AudioClip AmmoTaken;
    public AudioClip BossBomb;
    public AudioClip BossDeath;
    public AudioClip BossFire;
    public AudioClip BossIntro;
    public AudioClip CoinTaken;
    public AudioClip GameOver;
    public AudioClip HeartTaken;
    public AudioClip Hurt;
    public AudioClip Jump;
    public AudioClip JumpBoostTaken;
    public AudioClip Shoot;

    public void PlayAmmoTaken()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(AmmoTaken);
    }

    public void PlayBossBomb()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(BossBomb);
    }

    public void PlayBossDeath()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(BossDeath);
    }

    public void PlayBossFire()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(BossFire);
    }

    public void PlayBossIntro()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(BossIntro);
    }

    public void PlayCoinTaken()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(CoinTaken);
    }

    public void PlayGameOver()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(GameOver);
    }

    public void PlayHeartTaken()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(HeartTaken);
    }

    public void PlayHurt()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(Hurt);
    }

    public void PlayJump()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(Jump);
    }

    public void PlayJumpBoostTaken()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(JumpBoostTaken);
    }

    public void PlayShoot()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(Shoot);
    }
}
