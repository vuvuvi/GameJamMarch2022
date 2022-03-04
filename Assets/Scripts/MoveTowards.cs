using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour


{
    public Transform zonePos;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, zonePos.position, speed * Time.deltaTime);
    }
}
