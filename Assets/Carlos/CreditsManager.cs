using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    
    public Button backToTitleButton, exitGameButton;

    private AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager = GetComponent<AudioManager>();
        //_audioManager.Play("CreditsMusic");
        backToTitleButton.onClick.AddListener(LoadTitle);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private static void LoadTitle()
    {
        SceneManager.LoadScene(0);
    }

    private static void ExitGame()
    {
        Application.Quit();
    }
}
