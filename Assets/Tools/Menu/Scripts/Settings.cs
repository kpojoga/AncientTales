using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Toggle _vibroToggle;

    public void Initialize()
    {
        _soundToggle.onValueChanged.AddListener(delegate {SetSettings();});

        _soundToggle.isOn = PlayerPrefs.GetInt("Sound") != 0;
        _vibroToggle.isOn = PlayerPrefs.GetInt("Vibro") != 0;

        ServiceLocator.GetService<AudioListener>().enabled = _soundToggle.isOn;
    }

    public void SetSettings()
    {
        PlayerPrefs.SetInt("Sound", _soundToggle.isOn ? 1 : 0);
        ServiceLocator.GetService<AudioListener>().enabled = _soundToggle.isOn;
        PlayerPrefs.SetInt("Vibro", _vibroToggle.isOn ? 1 : 0);
    }

    public bool SoundOn()
    {
        return _soundToggle.isOn;
    }

    public bool VibroOn()
    {
        return _vibroToggle.isOn;
    }
}
