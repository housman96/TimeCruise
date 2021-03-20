using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsVolume : MonoBehaviour {
    public Slider sliderVolumeMaster;
    public Slider sliderVolumeMusic;
    public Slider sliderVolumeEffects;
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume) {
        if (volume <= sliderVolumeMaster.minValue)
        {
            volume = -80;
        }
        audioMixer.SetFloat("masterVolume",volume);
    }

    public void SetMusicVolume(float volume) {
        if (volume <= sliderVolumeMaster.minValue)
        {
            volume = -80;
        }
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetEffectsVolume(float volume) {
        if( volume <= sliderVolumeMaster.minValue)
        {
            volume = -80;
        }
        audioMixer.SetFloat("effectsVolume", volume);
    }
}
