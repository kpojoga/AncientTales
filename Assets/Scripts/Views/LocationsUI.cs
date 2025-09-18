using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationsUI : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    
    [SerializeField] private GameObject _pointer1;
    [SerializeField] private GameObject _pointer2;
    [SerializeField] private GameObject _pointer3;
    
    [SerializeField] private GameObject _lock1;
    [SerializeField] private GameObject _lock2;

    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    
    public void OpenLocation1()
    {
        _playerData.location = 1;
        
        _pointer1.SetActive(true);
        _pointer2.SetActive(false);
        _pointer3.SetActive(false);
    }
    
    // public void OpenLocation2()
    // {
    //     _playerData.location = 2;
    //
    //     if (_playerData.isUlocked1)
    //     {
    //         _lock1.SetActive(false);
    //         
    //         _pointer1.SetActive(false);
    //         _pointer2.SetActive(true);
    //         _pointer3.SetActive(false); 
    //     }
    // }
    
    // public void OpenLocation3()
    // {
    //     _playerData.location = 3;
    //
    //     if (_playerData.isUlocked2)
    //     {
    //         _lock2.SetActive(false);
    //         
    //         _pointer1.SetActive(false);
    //         _pointer2.SetActive(false);
    //         _pointer3.SetActive(true); 
    //     }
    // }
    
    // private void Start()
    // {
    //     _playerData.location = 1;
    // }

    private void Update()
    {
        // if (_playerData.isUlocked1 == false)
        // {
        //     _button2.interactable = false;
        // }
        // else if (_playerData.isUlocked2 == false)
        // {
        //     _button3.interactable = false;
        // }
    }
}
