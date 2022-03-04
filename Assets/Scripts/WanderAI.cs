using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    float waitTime;

    Vector2 wayPoint;

    private void Start()
    {
        //StartCoroutine(Wandering());
        SetNewDestination();
        waitTime = 1f;
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
        Debug.Log("Wait Time = " + waitTime);

        if (waitTime > 8)
        {
            
            waitTime = 0f;
        }

        else if (waitTime == 0)
        {

        }
        else
        {
            Move();

        }

        if (Vector2.Distance(transform.position, wayPoint) <range)
        {

            SetNewDestination();
            //StartCoroutine(Wandering()) ;
            
        }
    }

    void SetNewDestination ()
    {
        
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range(-maxDistance, maxDistance));
        
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
    }


}




