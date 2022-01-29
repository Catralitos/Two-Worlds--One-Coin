using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoinFlipManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI text;
    public ChangeCameraScript cameraManager;
    public VisualCoinFlipper flipObject;

    public float flipCoinCooldown = 5.0f;
    private float flipCoinCooldownAux;
    private bool pressedButton = false;
    public int result;

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
                

                result = Random.Range(0, 2);
                pressedButton = true;
                flipObject.OnInteract(result, this);
                Debug.Log("Result: " + result);
               
            }
        }

    }

    public void OnFlipEnd()
    {
        cameraManager.HandleCoinResult(result);
    }
}
