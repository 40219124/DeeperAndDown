using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[ExecuteInEditMode]
public class ExposeMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string ChannelString;

    private string[] validChannels = new string[3] { "MasterVolume", "MusicVolume", "SoundsVolume" };

    private void Start()
    {
        float val = 1.0f;
        Slider slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey(ChannelString))
        {
            val = PlayerPrefs.GetFloat(ChannelString);
            if (slider != null)
            {
                slider.value = val;
            }
        }
        else if (slider != null)
        {
            val = slider.value;
        }
        SetChannelLevel(val);
    }


    public void SetChannelLevel(float sliderValue)
    {
        //if the user-defined channel string is in the list of valid channel string then
        if (System.Array.Exists(validChannels, element => element == ChannelString))
        {
            float volume = Mathf.Log10(sliderValue) * 20;
            //represents slider with logarithmic scale like it is in the audio mixer system and sets it accordingly
            mixer.SetFloat(ChannelString, volume);
            PlayerPrefs.SetFloat(ChannelString, sliderValue);
        }
        else
        {
            Debug.LogWarning("Invalid channel string: " + ChannelString);
        }

    }
}