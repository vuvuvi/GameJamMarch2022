using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulturesManager : MonoBehaviour
{
    private Culture baseCulture;
    private SpriteRenderer spriteRenderer;
    private Dude dude;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(Culture baseCulture, Dude dude)
    {
        this.baseCulture = baseCulture;
        this.dude = dude;
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (baseCulture)
        {
            case Culture.CULTURE2:
                color2Ratio = 1f;
                break;
            case Culture.CULTURE3:
                color2Ratio = 1f;
                color3Ratio = 1f;
                break;
            case Culture.CULTURE4:
                color2Ratio = 1f;
                color3Ratio = 1f;
                color4Ratio = 1f;
                break;

        }
        block.SetFloat("Color2Ratio", color2Ratio);
        block.SetFloat("Color3Ratio", color3Ratio);
        block.SetFloat("Color4Ratio", color4Ratio);
        spriteRenderer.SetPropertyBlock(block);
    }
}

public enum Culture
{
    CULTURE1,
    CULTURE2,
    CULTURE3,
    CULTURE4
}