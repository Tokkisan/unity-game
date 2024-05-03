using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    void Start(){
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = volume;
    }

    public void VolumeSlide(){
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();

    }
}
