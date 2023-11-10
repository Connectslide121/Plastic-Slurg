using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagerScript : MonoBehaviour
{

    public AudioSource AmmoTaken;
    public AudioSource BossBomb;
    public AudioSource BossDeath;
    public AudioSource BossFire;
    public AudioSource BossIntro;
    public AudioSource CoinTaken;
    public AudioSource GameOver;
    public AudioSource HeartTaken;
    public AudioSource Hurt;
    public AudioSource Jump;
    public AudioSource JumpBoostTaken;
    public AudioSource Shoot;

    public void PlayAmmoTaken()
    {
        AmmoTaken.Play();
    }

    public void PlayBossBomb()
    {
        BossBomb.Play();
    }

    public void PlayBossDeath()
    {
        BossDeath.Play();
    }

    public void PlayBossFire()
    {
        BossFire.Play();
    }

    public void PlayBossIntro()
    {
        BossIntro.Play();
    }

    public void PlayCoinTaken()
    {
        CoinTaken.Play();
    }

    public void PlayGameOver()
    {
        GameOver.Play();
    }

    public void PlayHeartTaken()
    {
        HeartTaken.Play();
    }

    public void PlayHurt()
    {
        Hurt.Play();
    }

    public void PlayJump()
    {
        Jump.Play();
    }

    public void PlayJumpBoostTaken()
    {
        JumpBoostTaken.Play();
    }

    public void PlayShoot()
    {
        Shoot.Play();
    }
}
