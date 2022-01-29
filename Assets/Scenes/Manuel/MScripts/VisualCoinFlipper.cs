using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCoinFlipper : MonoBehaviour
{
    Image image;
    public Sprite[] sides;
    int flipCount = 1;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnInteract()
    {
        StartCoroutine(WaitPlease(0.0001f, 1.0f));
    }

    IEnumerator WaitPlease(float duration , float size)
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
    

}
