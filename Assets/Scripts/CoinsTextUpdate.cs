using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsTextUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private PlayerData _playerData;

    private void Update()
    {
        _coinsText.text = _playerData.coins.ToString();
    }
}
