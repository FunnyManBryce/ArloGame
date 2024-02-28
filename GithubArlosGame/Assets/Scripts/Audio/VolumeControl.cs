using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public List<AudioSource> audioSource;
    public BryceAudioManager BAM;

    private const string VolumeKey = "VolumeLevel";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        volumeSlider.value = savedVolume;
        foreach(AudioSource a in audioSource)
        {
            a.volume = savedVolume;
        }
        

        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }
    
    void ChangeVolume()
    {
        float newVolume = volumeSlider.value;
        foreach (AudioSource a in audioSource)
        {
            a.volume = newVolume;
        }
        PlayerPrefs.SetFloat(VolumeKey, newVolume);
        PlayerPrefs.Save();
    }
}
