using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TextSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private string audioParam = "MusicVolume";

    // Start is called before the first frame update
    void Start()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        audioMixer.SetFloat(audioParam, volumeSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
