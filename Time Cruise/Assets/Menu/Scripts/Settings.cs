using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer audiomixer;

    public void SetAudioMaster(float volume) {
        audiomixer.SetFloat("masterVolume", volume);
    }

    public void SetAudioEffects(float volume) {
        audiomixer.SetFloat("effectsVolume", volume);
    }

    public void SetAudioMusic(float volume) {
        audiomixer.SetFloat("musicVolume", volume);
    }
}
