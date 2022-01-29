using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTransitionScript : MonoBehaviour
{
   
    Material material;

    float cutoff = 0;
    public float transitionSpeed = 0.5f;

    private bool transitioning = false;
    void Start()
    {
        material = this.GetComponent<Image>().material;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transitioning)
        {
            cutoff = material.GetFloat("_Cutoff");
            var newCutoff = cutoff + Time.deltaTime * transitionSpeed;
            if (cutoff < 1)
            {
                
                material.SetFloat("_Cutoff", newCutoff);
              
            }
            else
            {
                transitioning = false;
                cutoff = 0;
                this.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }


    public void ActivateTransition()
    {
        if (!transitioning)
        {
            transitioning = true;
            this.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f); ;
        }
    }
}
