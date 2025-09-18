using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private PlayerData _settings; // ScriptableObject reference
    [SerializeField] private GameObject _musicSource; // GameObject with AudioSource
    [SerializeField] private AudioListener _audioListener; // Optional if you want to toggle listener

    private void Update()  
    {
        if (_settings._isMusicOn)
        {
            if (_musicSource != null && !_musicSource.activeSelf)
                _musicSource.SetActive(true);

            if (_audioListener != null && !_audioListener.enabled)
                _audioListener.enabled = true;
        }
        else
        {
            if (_musicSource != null && _musicSource.activeSelf)
                _musicSource.SetActive(false);

            if (_audioListener != null && _audioListener.enabled)
                _audioListener.enabled = false;
        }
    }
}