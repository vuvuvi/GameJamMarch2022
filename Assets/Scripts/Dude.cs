using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    public StatsManager StatsManager => statsManager;
    public CulturesManager CulturesManager => culturesManager;
    public WanderAI WanderAI => wanderAI;

    private StatsManager statsManager;
    private CulturesManager culturesManager;
    private WanderAI wanderAI;



    private void Awake()
    {
        statsManager = GetComponent<StatsManager>();
        culturesManager = GetComponent<CulturesManager>();
        wanderAI = GetComponent<WanderAI>();
    }



    public void Init(Culture baseCulture, Vector4 boardBounds)
    {
        statsManager.Init(this);
        culturesManager.Init(baseCulture, this);
        wanderAI.Init(boardBounds, this);
    }
}
