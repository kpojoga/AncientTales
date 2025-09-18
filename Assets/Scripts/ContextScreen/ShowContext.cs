using UnityEngine;

public class ShowContext : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    void Start()
    {
        int value = PlayerPrefs.GetInt("ContextScreen", 0);
        if (value == 0)
        {
            screen.SetActive(true);
            PlayerPrefs.SetInt("ContextScreen", 1);
        }
    }
}
