using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager audioManager;
    public string startSongName;
    public string hellSong;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioManager = this.GetComponent<Audio.AudioManager>();
        audioManager.Play(hellSong);
        audioManager.PauseAudio(hellSong);
        audioManager.Play(startSongName);


    }

    public void ChangeSong(string s)
    {
        var playing = audioManager.GetIsPlaying();
        if (playing != null)
            audioManager.PauseAudio(playing);
        audioManager.UnPauseAudio(s);
    }


    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void RIP()
    {
        GameObject.FindObjectOfType<GameOverHandler>()?.LoseGame();
    }

    private IEnumerator HandleDeath()
    {
        
        var cooldown = 0.0f;

            while (true)
            {
                cooldown += Time.deltaTime;

              /*  if (cooldown >= flipCoinCooldown)
                {
                    pressedButton = false;
                    StopCoroutine("Cooldown");
                }
              */
                yield return null;
            }
       
    }

}
