using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winGameScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        
        if(winGameScreen != null)
            winGameScreen.SetActive(false);
    }

    public void LoseGame()
    {

        gameOverScreen.SetActive(true);
    }

    public void WinGame()
    {
        winGameScreen.SetActive(true);
    }
}
