using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulturesManager : MonoBehaviour
{
    public Culture BaseCulture => baseCulture;

    private Culture baseCulture;
    private float culturesPresence1;
    private float culturesPresence2;
    private float culturesPresence3;
    private float culturesPresence4;
    private SpriteRenderer spriteRenderer;
    private Dude dude;



    public void Init(Culture baseCulture, Dude dude)
    {
        this.baseCulture = baseCulture;
        this.dude = dude;
        switch (baseCulture)
        {
            case Culture.CULTURE1:
                culturesPresence1 = 1f;
                break;
            case Culture.CULTURE2:
                culturesPresence2 = 1f;
                break;
            case Culture.CULTURE3:
                culturesPresence3 = 1f;
                break;
            case Culture.CULTURE4:
                culturesPresence4 = 1f;
                break;

        }
        ModifyColors();
    }

    public void IncreaseCulture(Culture culture, float amount)
    {
        switch (culture)
        {
            case Culture.CULTURE1:
                float factor = (1 - culturesPresence1 + amount) / (1 - culturesPresence1);
                culturesPresence2 *= factor;
                culturesPresence3 *= factor;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE2:
                factor = (1 - culturesPresence2 + amount) / (1 - culturesPresence2);
                culturesPresence1 *= factor;
                culturesPresence3 *= factor;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE3:
                factor = (1 - culturesPresence3 + amount) / (1 - culturesPresence3);
                culturesPresence1 *= factor;
                culturesPresence2 *= factor;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE4:
                factor = (1 - culturesPresence4 + amount) / (1 - culturesPresence4);
                culturesPresence1 *= factor;
                culturesPresence2 *= factor;
                culturesPresence3 *= factor;
                break;
        }
        ModifyColors();
    }



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ModifyColors()
    {
        float[] colorsRatios = new float[3];
        colorsRatios[0] = 1 - culturesPresence1;
        colorsRatios[1] = colorsRatios[0] - culturesPresence2;
        colorsRatios[2] = colorsRatios[1] - culturesPresence3;
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        block.SetTexture("_MainTex", spriteRenderer.sprite.texture);
        block.SetFloat("_Color2Ratio", colorsRatios[0]);
        block.SetFloat("_Color3Ratio", colorsRatios[1]);
        block.SetFloat("_Color4Ratio", colorsRatios[2]);
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