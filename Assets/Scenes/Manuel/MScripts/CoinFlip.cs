using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoinFlip : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;
    public ChangeCameraScript cameraManager;
    public Animator buttonAnimator;

    public float flipCoinCooldown = 5.0f;
    private float flipCoinCooldownAux;
    private bool pressedButton = false;

    void Start()
    {
        flipCoinCooldownAux = flipCoinCooldown;
    }
    void FixedUpdate()
    {
        //   InvokeRepeating("FlipCoin", 2.0f, 2.0f);

        if (pressedButton)
        {
            if (flipCoinCooldownAux <= 0)
            {
                buttonAnimator.SetTrigger("FadeIn");
                flipCoinCooldownAux = flipCoinCooldown;
                pressedButton = false;
            }
            else
            {
                flipCoinCooldownAux -= Time.deltaTime;
            }
        }
    }


    public void FlipCoin(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!pressedButton)
            {

                var result = Random.Range(0, 2);
                pressedButton = true;
                buttonAnimator.SetTrigger("Fade");

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

    }
}
