using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateGame : MonoBehaviour
{
    [SerializeField] private Button _goodButton;
    [SerializeField] private Button _badButton;

    private void Awake()
    {
        _goodButton.onClick.AddListener(SetRate);
        _badButton.onClick.AddListener(DontSetRate);
    }

    private void DontSetRate()
    {
        gameObject.SetActive(false);
    }

    private void SetRate()
    {
        UnityEngine.iOS.Device.RequestStoreReview();
        gameObject.SetActive(false);
    }
}
