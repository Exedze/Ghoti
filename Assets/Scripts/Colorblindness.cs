using System;
using UnityEngine;

public class Colorblindness : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    private bool on = true;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (on)
        {
            Graphics.Blit(src,dest,mat);
        }
    }
}
