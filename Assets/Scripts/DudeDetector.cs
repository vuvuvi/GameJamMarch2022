using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeDetector : MonoBehaviour
{
    [SerializeField] private Dude dude;
    [SerializeField] private LayerMask layer;



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != layer) return;

        Dude otherDude = collider.GetComponent<Dude>();
        // otherDude.CulturesManager.StatsManager.Openness
    }
}
