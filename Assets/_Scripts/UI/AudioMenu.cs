using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    public AudioMixer audioMixerMain;

    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    void Start()
    {
        mainVolumeSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        audioMixerMain.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));

        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
        audioMixerMain.SetFloat("Music", PlayerPrefs.GetFloat("musicVolume"));

        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
        audioMixerMain.SetFloat("SFX", PlayerPrefs.GetFloat("sfxVolume"));
    }

    public void SetVolumeMain(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        audioMixerMain.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));
    }

    public void SetVolumeMusic(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
        audioMixerMain.SetFloat("Music", PlayerPrefs.GetFloat("musicVolume"));
    }

    public void SetVolumeSFX(float volume)
    {
        PlayerPrefs.SetFloat("sfxVolume", volume);
        audioMixerMain.SetFloat("SFX", PlayerPrefs.GetFloat("sfxVolume"));
    }
}
