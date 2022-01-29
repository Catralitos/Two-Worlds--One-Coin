using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

        public void FlipCoin(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (!pressedButton)
                {
                    var auxresult = Random.Range(0, 2);

                    if (auxresult != this.result)
                        resultChanged = true;
                    else resultChanged = false;

                    result = auxresult;
                    pressedButton = true;

                    flipObject.OnInteract(result, this);
                    Debug.Log("Result: " + result);
               
               
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
    }
}
