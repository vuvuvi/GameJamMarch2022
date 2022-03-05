using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float Openness
    {
        get => openness;

        set => openness = Mathf.Clamp01(value);
        //set "aura" et if le joueur lui assigne un accessoire, changer en cons�quence.
    }
    public float Mobility
    {
        get => mobility;
        set => mobility = Mathf.Clamp01(value);
        //changer en cons�quence si le joueur  lui assigne un accessoire.
    }

    [SerializeField] private GameObject backpack;
    [SerializeField] private GameObject hat;
    [SerializeField] private SpriteRenderer eye;
    private float openness;
    private float mobility;
    private Dude dude;



    public void Init(Dude dude)
    {
        this.dude = dude;
        openness = Random.value;
        mobility = Random.value;

        backpack.SetActive(mobility > 0.6f);
        hat.SetActive(mobility < 0.4f);
        eye.color = new Color(eye.color.r * openness, eye.color.g * openness, eye.color.b * openness, eye.color.a);
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
    //        Debug.Log("Sac � dos");
    //    }
    //    if (other.CompareTag("Sword"))
    //    {
    //        //Activer le layer sword
    //        Debug.Log("Ep�e");
    //    }
    //    if (other.CompareTag("Rateau"))
    //    {
    //        //Activer le layer fourche
    //        Debug.Log("Rateau");
    //    }

    //}



}
