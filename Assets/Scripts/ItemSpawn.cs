using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    float time;
    public GameObject hat1, backpack1, hat2, backpack2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        Debug.Log(time);

        if (time >= 45)
        {
            hat1.SetActive(true);
            backpack1.SetActive(true);
        }

        if (time >= 90) { 
            hat2.SetActive(true);
            backpack2.SetActive(true);}
    }
}
