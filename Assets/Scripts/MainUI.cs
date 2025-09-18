using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUI : MonoBehaviour
{
    public void StartGame()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene("Level " + level.ToString());
    }
    public void OpenPP()
    {
        ///Application.("https://pharaonstomb.com/privacy.html");
    }
    public void OpenFB()
    {
        Application.OpenURL("https://www.facebook.com/groups/367545196440460");
    }
}
