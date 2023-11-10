using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    public AudioSource MainTheme;
    public AudioSource MainMenuTheme;
    public AudioSource BossTheme;
    public AudioSource MissionCompleTheme;

    public void PlayMainTheme()
    {
        MainTheme.Play();
    }

    public void StopMainTheme()
    {
        MainTheme.Stop();
    }

    public void PlayMainMenuTheme()
    {
        MainMenuTheme.Play();
    }

    public void PlayBossTheme()
    {
        BossTheme.Play();
    }

    public void PlayMissionCompleteTheme()
    {
        MissionCompleTheme.Play();
    }
}
