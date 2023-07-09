using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOption : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeAudio", 1f);

        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void changeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("VolumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void CheckMute()
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
}
