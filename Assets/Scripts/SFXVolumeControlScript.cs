using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SFXVolumeControlScript : MonoBehaviour
{
    public GameObject sfxManager; 
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        sfxManager.GetComponent<SFXVolumeScript>().SetSFXVolume(volume);
    }
}
