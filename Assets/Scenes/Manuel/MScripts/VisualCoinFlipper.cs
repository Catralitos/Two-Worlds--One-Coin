using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCoinFlipper : MonoBehaviour
{
    public Image image;
    public Sprite[] sides;
    int flipCount = 1;
    public int maxFlip = 3;
    CoinFlipManager manager;
    Animator anim;
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    public void OnInteract(float result, CoinFlipManager manager)
    {
        this.manager = manager;
        StartCoroutine(WaitPlease(0.005f, 1.0f, result));
    }

    IEnumerator WaitPlease(float duration , float size, float result)
    {

        var auxmaxFlip = maxFlip - result;
        anim.SetTrigger("Flip");
        while (flipCount < auxmaxFlip)
        {
            while (size > 0.1)
            {
                size = size - 0.07f;
                transform.localScale = new Vector3(1, size, 1);
                yield return new WaitForSeconds(duration);
            }
            image.sprite = sides[flipCount % 2];
            while (size < 0.99)
            {
                size = size + 0.07f;
                transform.localScale = new Vector3(1, size, size);
                yield return new WaitForSeconds(duration);
            }
            flipCount++;
        }

        flipCount = 0;
        yield return new WaitForSeconds(1.0f);
        OnFinishedFlipping();
    }
    
    void OnFinishedFlipping()
    {
        manager.OnFlipEnd();
    }
}
