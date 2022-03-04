using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    private WanderAI wanderAI;
    private StatsManager statsManager;
    private CulturesManager culturesManager;



    private void Awake()
    {
        wanderAI = GetComponent<WanderAI>();
        statsManager = GetComponent<StatsManager>();
        culturesManager = GetComponent<CulturesManager>();
    }



    public void Init(Culture baseCulture)
    {
        culturesManager.Init(baseCulture);
    }
}
