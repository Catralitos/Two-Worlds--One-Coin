using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTransitionScript : MonoBehaviour
{
   
    Material material;

    float cutoff = 0;
    public CoinFlipManager CoinFlipManager;
    public float transitionSpeed = 0.5f;

    private int state = 0;
    private ChangeCameraScript callback;
    private int cameraNumber;
    public List<Texture2D> transitionTextureList;
    void Start()
    {
        material = this.GetComponent<Image>().material;
        material.SetFloat("_Cutoff", 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == 1)
        {

            TransitionToBlack();
        }


        else if (state == 2)
        {
            TransitionFromBlack();
        }
          
    }


    public void ActivateTransition(ChangeCameraScript script, int cameraNumber)
    {
        var rand = Random.Range(0, transitionTextureList.Count);

        material.SetTexture("_TransitionTex", transitionTextureList[rand]);

        this.callback = script;
        this.cameraNumber = cameraNumber;
        if (state == 0)
        {
            state = 1;
            this.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f); ;
        }
    }

    public void Intermission()
    {
        this.callback.CutTo(cameraNumber);
        state = 2;
    }

    public void FinishedTransition()
    {
        cutoff = 0;
        state = 0;
        CoinFlipManager.OnTransitionEnd();
    }

    public void TransitionToBlack()
    {
        cutoff = material.GetFloat("_Cutoff");
        var newCutoff = cutoff + Time.deltaTime * transitionSpeed;
        if (cutoff <= 1)
        {

            material.SetFloat("_Cutoff", newCutoff);

        }
        else if (cutoff > 1)
            Intermission();
    }

    public void TransitionFromBlack()
    {
        cutoff = material.GetFloat("_Cutoff");
        var newCutoff = cutoff - Time.deltaTime * transitionSpeed;
        if (cutoff >= 0)
        {
            material.SetFloat("_Cutoff", newCutoff);

        } else if(cutoff < 0)
        {
            FinishedTransition();
        }
    }
}
