using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeDetector : MonoBehaviour
{
    [SerializeField] private Dude dude;
    // [SerializeField] private LayerMask layer;



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Dude")) return;

        Dude otherDude = collider.GetComponent<Dude>();
        if (otherDude == null) return;
        if (otherDude.CulturesManager.BaseCulture == dude.CulturesManager.BaseCulture) return;

        otherDude.CulturesManager.IncreaseCulture(dude.CulturesManager.BaseCulture, dude.StatsManager.Openness);
    }
}
