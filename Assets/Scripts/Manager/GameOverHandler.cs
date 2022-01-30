using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winGameScreen;
    public GameObject gameUI;

    void Start()
    {
        gameOverScreen.SetActive(false);
        
        if(winGameScreen != null)
            winGameScreen.SetActive(false);
    }

    public void LoseGame()
    {
        gameUI.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void WinGame()
    {
        gameUI.SetActive(false);
        winGameScreen.SetActive(true);
    }
}
