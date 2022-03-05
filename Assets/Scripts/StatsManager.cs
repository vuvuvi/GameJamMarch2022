using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private float openness;
    private float mobility;

    private Dude dude;

   

    public float Openness
    {
        get => openness;

        set => openness = Mathf.Clamp01(value);
        //set "aura" et if le joueur lui assigne un accessoire, changer en conséquence. 
    }
    public float Mobility
    {
        get => mobility;
        set => mobility = Mathf.Clamp01(value);
        //changer en conséquence si le joueur  lui assigne un accessoire. 
    }


    public void Init(Dude dude)
    {
        this.dude = dude;
    }

   

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Hat"))
    //    {
    //        //Activer le layer hat 
    //        Debug.Log("Chapeau");
    //    }

    //    if (other.CompareTag("Backpack"))
    //    {
    //        //Activer le layer backpack 
    //        Debug.Log("Sac à dos");
    //    }
    //    if (other.CompareTag("Sword"))
    //    {
    //        //Activer le layer sword 
    //        Debug.Log("Epée");
    //    }
    //    if (other.CompareTag("Rateau"))
    //    {
    //        //Activer le layer fourche 
    //        Debug.Log("Rateau");
    //    }

    //}



}
