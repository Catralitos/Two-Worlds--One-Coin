using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTransitionScript : MonoBehaviour
{
    public Material TransitionMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, TransitionMaterial);
    }
}
