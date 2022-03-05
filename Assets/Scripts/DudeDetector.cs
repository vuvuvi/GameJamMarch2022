using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeDetector : MonoBehaviour
{
    [SerializeField] private Dude dude;
    List<(Collider2D, Dude)> collisions;
    // [SerializeField] private LayerMask layer;



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Dude")) return;
        Dude otherDude = collider.GetComponent<Dude>();
        if (otherDude == null) return;

        collisions.Add((collider, otherDude));
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        (Collider2D, Dude) itemToRemove = (null, null);
        foreach (var collision in collisions)
        {
            if (collision.Item1 == collider)
            {
                itemToRemove = collision;
                break;
            }
        }
        collisions.Remove(itemToRemove);
    }

    private void Awake()
    {
        collisions = new List<(Collider2D, Dude)>();
    }

    private void Update()
    {
        foreach (var collision in collisions)
        {
            collision.Item2.CulturesManager.IncreaseCulture(dude.CulturesManager.BaseCulture);
        }
    }
}
