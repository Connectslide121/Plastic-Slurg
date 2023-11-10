using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControlScript : MonoBehaviour
{
    public GameObject MusicManager;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        MusicManager.GetComponent<MusicVolumeScript>().SetSFXVolume(volume);
    }
}
