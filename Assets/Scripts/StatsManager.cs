using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float Openness
    {
        get => openness;
        set => openness = Mathf.Clamp01(value);
    }
    public float Mobility
    {
        get => mobility;
        set => mobility = Mathf.Clamp01(value);
    }

    private float openness;
    private float mobility;
}
