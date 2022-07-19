using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class holding all settings fields. Stored in PlayerPrefs.
/// </summary>
public class ApplicationSettings
{
    /// <summary>
    /// True : Settings are present
    /// False : Use default settings
    /// </summary>
    public static bool Loaded
    {
        get { return bool.Parse(PlayerPrefs.GetString("settings_loaded", bool.FalseString)); }
        set { PlayerPrefs.SetString("settings_loaded", value.ToString()); }
    }

    public static int FOV
    {
        get { return PlayerPrefs.GetInt("settings_fov", 60); }
        set { PlayerPrefs.SetInt("settings_fov", 60); }
    }

    /// <summary>
    /// 0 : Off
    /// 1 : Basic
    /// 2 : Advanced
    /// 3 : Give Me Everything!
    /// </summary>
    public static int PerfMetrics
    {
        get { return PlayerPrefs.GetInt("settings_perfmetrics", 0); }
        set { PlayerPrefs.SetInt("settings_perfmetrics", value); }
    }

    /// <summary>
    /// Contains video settings
    /// </summary>
    public class Video
    {
        public static Vector2Int ScreenResolution
        {
            get { return new Vector2Int(PlayerPrefs.GetInt("settings_screenresolution_x", Screen.currentResolution.width), PlayerPrefs.GetInt("settings_screenresolution_y", Screen.currentResolution.height)); }
            set { PlayerPrefs.SetInt("settings_screenresolution_x", value.x); PlayerPrefs.GetInt("settings_screenresolution_y", value.y); }
        }

        /// <summary>
        /// -1 : Default
        ///  0 : Uncapped
        /// n>0: n x 30;
        /// </summary>
        public static int FramerateLimit
        {
            get { return PlayerPrefs.GetInt("settings_fpslim", -1); }
            set { PlayerPrefs.SetInt("settings_fpslim", value); }
        }

        public static bool PostProcessing
        {
            get { return bool.Parse(PlayerPrefs.GetString("settings_ppx", bool.TrueString)); }
            set { PlayerPrefs.SetString("settings_ppx", value.ToString()); }
        }
    }

    /// <summary>
    /// Contains audio settings
    /// </summary>
    public static class Audio
    {
        public static float MasterVolume
        {
            get { return PlayerPrefs.GetFloat("settings_audio_master", 1f); }
            set { PlayerPrefs.SetFloat("settings_audio_master", value); }
        }

        public static float MusicVolume
        {
            get { return PlayerPrefs.GetFloat("settings_audio_music", 1f); }
            set { PlayerPrefs.SetFloat("settings_audio_music", value); }
        }

        public static float SFXVolume
        {
            get { return PlayerPrefs.GetFloat("settings_audio_sfx", 1f); }
            set { PlayerPrefs.SetFloat("settings_audio_sfx", value); }
        }
    }

    public class Gameplay
    {
        public static bool InvertLookAxis
        {
            get { return bool.Parse(PlayerPrefs.GetString("settings_invertlook", bool.FalseString)); }
            set { PlayerPrefs.SetString("settings_invertlook", value.ToString()); }
        }

        public class Sensitivity
        {
            public static float Mouse
            {
                get { return PlayerPrefs.GetFloat("settings_sens_mouse", 1f); }
                set { PlayerPrefs.SetFloat("settings_sens_mouse", value); }
            }

            public static float Controller
            {
                get { return PlayerPrefs.GetFloat("settings_sens_controller", 1f); }
                set { PlayerPrefs.SetFloat("settings_sens_controller", value); }
            }
        }
    }
}
