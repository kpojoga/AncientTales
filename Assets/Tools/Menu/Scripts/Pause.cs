using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Set(bool on)
    {
        Time.timeScale = on ? 0 : 1;
    }
}
