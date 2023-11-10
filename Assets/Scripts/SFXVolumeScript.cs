using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeScript : MonoBehaviour
{
    public AudioSource SFX;

    public void SetSFXVolume(float volume)
    {
        SFX.volume = Mathf.Clamp01(volume);
    }

}
