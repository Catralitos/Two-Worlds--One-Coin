using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlip : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;
    public ChangeCameraScript cameraManager;

    void Start()
    {
        InvokeRepeating("FlipCoin", 2.0f, 5.0f);
    }


    public void FlipCoin()
    {
        var result = Random.Range(0, 2);
       

        if (result == 1) // Coroa
            text.text = "Coinflip: Tails";
        else
        {
            text.text = "Coinflip: Heads";
        }

        Debug.Log("Result: " + result);
        cameraManager.HandleCoinResult(result);
    }
}
