using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulturesManager : MonoBehaviour
{
    public Culture BaseCulture => baseCulture;

    [SerializeField] private float influenceSpeed;
    [SerializeField] private Color outlineColor1;
    [SerializeField] private Color outlineColor2;
    [SerializeField] private Color outlineColor3;
    [SerializeField] private Color outlineColor4;
    private Culture baseCulture;
    private float culturesPresence1;
    private float culturesPresence2;
    private float culturesPresence3;
    private float culturesPresence4;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer outline;
    private Dude dude;



    public void Init(Culture baseCulture, Dude dude)
    {
        this.baseCulture = baseCulture;
        this.dude = dude;
        switch (baseCulture)
        {
            case Culture.CULTURE1:
                culturesPresence1 = 1f;
                outline.color = outlineColor1;
                break;
            case Culture.CULTURE2:
                culturesPresence2 = 1f;
                outline.color = outlineColor2;
                break;
            case Culture.CULTURE3:
                culturesPresence3 = 1f;
                outline.color = outlineColor3;
                break;
            case Culture.CULTURE4:
                culturesPresence4 = 1f;
                outline.color = outlineColor4;
                break;

        }
        ModifyColors();
    }

    public void IncreaseCulture(Culture culture)
    {
        float amount = dude.StatsManager.Openness * Time.deltaTime * influenceSpeed;
        switch (culture)
        {
            case Culture.CULTURE1:
                if (culturesPresence1 == 1) break;
                float factor = (1 - (Mathf.Clamp01(culturesPresence1 + amount))) / (1 - culturesPresence1);
                culturesPresence1 += amount;
                culturesPresence2 *= factor;
                culturesPresence3 *= factor;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE2:
                if (culturesPresence2 == 1) break;
                factor = (1 - (Mathf.Clamp01(culturesPresence2 + amount))) / (1 - culturesPresence2);
                culturesPresence1 *= factor;
                culturesPresence2 += amount;
                culturesPresence3 *= factor;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE3:
                if (culturesPresence3 == 1) break;
                factor = (1 - (Mathf.Clamp01(culturesPresence3 + amount))) / (1 - culturesPresence3);
                culturesPresence1 *= factor;
                culturesPresence2 *= factor;
                culturesPresence3 += amount;
                culturesPresence4 *= factor;
                break;
            case Culture.CULTURE4:
                if (culturesPresence4 == 1) break;
                factor = (1 - (Mathf.Clamp01(culturesPresence4 + amount))) / (1 - culturesPresence4);
                culturesPresence1 *= factor;
                culturesPresence2 *= factor;
                culturesPresence3 *= factor;
                culturesPresence4 += amount;
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