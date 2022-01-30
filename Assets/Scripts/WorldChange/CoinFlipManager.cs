using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace WorldChange
{
    public class CoinFlipManager : MonoBehaviour
    {

        public TMPro.TextMeshProUGUI text;
        public ChangeCameraScript cameraManager;
        public VisualCoinFlipper flipObject;

        public float flipCoinCooldown = 5.0f;
        private bool pressedButton = false;
        public int result = 0;
        private bool resultChanged = false;
        public Image frontImg;
        public Image backImg;

        private float _flipThreshold;
        public float increasePerFailedFlip = 0.05f;

        private void Start()
        {
            _flipThreshold = -1.0f;
        }

        public void FlipCoin(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (!pressedButton)
                {
                    float randomFloat = Random.Range(0.0f, 1.0f);
                    Debug.Log(randomFloat + " " + _flipThreshold);
                    
                    var auxresult = randomFloat >= _flipThreshold ? 1 : 0;

                    if (auxresult != this.result)
                    {
                        resultChanged = true;
                        _flipThreshold = 0.5f;
                    }
                    else
                    {
                        resultChanged = false;
                        _flipThreshold -= increasePerFailedFlip;
                    }

                    result = auxresult;
                    pressedButton = true;

                    flipObject.OnInteract(result, this);
                    //Debug.Log("Result: " + result);
               
               
                }
            }

        }

        public void OnFlipEnd()
        {
            cameraManager.HandleCoinResult(result);
       
            if(!resultChanged)
                StartCoroutine("Cooldown");
        }

        public void OnTransitionEnd()
        {
            backImg.sprite = frontImg.sprite;
            StartCoroutine("Cooldown");
            
        }

        IEnumerator Cooldown()
        {
            var cooldown = 0.0f;

            while (true)
            {
                cooldown += Time.deltaTime;
           
                frontImg.fillAmount = cooldown / flipCoinCooldown;
                if (cooldown >= flipCoinCooldown)
                {
                    pressedButton = false;
                    StopCoroutine("Cooldown");
                }

                yield return null;
            }
        }

        public void PlayAgain()
        {
            var manager = GameObject.FindObjectOfType<GameManager>();
           if (manager != null)
                manager.RestartGame();

            else UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }


   
}
