using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer SFXMixer;
    public Slider SFXSlider;

    public AudioMixer MusicMixer;
    public Slider MusicSlider;

    private void Start()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

    }

    public void SetSFXLevel(float sliderValue)
    {
        SFXMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    public void SetMusicLevel(float sliderValue)
    {
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
