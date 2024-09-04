using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerPuzzle : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSource;


    void Start(){
        audioSource.volume = volumeSlider.value;
    }

    public void OnVolumeChanged()
    {
        float volume = volumeSlider.value;
        audioSource.volume = volumeSlider.value;

    }
}
