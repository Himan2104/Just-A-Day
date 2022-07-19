using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioMixer Mixer;
    [SerializeField] TMP_Dropdown ResolutionSelect;
    [SerializeField] Toggle PostProcessing;
    [SerializeField] TMP_Dropdown FrameRateLimit;
    [SerializeField] Slider MasterVolume;
    [SerializeField] Slider SFXVolume;
    [SerializeField] Slider MusicVolume;

    private void Start()
    {
        ResolutionSelect.AddOptions(GenerateResolutionsAsOptions());
        Vector2 saved_res = ApplicationSettings.Video.ScreenResolution;
        foreach(Resolution res in Screen.resolutions)
        {
            if (res.width == saved_res.x && res.height == saved_res.y)
            {
                ResolutionSelect.value = ResolutionSelect.options.IndexOf(new TMP_Dropdown.OptionData(res.ToString()));
            }
        }

        PostProcessing.isOn = ApplicationSettings.Video.PostProcessing;

        MasterVolume.value = ApplicationSettings.Audio.MasterVolume;
        SFXVolume.value = ApplicationSettings.Audio.SFXVolume;
        MusicVolume.value = ApplicationSettings.Audio.MusicVolume;
    }

    public void SetResolution(int value)
    {
        ApplicationSettings.Video.ScreenResolution = new Vector2Int(Screen.resolutions[value].width, Screen.resolutions[value].height);

        Screen.SetResolution(ApplicationSettings.Video.ScreenResolution.x, ApplicationSettings.Video.ScreenResolution.y, true);
    }

    public void SetMasterVolume(float value)
    {
        ApplicationSettings.Audio.MasterVolume = value;
        Mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
    }

    public void SetSFXVolume(float value)
    {
        ApplicationSettings.Audio.SFXVolume = value;
        Mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20f);
    }

    public void SetMusicVolume(float value)
    {
        ApplicationSettings.Audio.MusicVolume = value;
        Mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20f);
    }

    List<TMP_Dropdown.OptionData> GenerateResolutionsAsOptions()
    {
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (Resolution res in Screen.resolutions)
        {
            options.Add(new TMP_Dropdown.OptionData(res.ToString()));
        }

        return options;
    }
}

