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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSong(string s)
    {
        var playing = audioManager.GetIsPlaying();
        if (playing != null)
            audioManager.PauseAudio(playing);
        Debug.Log("Play: " + s);
        audioManager.UnPauseAudio(s);
    }
}
