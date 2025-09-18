using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private PlayerData _data;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Button _musicON;
    [SerializeField] private Button _musicOFF;
    
    
    private void Start()
    {
        //buttons music
        _musicON.onClick.AddListener(TurnOnMusic);
        _musicOFF.onClick.AddListener(TurnOffMusic);
        
    }
    
    public void OpenSettings()
    {
        _settings.SetActive(true);
    }
    public void CloseSettings()
    {
        _settings.SetActive(false);
    }

    public void TurnOnMusic()
    {
        _data._isMusicOn = true;
        _audioSource.Play();
    }

    public void TurnOffMusic()
    {
        _data._isMusicOn = false;
        _audioSource.Stop();
    }

    public void OpenPrivacyPolicyView()
    {
        _panel.SetActive(true);
    }
    
    public void ClosePrivacyPolicyView()
    {
        _panel.SetActive(false);
    }
}
