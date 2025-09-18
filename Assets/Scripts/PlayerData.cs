using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATA", menuName = "ScriptableObjects/DATA")]
public class PlayerData : ScriptableObject
{
    public int coins;

    public int location;

    //public bool isUlocked1;
    //public bool isUlocked2;

    public bool _isMusicOn;
}
