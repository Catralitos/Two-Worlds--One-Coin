using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager audioManager;
    public string startSongName;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioManager = this.GetComponent<Audio.AudioManager>();
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
            audioManager.Stop(playing);

        audioManager.Play(s);
    }
}
