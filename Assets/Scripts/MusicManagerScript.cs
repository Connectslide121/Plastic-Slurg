using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    public AudioSource MainTheme;
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

    public void PlayBossTheme()
    {
        BossTheme.Play();
    }

    public void StopBossTheme()
    {
        BossTheme.Stop();
    }

    public void PlayMissionCompleteTheme()
    {
        MissionCompleTheme.Play();
    }
}
