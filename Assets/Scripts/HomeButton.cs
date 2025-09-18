using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
