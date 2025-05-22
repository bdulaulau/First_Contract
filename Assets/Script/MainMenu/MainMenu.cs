using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    public AudioClip exit;

    public void Start()
    {
        settingsWindow.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        AudioManager.instance.PlayClipAt(exit, transform.position);
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
