using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private GameObject _location1;
    [SerializeField] private GameObject _location2;
    [SerializeField] private GameObject _location3;
    
    public Material[] skyboxes; 

    private void Update()
    {
        if (_playerData.location == 1)
        {
            _location1.SetActive(true);
        
            _location2.SetActive(false);
            _location3.SetActive(false);
            
            RenderSettings.skybox = skyboxes[0];
            DynamicGI.UpdateEnvironment();
        }
        else if (_playerData.location == 2)
        {
            _location2.SetActive(true);
        
            _location1.SetActive(false);
            _location3.SetActive(false);
            
            RenderSettings.skybox = skyboxes[1];
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            _location3.SetActive(true);
        
            _location2.SetActive(false);
            _location1.SetActive(false);
            
            RenderSettings.skybox = skyboxes[2];
            DynamicGI.UpdateEnvironment();
        }
    }
}
