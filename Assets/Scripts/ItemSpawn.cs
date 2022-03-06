using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public float spawnfrequency;
    public GameObject item;
    public Transform itemspawn;
    public Transform canvas;
    public int count = 0;
    float nextspawntime;
    bool isAvailable;
    // Start is called before the first frame update

   
    // Update is called once per frame
    void Update()
    {
        
      if (isAvailable)
        {
            return;
        }

        if (Time.time >= nextspawntime && count <3)
        {
            GameObject itemdrop = Instantiate(item, canvas);
            isAvailable = true;
            
            itemdrop.transform.position = itemspawn.position;
           
            count++;
            
        }

       

   
    }

    public void SetNextSpawnTime()
    {
        nextspawntime = Time.time+  spawnfrequency;
        isAvailable = false;    
    }
    }
