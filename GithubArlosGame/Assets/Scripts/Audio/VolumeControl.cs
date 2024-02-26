using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private const string VolumeKey = "VolumeLevel";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        volumeSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    void ChangeVolume()
    {
        float newVolume = volumeSlider.value;
        audioSource.volume = newVolume;
        PlayerPrefs.SetFloat(VolumeKey, newVolume);
        PlayerPrefs.Save();
    }
}
