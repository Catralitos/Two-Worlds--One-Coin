using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class TitleScreenManager : MonoBehaviour
    {
        public GameObject titleScreen, storyScreen, tutorialScreen;

        public Button startGameButton,
            showStoryButton,
            hideStoryButton,
            showTutorialButton,
            hideTutorialButton,
            exitGameButton;

        private AudioManager _audioManager;
    
        private void Start()
        {
            _audioManager = GetComponent<AudioManager>();
            //_audioManager.Play("TitleMusic");
            startGameButton.onClick.AddListener(StartGame);
            showStoryButton.onClick.AddListener(ShowStory);
            hideStoryButton.onClick.AddListener(HideStory);
            showTutorialButton.onClick.AddListener(ShowTutorial);
            hideTutorialButton.onClick.AddListener(HideTutorial);
            exitGameButton.onClick.AddListener(ExitGame);
        }

        private static void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void ShowStory()
        {
            titleScreen.SetActive(false);
            storyScreen.SetActive(true);
        }

        private void HideStory()
        {
            storyScreen.SetActive(false);
            titleScreen.SetActive(true);
        }

        private void ShowTutorial()
        {
            titleScreen.SetActive(false);
            tutorialScreen.SetActive(true);
        }

        private void HideTutorial()
        {
            tutorialScreen.SetActive(false);
            titleScreen.SetActive(true);
        }

        private static void ExitGame()
        {
            Application.Quit();
        }
    }
}