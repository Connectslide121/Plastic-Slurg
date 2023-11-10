using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeScript : MonoBehaviour
{
    public AudioSource MainTheme;
    public AudioSource BossTheme;
    public AudioSource MissionCompleteTheme;

    public void SetSFXVolume(float volume)
    {
        MainTheme.volume = Mathf.Clamp01(volume);
        BossTheme.volume = Mathf.Clamp01(volume);
        MissionCompleteTheme.volume = Mathf.Clamp01(volume);
    }
}
